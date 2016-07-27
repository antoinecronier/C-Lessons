using ClassLibrary2.Attributs;
using ClassLibrary2.Entities.Reflection;
using ClassLibrary2.EnumManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entities.Generator
{
    public class EntityGeneratorFakerTyper<T> where T : class
    {
        private Reflectionner reflectionner;
        private Dictionary<String, object> itemProperties;

        public EntityGeneratorFakerTyper()
        {
            reflectionner = new Reflectionner();

            if (typeof(T).Name.Equals(TypeEnum.LIST))
            {
                var type = Type.GetType(typeof(List<T>).AssemblyQualifiedName);
                var list = (List<T>)Activator.CreateInstance(type);
                itemProperties = reflectionner.ReadClass<T>();
            }
            else
            {
                itemProperties = reflectionner.ReadClass<T>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inheritance"></param>
        /// <returns></returns>
        public T GenerateItem(Int32 inheritance = 2)
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            if (inheritance > 0)
            {
                inheritance--;

                foreach (var item in itemProperties)
                {
                    PropertyInfo property = typeof(T).GetProperty(item.Key);
                    if (property.CanWrite && property.GetSetMethod(/*nonPublic*/ true).IsPublic)
                    {
                        if (property.CustomAttributes.Where(x => x.AttributeType.Name.Equals("FakerTyper")).ToList().Count > 0)
                        {
                            foreach (var item1 in property.CustomAttributes)
                            {
                                switch (item1.ConstructorArguments[0].Value.ToString())
                                {
                                    case TypeEnumCustom.NAME:
                                        property.SetValue(result, Faker.Name.First());
                                        break;
                                    case TypeEnumCustom.SURNAME:
                                        property.SetValue(result, Faker.Name.Last());
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            switch (property.PropertyType.Name)
                            {
                                case TypeEnum.INT32:
                                    property.SetValue(result, Faker.RandomNumber.Next(Int32.MaxValue));
                                    break;
                                case TypeEnum.INT:
                                    property.SetValue(result, Faker.RandomNumber.Next(Int32.MaxValue));
                                    break;
                                case TypeEnum.STRING:
                                    property.SetValue(result, Faker.Name.FullName());
                                    break;
                                case TypeEnum.LIST:
                                    //object list = Activator.CreateInstance(
                                    //    typeof(List<>).MakeGenericType(property.PropertyType.GetGenericArguments()));
                                    //property.SetValue(result, list);
                                    object generatorList = Activator.CreateInstance(typeof(EntityGenerator<>)
                                        .MakeGenericType(new Type[] { property.PropertyType }));
                                    property.SetValue(result, generatorList.GetType().GetMethod("GenerateListItems").Invoke(generatorList, new object[] { inheritance }));
                                    //Type.GetType(typeof(List<T>).AssemblyQualifiedName)
                                    break;
                                default:
                                    object generator = Activator.CreateInstance(typeof(EntityGenerator<>)
                                        .MakeGenericType(new Type[] { property.PropertyType }));
                                    property.SetValue(result, generator.GetType().GetMethod("GenerateItem").Invoke(generator, new object[] { inheritance }));
                                    break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<T> GenerateListItems()
        {
            List<T> result = (List<T>)Activator.CreateInstance(typeof(List<T>));
            for (int i = 0; i < Faker.RandomNumber.Next(0, 100); i++)
            {
                result.Add(GenerateItem());
            }
            return result;
        }
    }
}

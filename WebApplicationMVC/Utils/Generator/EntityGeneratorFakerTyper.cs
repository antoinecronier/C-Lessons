using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Utils.Reflection;

namespace WebApplicationMVC.Utils.Generator
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
                                    case TypeEnumCustom.FIRSTNAME:
                                        property.SetValue(result, Faker.Name.First());
                                        break;
                                    case TypeEnumCustom.LASTNAME:
                                        property.SetValue(result, Faker.Name.Last());
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            String toSwitchOn = "";
                            if (property.PropertyType.Name == TypeEnum.NULLABLE)
                            {
                                toSwitchOn = property.PropertyType.GenericTypeArguments[0].Name;
                            }
                            else
                            {
                                toSwitchOn = property.PropertyType.Name;
                            }
                            switch (toSwitchOn)
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
                                    object list = Activator.CreateInstance(
                                    typeof(List<>).MakeGenericType(property.PropertyType.GetGenericArguments()));
                                    property.SetValue(result, list);
                                    break;
                                case TypeEnum.NULLABLE:
                                    break;
                                default:
                                        object generator = Activator.CreateInstance(typeof(EntityGeneratorFakerTyper<>)
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

using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Genericity
{
    public class Genericitycs
    {
        public Genericitycs()
        {
            this.Method1<ClassA>(new ClassA());
            Console.WriteLine((new ClassA()).ToString());

            this.Method1<ClassA>(new ClassD());
            Console.WriteLine((new ClassD()).ToString());

            ClassB b = new ClassB();
            b.Field1 = 1;
            b.Field2 = "hi";
            this.Method2<ClassB>(b);

            ClassC c = new ClassC();
            c.Field1 = 1;
            c.Field2 = "hi";
            c.Field3 = "you";
            c.Field4 = 2;
            this.Method2<ClassB>(c);

            ClassC c1 = this.Method3<ClassC>(2);

            ClassA a1 = this.Method3<ClassC>(2);

            ClassA a = new ClassA();
            a.Field1 = 10;
            a.Field2 = "plop";
            a.Field3 = "plip";
            ClassE e = this.Method4<ClassE, ClassA, ClassC>(a, c);
            ClassD d = this.Method4<ClassD, ClassA, ClassB>(a, c);
        }

        public void Method1<T>(T param) where T : class
        {
            Console.WriteLine(param.ToString());
        }

        public void Method2<T>(T param) where T : ClassA
        {
            Console.WriteLine(param.Field1 + " " + param.Field2);
        }

        public T Method3<T>(Int32 id) where T : ClassA
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            result.Field1 = id;
            return result;
        }

        public T1 Method4<T1, T2, T3>(T2 class2, T3 class3) where T1 : ClassD where T2 : ClassA where T3 : ClassB
        {
            T1 result = (T1)Activator.CreateInstance(typeof(T1));
            result.Field1 = class2.Field1 + class3.Field1;
            result.Field2 = class2.Field2 + class3.Field2;
            result.Field3 = class2.Field3 + class3.Field3;
            result.Field4 = 2;
            result.Field5 = 6;
            return result;
        }
    }

    public class Genericitycs2<T> where T : ClassA
    {
        public Genericitycs2()
        {
            this.Method1<ClassA>(new ClassA());
            Console.WriteLine((new ClassA()).ToString());

            this.Method1<ClassA>(new ClassD());
            Console.WriteLine((new ClassD()).ToString());

            ClassA b = new ClassA();
            b.Field1 = 1;
            b.Field2 = "hi";
            this.Method2(b as T);

            ClassC c = new ClassC();
            c.Field1 = 1;
            c.Field2 = "hi";
            c.Field3 = "you";
            c.Field4 = 2;
            this.Method2(c as T);

            ClassC c1 = this.Method3(2) as ClassC;

            ClassA a1 = this.Method3(2);

            ClassA a = new ClassA();
            a.Field1 = 10;
            a.Field2 = "plop";
            a.Field3 = "plip";
            ClassE e = this.Method4<ClassE, ClassA, ClassC>(a, c);
            ClassD d = this.Method4<ClassD, ClassA, ClassB>(a, c);
        }

        public void Method1<TClass>(TClass param) where TClass : class
        {
            Console.WriteLine(param.ToString());
        }

        public void Method2(T param)
        {
            Console.WriteLine(param.Field1 + " " + param.Field2);
        }

        public T Method3(Int32 id)
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            result.Field1 = id;
            return result;
        }

        public T1 Method4<T1, T2, T3>(T2 class2, T3 class3) where T1 : ClassD where T2 : ClassA where T3 : ClassB
        {
            T1 result = (T1)Activator.CreateInstance(typeof(T1));
            result.Field1 = class2.Field1 + class3.Field1;
            result.Field2 = class2.Field2 + class3.Field2;
            result.Field3 = class2.Field3 + class3.Field3;
            result.Field4 = 2;
            result.Field5 = 6;
            return result;
        }
    }
}

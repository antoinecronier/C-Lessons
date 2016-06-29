using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class MyClass
    {
        public Double Id { get; set; }
        public DateTime DateTime { get; set; }
        public Boolean Boolean { get; set; }
        public String String { get; set; }
        public Double Double { get; set; }

        public MyClass()
        {
            Random random = new Random();
            this.Id = Faker.Date.PastWithTime().Ticks;
            this.DateTime = Faker.Date.Between(new DateTime(1990, 01, 01), new DateTime());
            this.Boolean = true;
            this.String = Faker.Lorem.Sentence();
            this.Double = random.NextDouble();
        }
    }

    public class MyClass1
    {
        public Int32 Id { get; set; }
        public List<MyClass> MyClasss { get; set; }
        public MyClass MyClass { get; set; }
        public Dictionary<String, Object> Dictionnary { get; set; }

        public MyClass1()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            this.Id = random.Next(random.Next());
            this.MyClasss = new List<MyClass>();
            for (int i = 0; i < random.Next(100); i++)
            {
                this.MyClasss.Add(new MyClass());
            }
            this.MyClass = new MyClass();
            this.Dictionnary = new Dictionary<string, object>();
            for (int i = 0; i < random.Next(10); i++)
            {
                try
                {
                    this.Dictionnary.Add(Faker.Lorem.Word(), new MyClass());
                }
                catch (Exception)
                {
                }
            }
        }
    }

    public class MyClass2
    {
        public int Id { get; set; }
        public MyClass1 MyClass1 { get; set; }

        public MyClass2()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            this.Id = random.Next(random.Next());
            this.MyClass1 = new MyClass1();
        }
    }

    public class MyClass3
    {
        public int Id { get; set; }
        public ObservableCollection<MyClass2> ObservableCollection { get; set; }

        public MyClass3()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            this.Id = random.Next(random.Next());
            this.ObservableCollection = new ObservableCollection<MyClass2>();
            for (int i = 0; i < random.Next(20); i++)
            {
                this.ObservableCollection.Add(new MyClass2());
            }
        }
    }

    public class MyClass4
    {
    }
}

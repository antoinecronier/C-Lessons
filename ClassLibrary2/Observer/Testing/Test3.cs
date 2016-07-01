using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Observer.Testing
{
    public class Test3 : Observable
    {
        private Int32 myVar;

        public Int32 MyProperty
        {
            get
            {
                return myVar;
            }
            set
            {
                myVar = value;
                this.Notify();
            }
        }

        private String myVar1;

        public String MyProperty1
        {
            get
            {
                return myVar1;
            }
            set
            {
                myVar1 = value;
                this.Notify();
            }
        }

        private String myVar2;

        public String MyProperty2
        {
            get
            {
                return myVar2;
            }
            set
            {
                myVar2 = value;
                this.Notify();
            }
        }

        public Test3()
        {
            MyProperty = Faker.Number.RandomNumber();
            MyProperty1 = Faker.Name.FullName();
            MyProperty2 = Faker.Address.Country();
        }


    }
}

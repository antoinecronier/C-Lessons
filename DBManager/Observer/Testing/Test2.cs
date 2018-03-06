using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Observer.Testing
{
    public class Test2 : IInvestor
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private String myVar1;

        public String MyProperty1
        {
            get { return myVar1; }
            set { myVar1 = value; }
        }

        private String myVar2;

        public String MyProperty2
        {
            get { return myVar2; }
            set { myVar2 = value; }
        }

        public Test2()
        {
            MyProperty = Faker.Number.RandomNumber();
            MyProperty1 = Faker.Name.FullName();
            MyProperty2 = Faker.Address.Country();
        }

        public void Update(object toSee)
        {
            DoSomething(toSee);
        }

        private void DoSomething(object toSee)
        {
            Console.WriteLine(toSee.ToString());
        }
    }
}

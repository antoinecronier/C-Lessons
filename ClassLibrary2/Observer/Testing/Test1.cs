using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Observer.Testing
{
    public class Test1 : IInvestor
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

        private List<Test3> myVar3;

        public List<Test3> MyProperty3
        {
            get { return myVar3; }
            set { myVar3 = value; }
        }

        public Test1()
        {

        }

        public void Update(object toSee)
        {
            throw new NotImplementedException();
        }
    }
}

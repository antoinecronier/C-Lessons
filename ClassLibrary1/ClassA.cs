namespace ClassLibrary1
{
    public class ClassA
    {
        private int field1;
        private int field2;
        private int field3;

        public int Field1
        {
            get
            {
                return this.field1;
            }

            set
            {
                this.field1 = value;
            }
        }

        public int Field2
        {
            get
            {
                return this.field2;
            }

            set
            {
                this.field2 = value;
            }
        }

        public int Field3
        {
            get
            {
                return this.field3;
            }

            set
            {
                this.field3 = value;
            }
        }

        public void DoSomething()
        {
            //throw new System.NotImplementedException();
        }

        public void DoSomething(string param1, string param2)
        {
            throw new System.NotImplementedException();
        }
    }
}
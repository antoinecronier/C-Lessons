using ClassLibrary2.EnumManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Table("ClassA")]
    public class ClassA
    {
        private int field1;
        private String field2;
        private String field3;

        [Key]
        [Column("Id")]
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

        [Column("Field2")]
        public String Field2
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

        [Column("Field3")]
        public String Field3
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

        public ClassA()
        {

        }

        public void DoSomething()
        {
        }

        public void DoSomething(string param1, string param2)
        {
        }
    }
}
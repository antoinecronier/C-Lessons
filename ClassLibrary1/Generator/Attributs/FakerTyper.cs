using ClassLibrary2.Entities.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Attributs
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Property)]
    public class FakerTyper : System.Attribute
    {
        private string name;

        public TypeEnumCustom Typer { get; set; }

        public FakerTyper(string name)
        {
            this.name = name;
        }
    }
}

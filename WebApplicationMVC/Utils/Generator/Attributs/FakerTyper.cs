using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationMVC.Utils.Generator.Attributs
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

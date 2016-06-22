#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Sandbox
{
    class Preproc
    {
        public Preproc()
        {
            int a = 1;
            a++;
#if DEBUG
            Console.WriteLine("Debug version create preproc");
#endif
#if DESIGN

#endif
        }
    }
}

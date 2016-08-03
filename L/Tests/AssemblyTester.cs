using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LCore.Tests
    {
    public abstract class AssemblyTester
        {
        protected Type ThisType => this.GetType();

        protected Assembly TestAssembly => Assembly.GetAssembly(this.ThisType);

        }
    }

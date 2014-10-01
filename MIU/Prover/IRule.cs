using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    interface IRule
    {
        string Name { get; }
        IEnumerable<string> EnumerateChildren(string s);
    }
}

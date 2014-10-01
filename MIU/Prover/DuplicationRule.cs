using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    class DuplicationRule : IRule
    {
        int _skip;
        public string Name { get; private set; }

        public DuplicationRule(string name, int skip)
        {
            Name = name;
            _skip = 1;
        }

        public IEnumerable<string> EnumerateChildren(string s)
        {
            var sb = new StringBuilder();

            sb.Append(s.Substring(0, _skip));
            sb.Append(s.Substring(_skip));
            sb.Append(s.Substring(_skip));

            yield return sb.ToString();
        }
    }
}

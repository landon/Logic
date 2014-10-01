using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prover
{
    class ReplacementRule : IRule
    {
        Regex _regex;
        string _replacement;

        public string Name { get; private set; }

        public ReplacementRule(string name, string regex, string replacement)
        {
            Name = name;
            _regex = new Regex(regex, RegexOptions.Compiled);
            _replacement = replacement;
        }

        public IEnumerable<string> EnumerateChildren(string s)
        {
            var sb = new StringBuilder();
            foreach (Match match in _regex.Matches(s))
            {
                sb.Clear();
                sb.Append(s, 0, match.Index);
                sb.Append(_replacement);
                sb.Append(s, match.Index + match.Length, s.Length - (match.Index + match.Length));

                yield return sb.ToString();
            }
        }
    }
}

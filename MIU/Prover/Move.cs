using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    class Move
    {
        public string RuleName { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }

        public Move(string ruleName, string from, string to)
        {
            RuleName = ruleName;
            From = from;
            To = to;
        }
    }
}

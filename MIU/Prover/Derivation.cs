using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    class Derivation
    {
        public List<Move> Moves { get; private set; }

        public Move FinalMove
        {
            get { return Moves[Moves.Count - 1]; }
        }

        public Derivation()
        {
            Moves = new List<Move>();
        }

        public Derivation Extend(Move move)
        {
            var extended = new Derivation();
            extended.Moves = Moves.ToList();
            extended.Moves.Add(move);

            return extended;
        }

        public override string ToString()
        {
            var maxWidth = 5 + Moves.Max(m => m.To.Length);
            
            var sb = new StringBuilder();
            sb.AppendLine("1. Show " + FinalMove.To);

            int i = 2;
            foreach (var move in Moves)
            {
                sb.AppendFormat("{0}. ", i);
                sb.Append(move.To);
                for (int j = 0; j < maxWidth - move.To.Length - i.ToString().Length; j++)
                    sb.Append(" ");
                
                sb.AppendLine(move.RuleName);

                i++;
            }

            return sb.ToString();
        }
    }
}

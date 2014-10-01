using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    class Prover
    {
        HashSet<string> _seenPositions = new HashSet<string>();
        List<IRule> _rules;
        string _axiom;

        public Prover(string axiom, params IRule[] rules)
        {
            _axiom = axiom;
            _rules = rules.ToList();
        }

        public Derivation Prove(string formula)
        {
            var derivations = new Queue<Derivation>();
            derivations.Enqueue(new Derivation().Extend(new Move("Premise", _axiom, _axiom)));

            while (derivations.Count > 0)
            {
                var derivation = derivations.Dequeue();
                foreach (var move in EnumerateMoves(derivation.FinalMove.To))
                {
                    if (move.To == formula)
                        return derivation.Extend(move);

                    derivations.Enqueue(derivation.Extend(move));
                    _seenPositions.Add(move.To);
                }
            }

            return null;
        }

        IEnumerable<Move> EnumerateMoves(string formula)
        {
            foreach (var rule in _rules)
            {
                foreach (var child in rule.EnumerateChildren(formula))
                {
                    if (!_seenPositions.Contains(child))
                        yield return new Move(rule.Name, formula, child);
                }
            }
        }
    }
}

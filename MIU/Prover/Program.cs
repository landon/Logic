using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    class Program
    {

// xI → xIU
// Mx → Mxx
// xIIIy → xUy
// xUUy → xy

        static void Main(string[] args)
        {
            var IIItoU = new ReplacementRule("IIItoU", "III", "U");
            var UUto = new ReplacementRule("UUto", "UU", "");
            var EndItoIU = new ReplacementRule("EndItoIU", "I$", "IU");
            var Double = new DuplicationRule("Double", 1);

            var prover = new Prover("MI", IIItoU, UUto, EndItoIU, Double);

            var derivation = prover.Prove("MUUII");

            var v = derivation.ToString();
        }
    }
}

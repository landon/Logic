using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prover
{
    class Program
    {
        static void Main(string[] args)
        {
            var IIItoU = new ReplacementRule("IIItoU", "III", "U");
            var UUto = new ReplacementRule("UUto", "UU", "");
            var EndItoIU = new ReplacementRule("EndItoIU", "I$", "IU");
            var Double = new DuplicationRule("Double", 1);

            var prover = new Prover("MI", IIItoU, UUto, EndItoIU, Double);
            var derivation = prover.Prove("MIIIIIIIIIIU");

            var v = derivation.ToString();

            Console.Write(v);
            Console.ReadKey();
        }
    }
}

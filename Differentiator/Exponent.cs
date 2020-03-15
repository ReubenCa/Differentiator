using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Exponent : Node
    {
        public Exponent(string Equation) : base(Equation)
        {

        }

        public override char GetSymbol()
        {
            return '^';
        }

        public override string CalculateVal()
        {
            int inttotal = Convert.ToInt32(Vals[Vals.Count-1]);
            //f() ^ g() ^ B
            //needs to chain rule right to left
            //Needs special rules when creating Children
            for (int i = Vals.Count()-2; i>=0; i--)
            {
                inttotal = (int)Math.Pow( Convert.ToInt32(Vals[i]), inttotal);

            }
            return inttotal.ToString();
        }
    }
}

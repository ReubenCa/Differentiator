using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Subtract : Node
    {
        public Subtract(string Equation) : base(Equation)
        {

        }

        public override char GetSymbol()
        {
            return '-';
        }

        public override string CalculateVal()
        {
            string SubTotalStrings = "";
            int SubTotalInts = 0;

            if (Isint(Vals[0]))
            {
                SubTotalInts =Convert.ToInt32( Vals[0]);
            }
            else
            {
                SubTotalStrings = Vals[0];
            }
            for(int i = 1;i<Vals.Count;i++)
            {
                if (Isint(Vals[i]))
                {
                    SubTotalInts -= Convert.ToInt32(Vals[i]);
                }
                else
                {
                    SubTotalStrings += "-" + Vals[i];
                }
            }
            if(SubTotalInts != 0)
            {
                return (SubTotalInts + SubTotalStrings);
            }
            else
            {
                return SubTotalStrings;
            }
        }
    }
}


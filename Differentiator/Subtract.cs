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

            if (Isint(Sections[0]))
            {
                SubTotalInts =Convert.ToInt32( Sections[0]);
            }
            else
            {
                SubTotalStrings = Sections[0];
            }
            for(int i = 1;i<Sections.Length;i++)
            {
                if (Isint(Sections[i]))
                {
                    SubTotalInts -= Convert.ToInt32(Sections[i]);
                }
                else
                {
                    SubTotalStrings += "-" + Sections[i];
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


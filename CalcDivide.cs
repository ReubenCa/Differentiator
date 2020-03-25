using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class CalcDivide : CalcNode
    {
        new char Symbol = '*';
        public CalcDivide(string Equation) : base(Equation)
        {
        }
        public override char GetSymbol()
        {
            return '/';
        }

        public override string CalculateVal()
        {
            string DivTotalStrings = "";
            int DivTotalInts = 0;

            if (Isint(Sections[0]))
            {
                DivTotalInts = Convert.ToInt32(Sections[0]);
            }
            else
            {
                DivTotalStrings = Sections[0];
            }
            for (int i = 1; i < Sections.Count; i++)
            {
                if (Isint(Sections[i]))
                {
                    DivTotalInts /= Convert.ToInt32(Sections[i]);
                }
                else
                {
                    DivTotalStrings += "/" + Sections[i];
                }
            }
            if (DivTotalInts != 0)
            {
                return (DivTotalInts + DivTotalStrings);
            }
            else
            {
                return DivTotalStrings;
            }
        }

    }
}

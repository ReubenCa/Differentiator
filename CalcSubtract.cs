using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class CalcSubtract : CalcNode
    {
        public CalcSubtract(string Equation) : base(Equation)
        {

        }

        public override char GetSymbol()
        {
            return '-';
        }

        public override string CalculateVal()
        {

            CreateTermObjects();
            

            


            string SubTotalStrings = "";
            int SubTotalInts = 0;
            bool intfirst = true;
            if (Isint(Vals[0]))
            {
                SubTotalInts = Convert.ToInt32(Vals[0]);
            }
            else
            {
                SubTotalStrings = Vals[0];
                intfirst = false;
            }
            for (int i = 1; i < Vals.Count; i++)
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
            string strSubTotalInts = SubTotalInts.ToString();
            if (SubTotalInts > 0)
            {
                 strSubTotalInts = "+" + SubTotalInts;
            }
            
            
                
            

            if (SubTotalInts != 0)
            {
                if (intfirst)
                {
                    return (strSubTotalInts + SubTotalStrings);
                }
                else
                {

                    return (SubTotalStrings + strSubTotalInts);
                }
            }
            else
            {
                return SubTotalStrings;
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class CalcMultiply : CalcNode
    {
       
        public CalcMultiply(string Equation) : base(Equation)
        {
        }
            public override char GetSymbol()
        {
            return '*';
        }

        public override string CalculateVal()
        {
            SeperateIntoLists();
            int Totalints = 1;
            string Totalstrings = "";
            for (int i = 0; i < Ints.Count(); i++)
            {
                Totalints *= Convert.ToInt32(Ints[i]);
            }
            if (Totalints != 1)
            {
                Totalstrings += Totalints;

            }
            for (int i = 0; i < NonInts.Count(); i++)
            {
                Totalstrings +="*"+ NonInts[i];
            }
            return Totalstrings;
        }

    }
    
}

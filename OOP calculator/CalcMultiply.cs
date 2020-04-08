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
            CreateTermObjects();
           CalcTerm TotalTerms = MultiplyTerms();
            int Totalints = 1;
            string Totalstrings = "";
            for (int i = 0; i < Ints.Count(); i++)
            {
                Totalints *= Convert.ToInt32(Ints[i]);
            }


            Totalints *= TotalTerms.GetBase();

            if(Totalints==0)
            {
                return "0";
            }
            if(TotalTerms.GetExponent()!=0 && TotalTerms.GetExponent() != 1)
            {
                Totalstrings += Totalints.ToString() + "*x^" + TotalTerms.GetExponent();
            }
            if (TotalTerms.GetExponent() ==1)
            {
                Totalstrings += Totalints.ToString() + "*x";
            }
            if (TotalTerms.GetExponent() == 0)
            {
                Totalstrings += Totalints.ToString();
            }












            for (int i = 0; i < NonInts.Count(); i++)
            {
                Totalstrings += "*" + NonInts[i];
            }









            if (Totalstrings[Totalstrings.Length - 1] == '*')
            {
                Totalstrings = Totalstrings.Substring(0, Totalstrings.Length - 1);
            }
            if (Totalstrings[0] == '*')
            {
                Totalstrings = Totalstrings.Substring(1, Totalstrings.Length - 1);
            }


            return Totalstrings;
        }


       private CalcTerm MultiplyTerms()

        {
            if(Terms.Count==0)
            {
                return new CalcTerm(1,0);
            }


            int totalexponent = 0;
            int totalbase = 1;
            int i;
            for(i=0;i<Terms.Count;i++)
            {
                totalexponent += Terms[i].GetExponent();
                totalbase *= Terms[i].GetBase();
            }

            return new CalcTerm(totalbase, totalexponent);
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Add : CalcNode
    {
      
      public  Add (string Equation) : base (Equation)
        {
           
        }

     public override char GetSymbol()
        {
            return '+' ;
        }

        public  override string CalculateVal()
        {
            SeperateIntoLists();
            int Totalints = 0 ;
            string Totalstrings = "";
            for (int i = 0; i < Ints.Count(); i++)
            {
                Totalints += Convert.ToInt32(Ints[i]);
            }
            if (Totalints != 0 || NonInts.Count==0)
            {
                Totalstrings += Totalints;
               
            }

            CreateTermObjects();
            SumTerms();

            for (int i = 0; i <  NonInts.Count(); i++)
            {
                Totalstrings += "+" + NonInts[i];
                
                
                
            }
            if(Totalstrings[0] == '+')
            {
                Totalstrings = Totalstrings.Substring(1, Totalstrings.Length - 1);
            }

            if(Totalstrings[Totalstrings.Length - 1] == '+')
            {
                Totalstrings = Totalstrings.Substring(0, Totalstrings.Length - 1);
            }
            return Totalstrings;
        }

        private void SumTerms()
        {
            if (Terms.Count == 0)
            {
                return;
            }

            int HighestExp = GetHighestExp();
            int[] Bases = new int[HighestExp + 1];

            for (int n = 0; n < Bases.Length; n++)
            {
                Bases[n] = 0;
            }



            for (int ExpBeingGrouped = 0; ExpBeingGrouped <= HighestExp; ExpBeingGrouped++)
            {
                for (int j = 0; j < Terms.Count(); j++)
                {
                    if (Terms[j].GetExponent() == ExpBeingGrouped)
                    {
                        Bases[ExpBeingGrouped] += Terms[j].GetBase();
                    }




                }
            }

            for (int m = 0; m < Bases.Length; m++)
            {
                if (Bases[m] != 0)
                {
                    NonInts.Add(Bases[m].ToString() + "*x^" + m);
                }
            }
        }
    }
}

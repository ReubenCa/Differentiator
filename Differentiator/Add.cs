using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Add : Node
    {
      
      public  Add (string Equation) : base (Equation)
        {
           
        }

     public override char GetSymbol()
        {
            return '+' ;
        }

        public  override string GetTotalVal()
        {
            int Totalints = 0 ;
            string Totalstrings = "";
            for (int i = 0; i < Ints.Count(); i++)
            {
                Totalints += Convert.ToInt32(Ints[i]);
            }
            if (Totalints != 0)
            {
                Totalstrings += Totalints;
               
            }
            for (int i = 0; i <  NonInts.Count(); i++)
            {
                Totalstrings += "+" + NonInts[i];
            }
            return Totalstrings;
        }
    }
}

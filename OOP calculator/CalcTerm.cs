using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{

   
    class CalcTerm
    {
         int Base;
         int Exponent;
        
       public CalcTerm(int Base_, int Exponent_)
        {
            Base = Base_;
                Exponent = Exponent_;
            Console.WriteLine("Created new term with Base {0} and Exponent {1}", Base, Exponent);
        }

        public int GetBase()
        {
            return Base;
        }

        public int GetExponent()
        {
            return Exponent;
        }

    }
}

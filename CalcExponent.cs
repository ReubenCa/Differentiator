using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class CalcExponent : CalcNode
    {
        public CalcExponent(string Equation) : base(Equation)
        {

        }

        public override char GetSymbol()
        {
            return '^';
        }

        public override string CalculateVal()
        {
            List<string> strpowers = new List<string>();
            int i = Vals.Count-1;
            int currentIndex = 0;
            strpowers.Add( "1");
           string returnstring = "";
            while ((i >= 0))
            {
                if (Isint(Vals[i]))
                {
                    strpowers[currentIndex] = Math.Pow(Convert.ToInt32(Vals[i]), Convert.ToInt32(strpowers[currentIndex])).ToString();
                }
                else if (Vals[i] == "x")   //Cant just asume that this is x ; could be (x+2)
                {
                    strpowers.Add("x");
                    strpowers.Add("1");
                    currentIndex += 2;
                }
                else
                {
                    Vals[i] = new CalcEquation(Vals[i]).Getvalue();
                    if(Isint(Vals[i]))
                     {
                        strpowers[currentIndex] = Math.Pow(Convert.ToInt32(Vals[i]), Convert.ToInt32(strpowers[currentIndex])).ToString();
                    }
                    else
                    {
                        strpowers.Add("(" + Vals[i] + ")");
                        strpowers.Add("1");
                        currentIndex += 2;
                    }
                    
                }



                i--;
               
            }
            //Must return strpowers in reverse order also ignore ones
            for (int g = strpowers.Count() - 1; g >= 0; g--)
            {
                if (strpowers[g] != "1")
                {
                    returnstring += strpowers[g];
                    
                        returnstring += "^";
                    
                }
            }
            if(returnstring[returnstring.Length-1]=='^')
            {
                returnstring = returnstring.Substring(0, returnstring.Length - 1);
            }
            return returnstring;

        }
    }
}

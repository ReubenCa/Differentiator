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

        private void SubtractTerms(bool FirstOneIsAdded)
        {

            if(Terms.Count==0)
            {
                return;
            }



            int HighestExp = GetHighestExp();
            int[] Bases = new int[HighestExp + 1];

            for (int n = 0; n < Bases.Length; n++)
            {
                Bases[n] = 0;
            }
            CalcTerm AddedTerm = null;
            if (FirstOneIsAdded)
            {
                AddedTerm = Terms[0];
                Terms.RemoveAt(0);
            }

            for (int ExpBeingGrouped = 0; ExpBeingGrouped <= HighestExp; ExpBeingGrouped++)
            {
                for (int j = 0; j < Terms.Count(); j++)
                {
                    if (Terms[j].GetExponent() == ExpBeingGrouped)
                    {
                        Bases[ExpBeingGrouped] -= Terms[j].GetBase();
                    }




                }
            }

            if (FirstOneIsAdded)
            {
                Bases[AddedTerm.GetExponent()] += AddedTerm.GetBase();
            }

            for (int m = 0; m < Bases.Length; m++)
            {
                if (Bases[m] != 0)
                {
                    NonInts.Add(Bases[m].ToString() + "*x^" + m);
                }
            }

        }

        public override string CalculateVal()
        {
            string Initialval = Vals[0];
            bool Addedvalisint =true;
            SeperateIntoLists();
            CreateTermObjects();
            int subtotalints = 0;
            if (!Isint(Initialval))
            {
                if (testifterm(Initialval))
                {//Needs redoing

                    SubtractTerms(true);
                    Addedvalisint = true;
                }

            }
            else {
                subtotalints = Convert.ToInt32(Initialval) * 2; 
                    }

           
                SubtractTerms(false);
            




           
            



            for(int i=0;i<Ints.Count;i++)//NEEDS TO KNOW IF ADDED TERM IS INT OR NOT
            {
                subtotalints -= Convert.ToInt32(Ints[i]);
            }



            string strFinalTotal = "";
            if(subtotalints!=0)
            {
                strFinalTotal += subtotalints;
            }
            for(int i=0;i<NonInts.Count;i++)
            {
                strFinalTotal += "-" + NonInts[i];
            }
           /* if (strFinalTotal != "" && strFinalTotal[0] == '-')
            {
                strFinalTotal = strFinalTotal.Substring(1, strFinalTotal.Length - 1);
            }*/
            return strFinalTotal == "" ? "0" : strFinalTotal;



        }
        private bool testifterm(string Stringtoterm)
        {
            string strBase ="0";
            bool inBase = true;
            string strExponent="0";
            for (int i = 0; i < Stringtoterm.Length; i++)
            {
                if (Isint(Stringtoterm[i].ToString()) && inBase)
                {
                    strBase += Stringtoterm[i];
                }
                else if (Isint(Stringtoterm[i].ToString()) && !inBase)
                {
                    strExponent += Stringtoterm[i];
                }
                else if (i + 2 < Stringtoterm.Length ? Stringtoterm[i] == '*' && Stringtoterm[i + 1] == 'x' && Stringtoterm[i + 2] == '^' : false)
                {
                    i = i + 2;
                    inBase = false;



                }
                else if (i + 1 < Stringtoterm.Length ? Stringtoterm[i] == 'x' && Stringtoterm[i + 1] == '^' && i == 0 : false)
                {
                    i++;
                    inBase = false;
                    strBase = "1";
                }
                else if (Stringtoterm[i] == 'x' && i == Stringtoterm.Length - 1)
                {
                    strExponent = "1";
                    strBase = strBase == "0" ? "1" : strBase;

                }
                else
                {
                    return false;
                }

            }
            return true;
        }
    }
}
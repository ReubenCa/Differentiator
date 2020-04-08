using System;
using System.Collections.Generic;
using System.Linq;

namespace Differentiator
{
    class CalcNode
    {
      char Symbol;
      protected  List<string> Sections = new List<string>();
        Object[] Children;
      protected  List<string> Ints = new List<string>();
       protected List<string> NonInts = new List<string>();
        protected List<string> Vals = new List<string>();
        protected List<CalcTerm> Terms = new List<CalcTerm>();

        string Equation;
        public CalcNode(string Equation_)
        {
            Equation = Equation_;
            Symbol = this.GetSymbol();

            Console.WriteLine("Creating Node with contents: " + Equation);

            SplitRespectingBrackets();



            // Sections = Equation.Split(Symbol);
            Children = new object[Sections.Count];
            for (int i = 0; i < Sections.Count; i++)
            {
                Children[i] = new CalcEquation(Sections[i]);
            }
        }
        public  string GetValue()
        {
            for (int i = 0; i < Children.Length; i++)
            {
                Object obj = Children[i];
                CalcEquation eq = (CalcEquation)obj;
                string eqval = eq.Getvalue();
                Vals.Add(eqval);
            }
            return CalculateVal();
        }

        public virtual string CalculateVal()
        {
            Console.WriteLine("Error calling function CalculateVal");
            return "Error";
        }


        public void SeperateIntoLists()
        {
            

            for (int i = 0; i <Vals.Count(); i++)
            {
                string CurrentValueBeingSorted = Vals[i];
                if (Isint(CurrentValueBeingSorted))
                {
                    Ints.Add(CurrentValueBeingSorted);
                }
                else
                {
                    NonInts.Add(CurrentValueBeingSorted);
                }
            }
            
        }


        protected bool Isint(string a)
        {
            int x;
            return int.TryParse(a, out x);
           
        }
        public virtual char GetSymbol()
        {
            return '@';
        }


      protected void CreateTermObjects()
        {
            int i;
            int NICount = NonInts.Count();
            for(i=0;i<NICount;i++)
            {
                if (i<NonInts.Count) //needed if every non int is a term
                {
                    if (TryMakeTerm(NonInts[i]))//Maybe replace this with something a bit better -is a bit hacky
                    {
                        NonInts.RemoveAt(i);
                        i--; //compensates for there being one less term in nonInts.
                    }
                }
            }
           
        }

        protected int GetHighestExp()
        {
            int x = Terms[0].GetExponent();
            for (int i = 1; i< Terms.Count;i++)
            {
                if (Terms[i].GetExponent() > x)
                {
                    x = i;
                }
            }
            return x;
        }

        protected bool TryMakeTerm(string Stringtoterm)
        {
            for(int i=0;i<Stringtoterm.Length;i++)
            {
                if ((Isint(Stringtoterm[i].ToString()) ||
                    Stringtoterm[i] == 'x' ||
                    Stringtoterm[i] == '^' ||
                    Stringtoterm[i] == '*' ) == false)
                {
                    return false;
                }
                
            }

            
            
                string strExponent="0";
                string strBase ="0";
            bool inBase = true;

            for (int i = 0; i < Stringtoterm.Length; i++)
            {
                if (Isint(Stringtoterm[i].ToString())&&inBase)
                    {
                    strBase += Stringtoterm[i];
                }
                else if(Isint(Stringtoterm[i].ToString()) && !inBase)
                {
                    strExponent += Stringtoterm[i];
                }
                else if(i+2<Stringtoterm.Length ?    Stringtoterm[i]=='*' && Stringtoterm[i+1]=='x' && Stringtoterm[i + 2] == '^': false)
                {
                    i = i + 2;
                    inBase = false;



                }
                else if (i + 1 < Stringtoterm.Length ? Stringtoterm[i ] == 'x' && Stringtoterm[i + 1] == '^' && i==0: false)
                {
                    i++;
                    inBase = false;
                    strBase = "1";
                }
                else if(Stringtoterm[i] == 'x'&&i==Stringtoterm.Length-1)
                {
                    strExponent = "1";
                    strBase = strBase == "0" ? "1" : strBase;

                }
                else
                {
                    return false;
                }
                
            }


            Terms.Add( new CalcTerm(Convert.ToInt32(strBase), Convert.ToInt32(strExponent)));
            



            return true;
        }



       protected void SplitRespectingBrackets()
        {
          string  tempEquation = Equation + Symbol;
int bracketcount = 0;
            int currentindexstart = 0;
            for (int i = 0; i< tempEquation.Length;i++)
            {
                if(tempEquation[i]=='(')
                {
                    bracketcount++;
                }
               else if (tempEquation[i] == ')')
                {
                    bracketcount--;
                }
               else if(tempEquation[i] == Symbol&& bracketcount ==0)
                {
                    Sections.Add(tempEquation.Substring(currentindexstart, i - currentindexstart ));
                    currentindexstart = i+1;
                }
            }
           
        }
    }

    
}

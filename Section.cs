using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Section
    {
        string equation;
        Node Child;
        public Section(string equation_)
        {
            Console.WriteLine("Created Section with contents {0}", equation_);
            equation = Trim(equation_);

            if (CheckIfCanSplitToSections())
            {
                Child = new SectionSplitterNode(equation);
            }
            else
            {
                CheckIfJustTerms();
                DetermineRuleNeeded();
            }
        }

        private string Trim(string TrimmedEquation)
        {
            bool bracketsremoved = false;
            do
            {
                bracketsremoved = false;

                if (TrimmedEquation[0] == '(' && TrimmedEquation[TrimmedEquation.Length - 1] == ')')
                {
                    TrimmedEquation = TrimmedEquation.Substring(1, TrimmedEquation.Length - 2);
                    bracketsremoved = true;
                    Console.WriteLine("trimmed section to {0}", TrimmedEquation);

                }

            } while (bracketsremoved);
            return TrimmedEquation;
        }



        private void DetermineRuleNeeded()
        {
            int bracketcount = 0;
            for (int i = 0; i < equation.Length; i++)

            {
                if (equation[i] == '(')
                {
                    bracketcount++;
                }
                else if (equation[i] == ')')
                {
                    bracketcount--;
                }
                if (bracketcount == 0)
                {
                    switch (equation[i])
                    {
                        case '*':
                            Child = new ProductRule(equation);
                            return;
                        case '/':
                            Child = new QuotientRule(equation);
                            return;
                        case '^':
                            Child = new ExponentRule(equation);
                            return;
                        case 'S':
                            Child = new ChainRule(equation, 'S');
                            return;
                        case 'C':
                            Child = new ChainRule(equation, 'C');
                            return;
                        case 'L':
                            Child = new ChainRule(equation, 'L');
                            return;
                        case 'T':
                            Child = new ChainRule(equation, 'T');
                            return;


                    }
                }
            }

        }

        private bool CheckIfCanSplitToSections()
        {
            int bracketcount = 0;
            for (int i = 0; i < equation.Length - 1; i++)
            {
                switch (equation[i])
                {
                    case '(':
                        bracketcount++;
                        break;
                    case ')':
                        bracketcount--;
                        break;
                    case '+':
                        if (bracketcount == 0)
                        {
                            return true;
                        }
                        break;
                    case '-':
                        if (bracketcount == 0)
                        {
                            return true;
                        }
                        break;
                }
            }


            return false;
        }

        private void CheckIfJustTerms()
        {
            bool InExponent;


        }

        
        public string Differentiate()
        {
            if (Child != null)
            {
               return Child.Differentiate();
            }
            else
            {
                return equation;
            }
        }
    }
}

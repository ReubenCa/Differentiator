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
            equation = equation_;
            bool bracketsremoved = false;
            do
            {
                bracketsremoved = false;
                
                if (equation[0] == '(' && equation[equation.Length - 1] == ')')
                {
                    equation = equation.Substring(1, equation.Length - 2);
                    bracketsremoved = true;
                    Console.WriteLine("trimmed section to {0}", equation);
                    
                }

            } while (bracketsremoved);

            if (CheckIfCanSplitToSections())
            {
                Child = new SectionSplitterNode(equation);
            }
            else
            {
                DetermineRuleNeeded();
            }
        }


        private void DetermineRuleNeeded()
        {
        }

       private bool CheckIfCanSplitToSections()
        {
            int bracketcount = 0;
            for(int i = 0;i<equation.Length-1;i++)
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

    }
}

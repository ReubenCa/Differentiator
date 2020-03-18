using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Node
    {
       protected Section ChildOne;
       protected Section ChildTwo;
        protected string strChildOne;
            protected string strChildTwo;
        protected string equation;
       public Node(string equation_)
        {
            equation = equation_;
            ConsoleMessage(equation);
        }

        protected virtual void ConsoleMessage(string eq)
        {
            Console.WriteLine("Created Node with contents {0}", eq);
        }
        public virtual string Differentiate()
        {
            return "Node with contents " +  equation  + " did not contain a definition of how to differentiate";
        }

      protected int FindFirstCharacterIndex(char Character)
        {
            //ignores things in brackets
            int bracketcount = 0;
           
            for (int i=0; i<equation.Length;i++)
            {
                if (equation[i] == '(')
                {
                    bracketcount++;
                }
                else if (equation[i] == ')')
                {
                    bracketcount--;
                }
                if (equation[i]==Character && bracketcount==0)
                {
                    return i;
                }
            }
            return -1;
        }

        protected void SeperateAndCreateChildren()
        {
            int seperatorindex = FindFirstCharacterIndex(GetChar());

            strChildOne = equation.Substring(0, seperatorindex);
            strChildTwo = equation.Substring(seperatorindex + 1, equation.Length - seperatorindex - 1);


        ChildOne = new Section(strChildOne);
            ChildTwo = new Section(strChildTwo);
        }

        protected virtual char GetChar()
        {
            return '@';
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Differentiator
{
    class Equation
    {
        char[] SymbolsInOrder = new char[] { '+','-','/', '*', '^' };
        string Contents;
        string[] Sections;
        Node ChildNode;
        bool HasChildren;
        string value;
        public Equation(string Contents_)
        { 
            Contents = Contents_;
            Console.WriteLine("Creating Equation with contents: " + Contents);
            int x;
            if (int.TryParse(Contents, out x))
            {
                HasChildren = false;
                value = Contents;
                return;
            }
            HasChildren = true;


            if (Contents.Length != 1)
            {
                char Symbol = GetSymbolToUse();
                CreateChild(Symbol, Contents);
            }
            else
            {
                value = Contents;
                HasChildren = false;
                return;
            }


        }


        char GetSymbolToUse()
        {
            
                for (int i = 0; i < SymbolsInOrder.Length; i++)
                {
                    if (FindSymbol(SymbolsInOrder[i]))
                    {
                        return SymbolsInOrder[i];
                    }
                }
                
            
            Console.WriteLine("Error Finding Symbol To use");
            return '@';

        }

        private bool FindSymbol(char Symbol)
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                if (Contents[i] == Symbol)
                {
                    return true;
                }
            }
            return false;
        }
        void CreateChild(char Symbol, string ChildContents)
        {
            switch (Symbol)
            {
                case '+':
                    ChildNode = new Add(ChildContents);
                    break;
                case '*':
                    ChildNode = new Multiply(ChildContents);
                    break;
                case '/':
                    ChildNode = new Divide(ChildContents);
                    break;
                case '-':
                    ChildNode = new Subtract(ChildContents);
                    break;
                case '^':
                    ChildNode = new Exponent(ChildContents);
                    break;



            }
        }

        public string Getvalue()
        {

            if (!HasChildren)
            {
                Console.WriteLine("Equation with Contents of {0} is returning {1}",  Contents, value.ToString());
                return value.ToString();
            }
            else
            {
                string ChildVal = ChildNode.GetValue();
                Console.WriteLine("Equation with Contents of {0} is returning {1}",  Contents, ChildVal);
                return ChildVal;
            }
        }
       
    }
}

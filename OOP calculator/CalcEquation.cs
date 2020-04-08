using System;


namespace Differentiator
{
    class CalcEquation
    {
        char[] SymbolsInOrder = new char[] { '+', '-', '*', '/', '^' };
        string Contents;
        string[] Sections;
        CalcNode ChildNode;
        bool HasChildren;
        string value;
        public CalcEquation(string Contents_)
        {
            bool exitnow = false;
            Contents = Contents_;
            if (Contents=="")
            {
                Console.WriteLine("Blank equation assuming contents of 0");
                Contents = "0";
            }
            while (Contents[0] == '(' && Contents[Contents.Length - 1] == ')' && !exitnow)
            {

                int bracketcount = 0;
                for (int i = 0; i < Contents.Length - 1; i++)
                {
                    if (Contents[i] == '(')
                    {
                        bracketcount++;
                    }
                    else if (Contents[i] == ')')
                    {
                        bracketcount--;
                    }
                    if (bracketcount == 0)
                    {
                        exitnow = true;
                    }

                }
                if (!exitnow)
                {
                    Contents = Contents.Substring(1, Contents.Length - 2);
                    Console.WriteLine("Trimmed {0} to {1}", Contents_, Contents);
                }

            }

            AddZerosBeforeMinus();

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
            int bracketcount = 0;

            for (int i = 0; i < Contents.Length; i++)
            {
                if (Contents[i] == '(')
                {
                    bracketcount++;
                }
                else if (Contents[i] == ')')
                {
                    bracketcount--;
                }





                if (Contents[i] == Symbol && bracketcount == 0)
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
                    ChildNode = new CalcMultiply(ChildContents);
                    break;
                case '/':
                    ChildNode = new CalcDivide(ChildContents);
                    break;
                case '-':
                    ChildNode = new CalcSubtract(ChildContents);
                    break;
                case '^':
                    ChildNode = new CalcExponent(ChildContents);
                    break;



            }
        }

        public string Getvalue()
        {

            if (!HasChildren)
            {

                Console.WriteLine("Equation with Contents of {0} is returning {1}", Contents, value.ToString());
                return value.ToString();
            }
            else
            {
                string ChildVal = ChildNode.GetValue();
                Console.WriteLine("Equation with Contents of {0} is returning {1}", Contents, ChildVal);
                return ChildVal;
            }
        }


        private void AddZerosBeforeMinus()
        {
           
            int i;
            for (i = 0; i < Contents.Length; i++)
            {
                int bracketcount = 0;
                if (Contents[i] == '(')
                {
                    bracketcount++;
                }
                else if (Contents[i] == ')')
                {
                    bracketcount--;
                }
                if (Contents[i] == '-'&&bracketcount==0)
                {
                    if (i == 0 || (!Isint(Contents[i - 1].ToString()) && Contents[i - 1]!='x') && Contents[i - 1] != ')')
                    {
                      Contents=  insertsymbol(Contents, '0', i);
                        i++;
                    }
                }
            }
        }


        protected bool Isint(string a)
        {
            int x;
            return int.TryParse(a, out x);

        }

        private string insertsymbol(string text, char sym, int indexofsym)
        {
            return text.Substring(0, indexofsym) + sym + text.Substring(indexofsym, text.Length - indexofsym);
        }
    }
}

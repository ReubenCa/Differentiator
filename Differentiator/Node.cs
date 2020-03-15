using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Node
    {
      char Symbol;
      protected  string[] Sections;
        Object[] Children;
      protected  List<string> Ints = new List<string>();
       protected List<string> NonInts = new List<string>();
        protected List<string> Vals = new List<string>();

        public Node(string Equation)
        {

            Symbol = this.GetSymbol();

            Console.WriteLine("Creating Node with contents: " + Equation);
            Sections = Equation.Split(Symbol);
            Children = new object[Sections.Length];
            for (int i = 0; i < Sections.Length; i++)
            {
                Children[i] = new Equation(Sections[i]);
            }
        }
        public  string GetValue()
        {
            for (int i = 0; i < Children.Length; i++)
            {
                Object obj = Children[i];
                Equation eq = (Equation)obj;
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

    }
}

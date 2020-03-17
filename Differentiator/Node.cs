using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Node
    {
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

    }
}

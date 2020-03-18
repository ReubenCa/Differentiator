using System;

namespace Differentiator
{
    class ProductRule: Node
    {
        
        public ProductRule(string equation_) : base(equation_)
        {
            SeperateAndCreateChildren();
        }
        protected override char GetChar()
        {
            return '*';
        }
        protected override void ConsoleMessage(string eq)
        {
            Console.WriteLine("Created Product Rule Node with contents {0}", eq);
        }

        public override string Differentiate()
        {
            return ("(" + ChildOne.Differentiate() + ")(" + strChildTwo + ")+("  +strChildOne + ")(" + ChildTwo.Differentiate() + ")");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class ChainRule : Node
    {
       char seperator;
        public ChainRule(string equation_, char seperator_) : base(equation_)
        {
            seperator = seperator_;
            SeperateAndCreateChildren();
        }

        protected override char GetChar()
        {
            return seperator;
        }

    }
}

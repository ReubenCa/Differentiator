using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class QuotientRule : Node
    {
        public QuotientRule(string equation_) : base(equation_)
        {
            SeperateAndCreateChildren();
        }
                
            
        protected override char GetChar()
        {
            return '/';
        }
    }
    }


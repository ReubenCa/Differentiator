using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class SectionSplitterNode : Node
    {

        //makes a list of positive and negative sections within the section (seperated by + and -) anything inside brackets is ignored

        
        List<string> strPositiveSections = new List<string>();
        List<string> strNegativeSections = new List<string>();
        List<Section> objPositiveSections = new List<Section>();
        List<Section> objNegativeSections = new List<Section>();
        public SectionSplitterNode(string equation_) : base (equation_)
        {
            
            FillLists();
            CreateChildren();
        }

        protected override void ConsoleMessage(string eq)
        {
            Console.WriteLine("Created SectionSplitter Node with contents {0}", eq);
        }

        private void CreateChildren()
        {
            for (int i = 0; i < strPositiveSections.Count(); i++)
            {
                objPositiveSections.Add(new Section(strPositiveSections[i]));
              
            }
            for (int i = 0; i < strNegativeSections.Count(); i++)
            {
                objNegativeSections.Add(new Section(strNegativeSections[i]));
            }
        }

        private void FillLists()
        {
           string tempequation = equation + "+";//temp equation just sticks a plus on the end so last term gets counted
            bool SectionIsPos = true;
            int i;
            int bracketcount = 0;
            int secstart = 0;
            for ( i=0; i<tempequation.Length;i++)
            {
                if(tempequation[i] == '(')
                {
                    bracketcount++;
                }
                else if (tempequation[i] == ')')
                {
                    bracketcount--;
                }

                else if ((tempequation[i] == '+' || tempequation[i] == '-') && bracketcount ==0)
                {
                    if (i != 0)
                    {
                        if (SectionIsPos)
                        {
                            strPositiveSections.Add(tempequation.Substring(secstart, i - secstart));
                        }
                        else
                        {
                            strNegativeSections.Add(tempequation.Substring(secstart, i - secstart));
                        }
                    }
                    secstart = i + 1;

                    if (tempequation[i] == '-')
                    {
                        SectionIsPos = false;


                    }
                    if (tempequation[i] == '+')
                    {
                        SectionIsPos = true;


                    }
                }
               

            }
        }
    }
}

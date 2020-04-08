using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class CalcDivide : CalcNode
    {
        new char Symbol = '*';
        public CalcDivide(string Equation) : base(Equation)
        {
        }
        public override char GetSymbol()
        {
            return '/';
        }

        public override string CalculateVal()
        {
            List<string> FinalAnswer = new List<string>();
            //needs to go trhough list and call Divide all ints whenver it finds a bunch of ints in a row
            int IntsinARow = 0;
            for (int i=0; i<Sections.Count;i++)
            {
               if(Isint(Sections[i]))
                {
                    IntsinARow++;
                }

                if (!Isint(Sections[i]))
                {
                    FinalAnswer.Add(DivideListOfInts(Sections.GetRange(i - IntsinARow, IntsinARow)));
                    IntsinARow = 0;
                    FinalAnswer.Add(Sections[i]);
                }
                else if(i==Sections.Count-1)
                {
                    i++;
                    FinalAnswer.Add(DivideListOfInts(Sections.GetRange(i - IntsinARow, IntsinARow)));
                    IntsinARow = 0;
                }
                

            }


            return "";
           
        }


        private string DivideListOfInts(List<string> List)
        {
            int Top = Convert.ToInt32(List[0]);
            int Bottom = 1;
            for(int i = 1; i<List.Count;i++)
            {
                Bottom *= Convert.ToInt32(List[i]);
            }

            return "Error Unfinished division script";


        }

      
    }
}

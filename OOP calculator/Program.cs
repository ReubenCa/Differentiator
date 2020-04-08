using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Differentiator
{
    class Program
    {
       static void Main(string[] args)
        {
   


            while (true)
            {
                //fix 3*x-x
                Console.WriteLine("Enter Sum");
                string Sum = Console.ReadLine();
                // string FormattedSum = Format(Sum);


                CalcEquation Fred = new CalcEquation(Sum);
                Console.WriteLine(Fred.Getvalue());
                
            }
        }
     
    }
}

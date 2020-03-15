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

                Console.WriteLine("Enter Sum");
                string Sum = Console.ReadLine();
                // string FormattedSum = Format(Sum);


                Equation Fred = new Equation(Sum);
                Console.WriteLine(Fred.Getvalue());
                
            }
        }
      //static private string Format(string Sum)
      //  {
      //      for (int i =0; i< Sum.Length; i++)
      //      {
      //          if(Sum[i] == '-')
      //          {
      //             Sum= Sum.Insert(i+1, "+");
      //              //i = 0;
      //          }
      //      }



      //      Console.WriteLine("Formatted input into: " + Sum);
      //      return Sum;
      //  }
    }
}

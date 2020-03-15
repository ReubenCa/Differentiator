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
          


            Console.WriteLine("Enter Sum");
            string sum = Console.ReadLine();
            Equation Fred = new Equation(sum);
            Console.WriteLine(Fred.Getvalue());
            Console.ReadLine();
        }
    }
}

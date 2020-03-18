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
                string sum = Console.ReadLine();
              Section Fred = new Section(sum);
                Console.WriteLine(Fred.Differentiate());

            }



            //literally express everything in terms of functions - just have your multiply blocks return product rule etc
            // break down into rules if you can -- express trig as function of a function 
            //eventually functions will be as broken down as possible then you just need to know how to differentiate basic terms as well as trig and e^x
            //Have terms convereted to own object 'Term' to make adding/expanding brackets much easier much easier -- terms are everything from '5' to 6x^8

            //section will check if it can be split into smaller sections then create a node that splits it and spawns the smaller sections
            //node does calculation - section does formatting and decides what node is needed
        }

    }
}

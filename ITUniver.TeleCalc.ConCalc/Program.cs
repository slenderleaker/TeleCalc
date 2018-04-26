using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITUniver.TeleCalc.Core;

namespace ITUniver.TeleCalc.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var acc = new Calc();
            string opName = "";
            double x;
            double y;
            if (args.Length == 3)
            {
                opName = args[0].ToLower();
                x = double.Parse(args[1]);
                y = double.Parse(args[2]);
            }
            else
            {
                Console.WriteLine("Pick operation...");
                
                foreach (var item in acc.getOperNames())
                {
                    Console.WriteLine(item);
                }

            opName = Console.ReadLine().ToLower();
            Console.WriteLine("Write params");
            var data = Console.ReadLine().Split(' ');
            x = double.Parse(data[0]);
            y = double.Parse(data[1]);
            }

            double? con = acc.Exec(opName, x, y);
            Console.WriteLine(string.Format("{0}{1}{2} = {3}", x, opName, y, con));
            Console.ReadKey();

        }
    }
}

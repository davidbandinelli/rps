using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrt {
    class sqrt {
        static void Main(string[] args) {
            FizzBuzz();

            double input = 17;
            double output = 0;
            double EPSILON = 0.001;
            for (double k = 0.001; k <= input; k += 0.001) {
                if (((input - (k * k)) <= EPSILON)) {
                    output = k;
                    break;
                }
            }
            System.Console.WriteLine("Sqrt={0}", output);
            System.Console.ReadKey();
        }

        static void FizzBuzz() {
            for (int k = 1; k <= 100; k++) {
                if (k % 3 == 0 && k % 5 == 0) 
                    System.Console.WriteLine("{0} FizzBuzz", k);
                else if (k % 3 == 0) 
                    System.Console.WriteLine("{0} Fizz", k);
                else if (k % 5 == 0) 
                    System.Console.WriteLine("{0} Buzz", k);
                else // non divisibile per 3 o 5
                    System.Console.WriteLine("{0}", k);
            }
            System.Console.ReadKey();
        }
    }

    /*
     "Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz”."

    */


}

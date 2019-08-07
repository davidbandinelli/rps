using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrt {
    class sqrt {
        static void Main(string[] args) {
            double input = 10;
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
    }
}

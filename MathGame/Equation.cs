using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    
    public class Equation
    {
        char[] operators = { '+', '-', '*', '/' };
        public int a { get; set; }
        public int b { get; set; }
        public char op { get; set; }
        public int res { get; set; }

        public Equation() {
            Random r = new Random();

            while (true) {
                a = r.Next(20) + 1;
                b = r.Next(20) + 1;
                op = operators[r.Next(4)];

                if (op == '+') {
                    res = a + b;
                    break;
                }

                if (op == '*') {
                    res = a * b;
                    break;
                }

                if (op == '-') {
                    if (b > a)
                    {
                        int tmp = b;
                        b = a;
                        a = tmp;
                    }
                    res = a - b;
                    break;
                }

                if (op == '/') {
                    while (a % b != 0) {
                        a = r.Next(20) + 1;
                        b = r.Next(20) + 1;
                    }
                    res = a / b;
                    break;
                }
            }
        }
    }
}

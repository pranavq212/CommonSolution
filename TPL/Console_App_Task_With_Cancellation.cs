using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    public static class Console_App_Task_With_Cancellation
    {
        public static int Fibonacci(int n, CancellationToken token)
        {
            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Getting out of the Fibonacci Sequence ....");

                    return a;
                }

                int temp = a;
                a = b;
                b = temp + b;

                Console.WriteLine($"Current result {a}");
            }

            return a;
        }
    }
}

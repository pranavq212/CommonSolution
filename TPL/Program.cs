using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TPL.Console_App_Task_With_Cancellation;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            CancellationToken token = cancellationTokenSource.Token;

            Task<int> myFibonnaciTask = null;

            myFibonnaciTask = new Task<int>(() => { return Fibonacci(5000, token); }, token);

            myFibonnaciTask.Start();

            do
            {
                while (!Console.KeyAvailable)
                {
                    if (myFibonnaciTask.IsCompleted)
                    {
                        goto End;
                    }
                }

                input = Console.ReadKey(true);

                if (!myFibonnaciTask.IsCompleted & !cancellationTokenSource.IsCancellationRequested)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Cancelled");
                }

            } while (input.Key != ConsoleKey.Escape);

        End:
            Console.WriteLine($"Result {myFibonnaciTask.Result}");
            Console.WriteLine("Program has ended!");
            Console.ReadKey();

        }
    }
}

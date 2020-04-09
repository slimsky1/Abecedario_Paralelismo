using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Abecedario_Paralelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() => {
                Console.WriteLine("Tarea1");

                for (var i = 'A'; i <= 'Z'; i++)
                {
                    if ((int)i % 2 != 0) { Console.WriteLine("{0} : id hilo {1}", (char)i, Thread.CurrentThread.ManagedThreadId); }
                }
            });

            Task t2 = Task.Factory.StartNew(() => {
                t1.Wait();
                Console.WriteLine();
                Console.WriteLine("Tarea2");
                for (var i = 'A'; i <= 'Z'; i++)
                {
                    if ((int)i % 2 == 0) { Console.WriteLine("{0} : id hilo {1}", (char)i, Thread.CurrentThread.ManagedThreadId); }
                }
            });

            t2.Wait();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpConsoleClockObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var ticker = new Ticker();

            using (var clock1 = new SecondClock(0, 1, ConsoleColor.Yellow, ticker))
            using (var clock2 = new TenthSecondClock(0, 2, ConsoleColor.Green, ticker))
            using (var clock3 = new HundredthSecondClock(0, 3, ConsoleColor.Red, ticker))
            {
                Thread thread = new Thread(ticker.Run);
                thread.Start();

                Console.ReadLine();

                ticker.Done = true;
                thread.Join();
            }
        }

        /*
         * The event statement makes sure that the class that owns the delegate is the only one that can use it, but other classes can still "know about it" this is to avoid anything overwriting something important
         * 
         * The using statement makes sure that our cleanup "dispose" function is called automatically, this is to avoid any memory leaks or dangling pointers
         */
    }
}

using System;

namespace _03.AsynchronousTimer
{
    class Test
    {
        static void Main(string[] args)
        {
            AsyncTimer printLetter = new AsyncTimer(PrintLetterOnConsole, 5, 500);
            printLetter.Execute();
            
            AsyncTimer printNumber = new AsyncTimer(PrintNumberOnConsole, 3, 1000);
            printNumber.Execute();    
        }

        private static void PrintLetterOnConsole(int i)
        {
            char letter = (char) ('a' + i);
            Console.WriteLine(letter);
        }

        private static void PrintNumberOnConsole(int i)
        {
            Console.WriteLine(i + 1);
        }
    }
}

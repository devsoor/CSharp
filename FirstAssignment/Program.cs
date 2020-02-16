using System;

namespace FirstAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Print1to255();
            // Print1to100();
            FizzBuzz();
        }

        static void Print1to255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine("Value: " + i);
            }
        }

        static void Print1to100()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("Divisible by 3: " + i);
                } else if (i % 5 == 0)
                {
                    Console.WriteLine("Divisible by 5: " + i);
                }
            }
        }

        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                } else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if (i%3==0 && i%5==0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
        }
    }
}

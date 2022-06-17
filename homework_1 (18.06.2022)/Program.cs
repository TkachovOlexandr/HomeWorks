using System;

namespace homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise #1
            Console.Write("Write a number from 1 to 100: ");
            short num = short.Parse(Console.ReadLine());
            if (num > 0 && num < 101)
            {
                if (num % 3 == 0 && num % 5 == 0)
                    Console.WriteLine("Fizz Buzz");
                else if (num % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (num % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(num);
            }
            else
                Console.WriteLine("Your number doesn't match the specified range");
        }
    }
}
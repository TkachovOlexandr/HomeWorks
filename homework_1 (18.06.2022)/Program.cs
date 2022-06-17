using System;

namespace homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise #1
            //Console.Write("Write a number from 1 to 100: ");
            //short num = short.Parse(Console.ReadLine());
            //if (num > 0 && num < 101)
            //{
            //    if (num % 3 == 0 && num % 5 == 0)
            //        Console.WriteLine("Fizz Buzz");
            //    else if (num % 3 == 0)
            //        Console.WriteLine("Fizz");
            //    else if (num % 5 == 0)
            //        Console.WriteLine("Buzz");
            //    else
            //        Console.WriteLine(num);
            //}
            //else
            //    Console.WriteLine("Your number doesn't match the specified range");

            //Exercise #2
            //Console.Write("Write a number: ");
            //short num = short.Parse(Console.ReadLine());
            //Console.Write("Write the percentage of the number entered above: ");
            //short percent = short.Parse(Console.ReadLine());
            //Console.WriteLine($"{percent}% of {num} is equal to {(float)percent * num / 100}");

            //Exercise #3
            //short[] digits = new short[4];
            //for (short i = 1; i < 5; i++)
            //{
            //    Console.Write("Write the " + i);
            //    if (i == 1)
            //        Console.Write("-st");
            //    else if (i == 2)
            //        Console.Write("-nd");
            //    else if (i == 3)
            //        Console.Write("-rd");
            //    else
            //        Console.Write("-th");
            //    Console.Write(" digit of the number: ");
            //    digits[i - 1] = short.Parse(Console.ReadLine());
            //}
            //int answer = 0;
            //for (short i = 0; i < digits.Length; i++)
            //    answer += digits[digits.Length - i - 1] * (int)Math.Pow(10, i);
            //Console.WriteLine("Your number: " + answer);

            //Exercise #4
            //Console.Write("Write a six-digit number: ");
            //int num = int.Parse(Console.ReadLine());
            //Console.Write("Write the digit number: ");
            //short digit_1 = short.Parse(Console.ReadLine());
            //Console.Write("Write the digit number: ");
            //short digit_2 = short.Parse(Console.ReadLine());
            //int answer = 0;
            //if ((num / 100000) > 0 && (num / 100000) < 10)
            //{
            //    if (digit_1 < 1 || digit_1 > 6)
            //        Console.WriteLine("Your first digit number doesn't match the number");
            //    else if (digit_2 < 1 || digit_2 > 6)
            //        Console.WriteLine("Your second digit number doesn't match the number");
            //    else
            //    {
            //        int first_digit = num / (int)Math.Pow(10, 6 - digit_1) - num / (int)Math.Pow(10, 7 - digit_1) * 10;
            //        int second_digit = num / (int)Math.Pow(10, 6 - digit_2) - num / (int)Math.Pow(10, 7 - digit_2) * 10;
            //        answer = num + (second_digit - first_digit) * (int)(Math.Pow(10, 6 - digit_1) - Math.Pow(10, 6 - digit_2));
            //        Console.WriteLine("Your number: " + answer);
            //    }
            //}
            //else
            //    Console.WriteLine("Your number isn't six digits");

            //Exercise #5                                                   !!!!!not finished yet!!!!!
            Console.Write("Write the date: ");
            string person_date = Console.ReadLine();
            short person_day = 0;
            short person_month = 0;
            short person_year = 0;
            short[] dot_place = {0, 0, 0};
            for (short i = 0; i < person_date.Length; i++)
            {
                if (person_date[i] == '.')
                {
                    for (short j = 0; j < dot_place.Length; j++)
                    {
                        if (dot_place[j] == 0)
                        {
                            dot_place[j] = 1;
                            break;
                        }
                    }
                }
                else if (dot_place[0] == 0)
                    person_day = Convert.ToInt16(person_day * 10 + Convert.ToInt16(person_date[i]));
                else if (dot_place[1] == 0)
                    person_month = Convert.ToInt16(person_month * 10 + Convert.ToInt16(person_date[i]));
                else if (dot_place[2] == 0)
                    person_year = Convert.ToInt16(person_year * 10 + Convert.ToInt16(person_date[i]));
            }
            Console.WriteLine(person_day + '.' + person_month + '.' + person_year);
            if (person_month < 3 || person_month > 11)
                Console.Write("Winter ");
            else if (person_month > 2 && person_month < 6)
                Console.Write("Spring ");
            else if (person_month > 5 && person_month < 9)
                Console.Write("Summer ");
            else if (person_month > 8 && person_month < 12)
                Console.Write("Autumn ");
            short comparative_day = 24;
            short comparative_month = 2;
            short comparative_year = 2022;
            short[] day_in_month = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            short max_month, min_month, day_sum = 0;
            if (person_month > comparative_month)
            {
                max_month = person_month;
                min_month = comparative_month;
            }
            else
            {
                max_month = comparative_month;
                min_month = person_month;
            }
            for (short i = 0; i < max_month; i++)
            {
                if (i + 1 > min_month)
                    day_sum += day_in_month[i];
            }
            if (person_month > comparative_month)
                day_sum *= -1;
            long delta = Convert.ToInt64(365.2425 * (comparative_year - person_year) + day_sum + (comparative_day - person_day));
            short week_day = Convert.ToInt16(delta % 7);
            string[] week_days = {"Thursday", "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday"};
            Console.WriteLine(delta + ' ' + week_day + ' ' + week_days[week_day]);

            //Exercise #6
            //Console.Write("Write the temperature: ");
            //int t = int.Parse(Console.ReadLine());
            //Console.Write("If the temperature was written in degrees Celsius - write \"C\", if in degrees Fahrenheit - write \"F\": ");
            //char scale = char.Parse(Console.ReadLine());
            //if (scale == 'C')
            //{
            //    Console.WriteLine($"Degrees Celsius: {t}°C");
            //    Console.WriteLine($"Degrees Fahrenheit: {(float)t * 9 / 5 + 32}°F");
            //}
            //else if (scale == 'F')
            //{
            //    Console.WriteLine($"Degrees Celsius: {((float)t - 32) * 5 / 9}°C");
            //    Console.WriteLine($"Degrees Fahrenheit: {t}°F");
            //}
            //else
            //    Console.WriteLine("You wrote the wrong character");

            //Exercise #7
            //Console.Write("Write first number: ");
            //int num_1 = int.Parse(Console.ReadLine());
            //Console.Write("Write second number: ");
            //int num_2 = int.Parse(Console.ReadLine());
            //if (num_1 > num_2)
            //{
            //    int temp = num_1;
            //    num_1 = num_2;
            //    num_2 = temp;
            //}
            //for (int i = num_1; i <= num_2; i++)
            //    if (i % 2 == 0) Console.Write(i + ", ");
            //Console.Write("\b\b");
        }
    }
}
//Exercise #1
//Random random = new Random();
//int min_random = 1;
//int max_random = 100;
//short A_size = 5;
//short[] A = new short[A_size];
//short B_size_r = 3;
//short B_size_c = 4;
//float[,] B = new float[B_size_r, B_size_c];
//for (short i = 1; i <= A_size; i++)
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
//    Console.Write(" number of array: ");
//    A[i - 1] = short.Parse(Console.ReadLine());
//}
//for (int i = 0; i < B_size_r; i++)
//{
//    for (int j = 0; j < B_size_c; j++)
//        B[i, j] = (float)random.Next(min_random, max_random) / 10;
//}
//short A_max = 0, A_min = 0, A_sum = 0, A_even_elem_sum = 0, A_product = 1;
//float B_max = 0, B_min = 0, B_sum = 0, B_odd_elem_sum = 0, B_product = 1;
//for (int i = 0; i < A_size; i++)
//{
//    Console.Write($"{A[i]}\t");
//    if (i == 0)
//        A_max = A[i];
//    else
//    {
//        if (A_max > A[i])
//            A_max *= 1;
//        else
//            A_max = A[i];
//    }
//    if (i == 0)
//        A_min = A[i];
//    else
//    {
//        if (A_min < A[i])
//            A_min *= 1;
//        else
//            A_min = A[i];
//    }
//    A_sum += A[i];
//    A_product *= A[i];
//    if (i % 2 == 1)
//        A_even_elem_sum += A[i];
//}
//Console.WriteLine();
//for (int i = 0; i < B_size_r; i++)
//{
//    for (int j = 0; j < B_size_c; j++)
//    {
//        Console.Write($"{B[i, j]}\t");
//        if (i == 0 && j == 0)
//            B_max = B[i, j];
//        else
//        {
//            if (B_max > B[i, j])
//                B_max *= 1;
//            else
//                B_max = B[i, j];
//        }
//        if (i == 0 && j == 0)
//            B_min = B[i, j];
//        else
//        {
//            if (B_min < B[i, j])
//                B_min *= 1;
//            else
//                B_min = B[i, j];
//        }
//        B_sum += B[i, j];
//        B_product *= B[i, j];
//        if (j % 2 == 0)
//            B_odd_elem_sum += B[i, j];
//    }
//    Console.WriteLine();
//}
//Console.Write($"Joint max element: ");
//if (A_max > B_max)
//    Console.WriteLine(A_max);
//else
//    Console.WriteLine(B_max);
//Console.Write($"Joint min element: ");
//if (A_min < B_min)
//    Console.WriteLine(A_min);
//else
//    Console.WriteLine(B_min);
//Console.WriteLine($"Sum of all elements: {A_sum + B_sum}");
//Console.WriteLine($"Product of all elements: {A_product * B_product}");
//Console.WriteLine($"Sum of even elements from array A: {A_even_elem_sum}");
//Console.WriteLine($"Sum of odd elements from array B: {B_odd_elem_sum}");

//Exercise #2
//Random random = new Random();
//int min_random = -100;
//int max_random = 100;
//short size_r = 5;
//short size_c = 5;
//short[,] arr = new short[size_r, size_c];
//for (int i = 0; i < size_r; i++)
//{
//    for (int j = 0; j < size_c; j++)
//        arr[i, j] = (short)random.Next(min_random, max_random);
//}
//short min_value = 0, max_value = 0;
//for (short i = 0; i < size_r; i++)
//{
//    for (short j = 0; j < size_c; j++)
//    {
//        if (i == 0 && j == 0)
//            max_value = arr[i, j];
//        else if (max_value < arr[i, j])
//            max_value = arr[i, j];
//        if (i == 0 && j == 0)
//            min_value = arr[i, j];
//        else if (min_value > arr[i, j])
//            min_value = arr[i, j];
//        Console.Write($"{arr[i, j]}\t");
//    }
//    Console.WriteLine();
//}
//short[] left_board = new short[2];
//short[] right_board = new short[2];
//for (short i = 0; i < size_r; i++)
//{
//    for (short j = 0; j < size_c; j++)
//    {
//        if (arr[i, j] == max_value || arr[i, j] == min_value)
//        {
//            right_board[0] = i;
//            right_board[1] = j;
//        }
//    }
//}
//for (short i = (short)(size_r - 1); i >= 0; i--)
//{
//    for (short j = (short)(size_c - 1); j >= 0; j--)
//    {
//        if (arr[i, j] == max_value || arr[i, j] == min_value)
//        {
//            left_board[0] = i;
//            left_board[1] = j;
//        }
//    }
//}
//short sum = 0;
//for (short i = left_board[0]; i <= right_board[0]; i++)
//{
//    for (short j = left_board[1]; j <= right_board[1]; j++)
//        sum += arr[i, j];
//}
//Console.Write("Sum of elements between ");
//if (arr[left_board[0], left_board[1]] == min_value)
//    Console.Write("min");
//else
//    Console.Write("max");
//Console.Write($" {arr[left_board[0], left_board[1]]} and ");
//if (arr[right_board[0], right_board[1]] == min_value)
//    Console.Write("min");
//else
//    Console.Write("max");
//Console.WriteLine($" {arr[right_board[0], right_board[1]]}: {sum}");

//Exercise #3
//Console.Write("Write your string: ");
//string person_str = Console.ReadLine();
//Console.Write("Write the number of movements: ");
//short num = short.Parse(Console.ReadLine());
//char[] char_arr = person_str.ToCharArray();
//for (short i = 0; i < person_str.Length; i++)
//    char_arr[i] = (char)(Convert.ToInt16(person_str[i]) + num);
//string answer_str = new string(char_arr);
//Console.WriteLine($"Your encrypted string: {answer_str}");

//Exercise #4
//Console.Write("Write how many rows you want in your matrix: ");
//short size_r = short.Parse(Console.ReadLine());
//Console.Write("Write how many columns you want in your matrix: ");
//short size_c = short.Parse(Console.ReadLine());
//Console.WriteLine("In this case, your matrix looks like this");
//for (short i = 0; i <= size_r; i++)
//{
//    for (short j = 0; j < size_c; j++)
//    {
//        if (i == 0)
//            Console.Write(" _______________");
//        else if (i != size_r)
//            Console.Write($"|\tnum_{(i - 1) * size_c + j + 1}\t");
//        else
//        {
//            string temp_str = $"|_______num_{(i - 1) * size_c + j + 1}";
//            while (temp_str.Length != 16)
//                temp_str = temp_str.Insert(temp_str.Length, "_");
//            Console.Write(temp_str);
//        }
//    }
//    if (i == 0)
//        Console.WriteLine();
//    else
//        Console.WriteLine("|");
//}
//short[,] numbers_arr = new short[size_r, size_c];
//for (short i = 0; i < size_r; i++)
//{
//    for (short j = 0; j < size_c; j++)
//    {
//        Console.Write($"Write the value of num_{i * size_c + j + 1}: ");
//        numbers_arr[i, j] = short.Parse(Console.ReadLine());
//    }
//}
//for (short i = -1; i < size_r; i++)
//{
//    for (short j = 0; j < size_c; j++)
//    {
//        if (i == -1)
//            Console.Write(" _______________");
//        else if (i != size_r - 1)
//            Console.Write($"|\t{numbers_arr[i, j]}\t");
//        else
//        {
//            string temp_str = $"|_______{numbers_arr[i, j]}";
//            while (temp_str.Length != 16)
//                temp_str = temp_str.Insert(temp_str.Length, "_");
//            Console.Write(temp_str);
//        }
//    }
//    if (i == -1)
//        Console.WriteLine();
//    else
//        Console.WriteLine("|");
//}
//while (true)
//{
//    Console.WriteLine("If you want to multiply the matrix by a number - write '1'");
//    Console.WriteLine("If you want to add matrices - write '2'");
//    Console.WriteLine("If you want to multiply matrices - write '3'");
//    Console.WriteLine("If you want to finish the program - write '0'");
//    char choice = char.Parse(Console.ReadLine());
//    if (choice == '1')
//    {
//        Console.Write("Write the number to multiply: ");
//        short num = short.Parse(Console.ReadLine());
//        for (short i = 0; i < size_r; i++)
//        {
//            for (short j = 0; j < size_c; j++)
//                numbers_arr[i, j] *= num;
//        }
//        for (short i = -1; i < size_r; i++)
//        {
//            for (short j = 0; j < size_c; j++)
//            {
//                if (i == -1)
//                    Console.Write(" _______________");
//                else if (i != size_r - 1)
//                    Console.Write($"|\t{numbers_arr[i, j]}\t");
//                else
//                {
//                    string temp_str = $"|_______{numbers_arr[i, j]}";
//                    while (temp_str.Length != 16)
//                        temp_str = temp_str.Insert(temp_str.Length, "_");
//                    Console.Write(temp_str);
//                }
//            }
//            if (i == -1)
//                Console.WriteLine();
//            else
//                Console.WriteLine("|");
//        }
//    }
//    else if (choice == '2' || choice == '3')
//    {
//        Console.WriteLine("The matrix with which you want to perform a mathematical operation on your matrix looks like this");
//        for (short i = 0; i <= size_r; i++)
//        {
//            for (short j = 0; j < size_c; j++)
//            {
//                if (i == 0)
//                    Console.Write(" _______________");
//                else if (i != size_r)
//                    Console.Write($"|\tnum_{(i - 1) * size_c + j + 1}\t");
//                else
//                {
//                    string temp_str = $"|_______num_{(i - 1) * size_c + j + 1}";
//                    while (temp_str.Length != 16)
//                        temp_str = temp_str.Insert(temp_str.Length, "_");
//                    Console.Write(temp_str);
//                }
//            }
//            if (i == 0)
//                Console.WriteLine();
//            else
//                Console.WriteLine("|");
//        }
//        short[,] addition_numbers_arr = new short[size_r, size_c];
//        for (short i = 0; i < size_r; i++)
//        {
//            for (short j = 0; j < size_c; j++)
//            {
//                Console.Write($"Write the value of num_{i * size_c + j + 1}: ");
//                addition_numbers_arr[i, j] = short.Parse(Console.ReadLine());
//            }
//        }
//        Console.WriteLine("Your newly created matrix:");
//        for (short i = -1; i < size_r; i++)
//        {
//            for (short j = 0; j < size_c; j++)
//            {
//                if (i == -1)
//                    Console.Write(" _______________");
//                else if (i != size_r - 1)
//                    Console.Write($"|\t{addition_numbers_arr[i, j]}\t");
//                else
//                {
//                    string temp_str = $"|_______{addition_numbers_arr[i, j]}";
//                    while (temp_str.Length != 16)
//                        temp_str = temp_str.Insert(temp_str.Length, "_");
//                    Console.Write(temp_str);
//                }
//            }
//            if (i == -1)
//                Console.WriteLine();
//            else
//                Console.WriteLine("|");
//        }
//        if (choice == '2')
//        {
//            for (short i = 0; i < size_r; i++)
//            {
//                for (short j = 0; j < size_c; j++)
//                    numbers_arr[i, j] += addition_numbers_arr[i, j];
//            }
//            Console.WriteLine("The result of their addition:");
//        }
//        else if (choice == '3')
//        {
//            for (short i = 0; i < size_r; i++)
//            {
//                for (short j = 0; j < size_c; j++)
//                    numbers_arr[i, j] *= addition_numbers_arr[i, j];
//            }
//            Console.WriteLine("The result of their multiply:");
//        }
//        for (short i = -1; i < size_r; i++)
//        {
//            for (short j = 0; j < size_c; j++)
//            {
//                if (i == -1)
//                    Console.Write(" _______________");
//                else if (i != size_r - 1)
//                    Console.Write($"|\t{numbers_arr[i, j]}\t");
//                else
//                {
//                    string temp_str = $"|_______{numbers_arr[i, j]}";
//                    while (temp_str.Length != 16)
//                        temp_str = temp_str.Insert(temp_str.Length, "_");
//                    Console.Write(temp_str);
//                }
//            }
//            if (i == -1)
//                Console.WriteLine();
//            else
//                Console.WriteLine("|");
//        }
//    }
//    else if (choice == '0')
//        break;
//    else
//        Console.WriteLine("You wrote an incorrect character. Try again.");
//}

//Exercise #5
//Console.WriteLine("Write an arithmetic expression in a string (put a space between the numbers and sighs of mathematical operations): ");
//string ar_expression = Console.ReadLine();
//ar_expression = ar_expression.Insert(ar_expression.Length, " ");
//short num_1 = 0;
//short num_2 = 0;
//char math_operation = '+';
//for (short i = 0; i < ar_expression.Length; i++)
//{
//    if (Convert.ToInt16(ar_expression[i]) > 47 && Convert.ToInt16(ar_expression[i]) < 59)
//    {
//        if (num_1 == 0)
//        {
//            short temp = 0;
//            while (Convert.ToInt16(ar_expression[i]) > 47 && Convert.ToInt16(ar_expression[i]) < 59)
//            {
//                num_1 = (short)(num_1 * Math.Pow(10, temp) + short.Parse(ar_expression[i].ToString()));
//                i++;
//                temp++;
//            }
//        }
//        else
//        {
//            short temp = 0;
//            while (Convert.ToInt16(ar_expression[i]) > 47 && Convert.ToInt16(ar_expression[i]) < 59)
//            {
//                num_2 = (short)(num_2 * Math.Pow(10, temp) + short.Parse(ar_expression[i].ToString()));
//                i++;
//                temp++;
//            }
//        }
//    }
//    else if (Convert.ToInt16(ar_expression[i]) == 43)
//        math_operation = '+';
//    else if (Convert.ToInt16(ar_expression[i]) == 45)
//        math_operation = '-';
//    if (math_operation == '+')
//        num_1 += num_2;
//    else if (math_operation == '-')
//        num_1 -= num_2;
//    num_2 = 0;
//}
//Console.WriteLine($"Answer: {num_1}");

//Exercise #6
//Console.Write("Write your line: ");
//string person_str = Console.ReadLine();
//for (short i = 0; i < person_str.Length; i++)
//{
//    if (person_str[i] == '.')
//    {
//        while (true)
//        {
//            i++;
//            if (i != person_str.Length)
//            {
//                if (person_str[i] != ' ' && !Char.IsUpper(person_str[i]))
//                {
//                    char[] char_arr = person_str.ToCharArray();
//                    char_arr[i] = Convert.ToChar(Convert.ToInt16(person_str[i]) - 32);
//                    person_str = new string(char_arr);
//                    break;
//                }
//            }
//            else
//                break;
//        }
//    }
//    else if (i == 0 && !Char.IsUpper(person_str[i]))
//    {
//        char[] char_arr = person_str.ToCharArray();
//        char_arr[i] = Convert.ToChar(Convert.ToInt16(person_str[i]) - 32);
//        person_str = new string(char_arr);
//    }
//}
//Console.WriteLine($"Your corrected string: {person_str}");

//Exercise #7
Console.Write("Write your string: ");
string person_str = Console.ReadLine();
Console.Write("Write the forbidden word: ");
string forbidden_word = Console.ReadLine();
string censored_word = new string('*', forbidden_word.Length);
person_str = person_str.Replace(forbidden_word, censored_word);
Console.Write($"Your censored string: {person_str}");
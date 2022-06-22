//Exercise #1
Random random = new Random();
int min_random = 1;
int max_random = 100;
short A_size = 5;
short[] A = new short[A_size];
short B_size_r = 3;
short B_size_c = 4;
float[,] B = new float[B_size_r, B_size_c];
for (short i = 1; i <= A_size; i++)
{
    Console.Write("Write the " + i);
    if (i == 1)
        Console.Write("-st");
    else if (i == 2)
        Console.Write("-nd");
    else if (i == 3)
        Console.Write("-rd");
    else
        Console.Write("-th");
    Console.Write(" number of array: ");
    A[i - 1] = short.Parse(Console.ReadLine());
}
for (int i = 0; i < B_size_r; i++)
{
    for (int j = 0; j < B_size_c; j++)
        B[i, j] = (float)random.Next(min_random, max_random) / 10;
}
short A_max = 0, A_min = 0, A_sum = 0, A_even_elem_sum = 0, A_product = 1;
float B_max = 0, B_min = 0, B_sum = 0, B_odd_elem_sum = 0, B_product = 1;
for (int i = 0; i < A_size; i++)
{
    Console.Write($"{A[i]}\t");
    if (i == 0)
        A_max = A[i];
    else
    {
        if (A_max > A[i])
            A_max *= 1;
        else
            A_max = A[i];
    }
    if (i == 0)
        A_min = A[i];
    else
    {
        if (A_min < A[i])
            A_min *= 1;
        else
            A_min = A[i];
    }
    A_sum += A[i];
    A_product *= A[i];
    if (i % 2 == 1)
        A_even_elem_sum += A[i];
}
Console.WriteLine();
for (int i = 0; i < B_size_r; i++)
{
    for (int j = 0; j < B_size_c; j++)
    {
        Console.Write($"{B[i, j]}\t");
        if (i == 0 && j == 0)
            B_max = B[i, j];
        else
        {
            if (B_max > B[i, j])
                B_max *= 1;
            else
                B_max = B[i, j];
        }
        if (i == 0 && j == 0)
            B_min = B[i, j];
        else
        {
            if (B_min < B[i, j])
                B_min *= 1;
            else
                B_min = B[i, j];
        }
        B_sum += B[i, j];
        B_product *= B[i, j];
        if (j % 2 == 0)
            B_odd_elem_sum += B[i, j];
    }
    Console.WriteLine();
}
Console.Write($"Joint max element: ");
if (A_max > B_max)
    Console.WriteLine(A_max);
else
    Console.WriteLine(B_max);
Console.Write($"Joint min element: ");
if (A_min < B_min)
    Console.WriteLine(A_min);
else
    Console.WriteLine(B_min);
Console.WriteLine($"Sum of all elements: {A_sum + B_sum}");
Console.WriteLine($"Product of all elements: {A_product * B_product}");
Console.WriteLine($"Sum of even elements from array A: {A_even_elem_sum}");
Console.WriteLine($"Sum of odd elements from array B: {B_odd_elem_sum}");
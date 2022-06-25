//Exercise #1
//using Figure;

//Square square_1 = new Square();
//square_1.Draw();

//Square square_2 = new Square('@', 10);
//square_2.Draw();

//Console.WriteLine();

//Square square_3 = new Square(square_2);
//square_3.Draw();

//Exercise #2
//using Number;

//Palindrome palindrome_1 = new Palindrome();
//Console.WriteLine(palindrome_1.CompleteAnswer());

//Palindrome palindrome_2 = new Palindrome(123);
//Console.WriteLine(palindrome_2.CompleteAnswer());

//Palindrome palindrome_3 = new Palindrome(palindrome_2);
//Console.WriteLine(palindrome_3.CompleteAnswer());

//Palindrome palindrome_4 = new Palindrome(24542);
//Console.WriteLine(palindrome_4.CompleteAnswer());

//Exercise #3
using ArrayOperation;

Filtration filtration_1 = new Filtration();
Console.WriteLine(filtration_1.ShowMainArray());
Console.WriteLine(filtration_1.ShowFiltrationArray());

Console.WriteLine();

short[] main_array = {10, 12, -1, 3};
short[] filtration_array = {3, 7};
Filtration filtration_2 = new Filtration(main_array, filtration_array);
Console.WriteLine(filtration_2.ShowMainArray());
Console.WriteLine(filtration_2.ShowFiltrationArray());
filtration_2.Filter();
Console.WriteLine(filtration_2.ShowMainArray());
Console.WriteLine(filtration_2.ShowFiltrationArray());

Console.WriteLine();

Filtration filtration_3 = new Filtration(filtration_2);
Console.WriteLine(filtration_3.ShowMainArray());
Console.WriteLine(filtration_3.ShowFiltrationArray());
filtration_3.Add(56, 9);
filtration_3.Add(5, null);
filtration_3.Add(null, 10);
Console.WriteLine(filtration_3.ShowMainArray());
Console.WriteLine(filtration_3.ShowFiltrationArray());
filtration_3.Filter();
Console.WriteLine(filtration_3.ShowMainArray());
Console.WriteLine(filtration_3.ShowFiltrationArray());
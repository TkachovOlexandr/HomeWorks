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
//using ArrayOperation;

//Filtration filtration_1 = new Filtration();
//Console.WriteLine(filtration_1.ShowMainArray());
//Console.WriteLine(filtration_1.ShowFiltrationArray());

//Console.WriteLine();

//short[] main_array = {10, 12, -1, 3};
//short[] filtration_array = {3, 7};
//Filtration filtration_2 = new Filtration(main_array, filtration_array);
//Console.WriteLine(filtration_2.ShowMainArray());
//Console.WriteLine(filtration_2.ShowFiltrationArray());
//filtration_2.Filter();
//Console.WriteLine(filtration_2.ShowMainArray());
//Console.WriteLine(filtration_2.ShowFiltrationArray());

//Console.WriteLine();

//Filtration filtration_3 = new Filtration(filtration_2);
//Console.WriteLine(filtration_3.ShowMainArray());
//Console.WriteLine(filtration_3.ShowFiltrationArray());
//filtration_3.Add(56, 9);
//filtration_3.Add(5, null);
//filtration_3.Add(null, 10);
//Console.WriteLine(filtration_3.ShowMainArray());
//Console.WriteLine(filtration_3.ShowFiltrationArray());
//filtration_3.Filter();
//Console.WriteLine(filtration_3.ShowMainArray());
//Console.WriteLine(filtration_3.ShowFiltrationArray());

//Exercise #4
//using WebSite;

//Website website_1 = new Website();
//website_1.WriteAllData();
//website_1.ChangeAllData();
//website_1.WriteAllData();

//Console.WriteLine();

//Website website_2 = new Website(website_1);
//website_2.WriteAllData();
//website_2.WebSiteName = new String("Google");
//website_2.WriteAllData();

//Console.WriteLine();

//Website website_3 = new Website("my-website.com", "http://:my-website.com", "Just for fun!", "172.217.14.206");
//website_3.WriteAllData();
//website_3.WebSiteDescription = new String("For a lark!");
//website_3.WriteAllData();

//Exercise #5
//using MassMedia;

//Magazine magazine_1 = new Magazine();
//magazine_1.WriteAllData();
//magazine_1.ChangeAllData();
//magazine_1.WriteAllData();

//Console.WriteLine();

//Magazine magazine_2 = new Magazine(magazine_1);
//magazine_2.WriteAllData();
//magazine_2.MagazineEmail = new String("magazine_email@gmail.com");
//magazine_2.WriteAllData();

//Console.WriteLine();

//Magazine magazine_3 = new Magazine("Fate", 1948, "Mysterious and unexplained phenomena", "828 702 3032", "fate@gmail.com");
//magazine_3.WriteAllData();

//Exercise #6
using Store;

Shop shop_1 = new Shop();
shop_1.WriteAllData();
shop_1.ChangeAllData();
shop_1.WriteAllData();

Console.WriteLine();

Shop shop_2 = new Shop(shop_1);
shop_2.WriteAllData();
shop_2.ShopName = "fLOVEr";
shop_2.WriteAllData();

Console.WriteLine();

Shop shop_3 = new Shop("Cookies", "Food street, 100", "You won't stay hungry", "097 512 9572", "cookies@gmail.com");
shop_3.WriteAllData();
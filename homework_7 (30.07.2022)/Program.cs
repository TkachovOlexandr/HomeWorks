const string fileName = "History of calculations.txt";

short continuation_choice = 0;
do
{
    short action_choice = 0;
    do
    {
        Console.WriteLine("\nIf you want to use the calculator - enter '1';");
        Console.Write("if you want to review previous actions - enter '2': ");
        action_choice = short.Parse(Console.ReadLine());
    } while (action_choice != 1 && action_choice != 2);
    if (action_choice == 1)
    {
        Console.Write("Enter the first number: ");
        float first_num = float.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        float second_num = float.Parse(Console.ReadLine());
        Console.Write("Enter the mathematical operation sign: ");
        char sign = Console.ReadKey().KeyChar;
        string operation_string = String.Empty;
        if (sign == '+')
            operation_string = $"{first_num} {sign} {second_num} = {first_num + second_num}";
        else if (sign == '-')
            operation_string = $"{first_num} {sign} {second_num} = {first_num - second_num}";
        else if (sign == '*')
            operation_string = $"{first_num} {sign} {second_num} = {first_num * second_num}";
        else if (sign == '/')
            operation_string = $"{first_num} {sign} {second_num} = {first_num / second_num}";
        else
            operation_string = "inappropriate sign";
        if (operation_string.Equals("inappropriate sign"))
            Console.WriteLine($"\nYou entered {operation_string}!");
        else
        {
            File.AppendAllText(fileName, $"{operation_string}\n");
            Console.WriteLine($"\n{operation_string}");
        }
    }
    else
    {
        if (File.Exists(fileName))
            Console.WriteLine(File.ReadAllText(fileName));
        else
            Console.WriteLine("You haven't worked with this calculator yet");
    }
    do
    {
        Console.WriteLine("\nIf you want to continue - enter '1';");
        Console.Write("if you want to end the program execution - enter '2': ");
        continuation_choice = short.Parse(Console.ReadLine());
    } while (continuation_choice != 1 && continuation_choice != 2);
} while (continuation_choice == 1);
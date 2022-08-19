using System.Text.Json;

Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonData.json"));

short choice = 0;
do
{
    do
    {
        Console.WriteLine("\nIf you want to add a new word pair - enter '1';");
        Console.WriteLine("if you want to delete a word pair - enter '2';");
        Console.WriteLine("if you want to find a translation - enter '3';");
        Console.WriteLine("if you want to sort the dictionary - enter '4';");
        Console.WriteLine("if you want to see all the words in the dictionary - enter '5';");
        Console.Write("if you want to finish the program execution - enter '6': ");
        choice = short.Parse(Console.ReadLine());
    } while (choice < 1 || choice > 6);

    if (choice == 1)
    {
        Console.Write("\nEnter an English word: ");
        string engWord = Console.ReadLine();
        Console.Write("Enter its translation: ");
        string itsTranslation = Console.ReadLine();
        dict.Add(engWord, itsTranslation);
        Console.WriteLine("Adding completed successfully!");
    }
    else if (choice == 2)
    {
        Console.Write("\nEnter the word to delete: ");
        string searchingWord = Console.ReadLine();
        foreach (var item in dict)
        {
            if (item.Key.ToLower().Equals(searchingWord.ToLower()) || item.Value.ToLower().Equals(searchingWord.ToLower()))
            {
                dict.Remove(searchingWord);
                Console.WriteLine("Uninstall completed successfully!");
                break;
            }
            if (item.Equals(dict.Last()))
                Console.WriteLine("There is no such word in the dictionary!");
        }
    }
    else if (choice == 3)
    {
        Console.Write("\nEnter searching word: ");
        string searchingWord = Console.ReadLine();
        foreach (var item in dict)
        {
            if (item.Key.ToLower().Equals(searchingWord.ToLower()) || item.Value.ToLower().Equals(searchingWord.ToLower()))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
                break;
            }
            if (item.Equals(dict.Last()))
                Console.WriteLine("There is no such word in the dictionary!");
        }
    }
    else if (choice == 4)
    {
        short sort_choice = 0;
        do
        {
            Console.WriteLine("\nIf you want to sort the dictionary by English words - enter '1';");
            Console.Write("If you want to sort the dictionary by their translations - enter '2': ");
            sort_choice = short.Parse(Console.ReadLine());
        } while (sort_choice != 1 && sort_choice != 2);

        if (sort_choice == 1)
            dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        else
            dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        Console.WriteLine("Sorting completed successfully!");
    }
    else if (choice == 5)
    {
        Console.WriteLine();
        foreach (var item in dict)
            Console.WriteLine($"{item.Key} - {item.Value}");
    }
} while (choice != 6);

File.WriteAllText("jsonData.json", JsonSerializer.Serialize<Dictionary<string, string>>(dict));
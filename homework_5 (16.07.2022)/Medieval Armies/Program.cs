using System;
using System.Data.SqlClient;
using Medieval_Armies.Troops.Warriors_with_swords;
using Medieval_Armies.Troops.Warriors_with_pikes;
using Medieval_Armies.Troops.Warriors_with_bows;
using Medieval_Armies.Troops;
using Medieval_Armies.Champaign;
using Medieval_Armies.Names;
using Medieval_Armies.Database;

Battlefield battlefield = new Battlefield();
for (short i = 0; i < battlefield.Height; i++)
{
    for (short j = 0; j < battlefield.Width; j++)
        battlefield[i, j] = (short)0;
}

Console.Write("Enter the required amount of first group soldiers: ");
short first_group_soldiers = short.Parse(Console.ReadLine());
Console.Write("Enter the required amount of second group soldiers: ");
short second_group_soldiers = short.Parse(Console.ReadLine());
SoldierBase[] soldiers = new SoldierBase[first_group_soldiers + second_group_soldiers];

short choice = 0;
do
{
    Console.Write("\nIf you want to enter information about soldiers yourself - write '1';\nif you want to do it semi-automatically - write '2': ");
    choice = short.Parse(Console.ReadLine());
} while (choice != 1 && choice != 2);


for (short i = 0; i < first_group_soldiers + second_group_soldiers; i++)
{
    if (i == 0)
        Console.WriteLine("\nFirst group:\n");
    else if (i == first_group_soldiers)
        Console.WriteLine("\nSecond group:\n");
    short locationX = 0;
    short locationY = 0;
    string suffix = String.Empty;
    if (i == 0 || i == first_group_soldiers)
        suffix = "st";
    else if (i == 1 || i == first_group_soldiers + 1)
        suffix = "nd";
    else if (i == 2 || i == first_group_soldiers + 2)
        suffix = "rd";
    else
        suffix = "th";
    short iterator = Convert.ToInt16(i < first_group_soldiers ? i + 1 : i - first_group_soldiers + 1);
    Console.WriteLine($"If you want {iterator}-{suffix} warrior to be a Byzantine soldier - enter '1';");
    Console.WriteLine($"If you want {iterator}-{suffix} warrior to be a Rashidun soldier - enter '2';");
    Console.WriteLine($"If you want {iterator}-{suffix} warrior to be a Spanish soldier - enter '3': ");
    Console.Write($"If you want {iterator}-{suffix} warrior to be a Mongol soldier - enter '4': ");
    short choice_of_origin = short.Parse(Console.ReadLine());
    Random random_number = new Random();
    if (choice == 1)
    {
        Console.Write("Enter the soldier's name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the soldier's position on the X-axis: ");
        short location_X = short.Parse(Console.ReadLine());
        Console.Write("Enter the soldier's position on the Y-axis: ");
        short location_Y = short.Parse(Console.ReadLine());
        locationX = location_X >= battlefield.Width || location_X < 0 ? Convert.ToInt16(random_number.Next(0, battlefield.Width - 1)) : location_X;
        locationY = location_Y >= battlefield.Height || location_Y < 0 ? Convert.ToInt16(random_number.Next(0, battlefield.Height - 1)) : location_Y;
        if (choice_of_origin == 1)
            soldiers[i] = new Byzantine_soldier(name, locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else if (choice_of_origin == 2)
            soldiers[i] = new Rashidun_soldier(name, locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else if (choice_of_origin == 3)
            soldiers[i] = new Spanish_soldier(name, locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else if (choice_of_origin == 4)
            soldiers[i] = new Mongol_soldier(name, locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else
            soldiers[i] = new Byzantine_soldier(name, locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
    }
    else
    {
        locationX = Convert.ToInt16(random_number.Next(0, battlefield.Width - 1));
        locationY = Convert.ToInt16(random_number.Next(0, battlefield.Height - 1));
        if (choice_of_origin == 1)
            soldiers[i] = new Byzantine_soldier(Names.Byzantine[random_number.Next(0, Names.Byzantine.Length - 1)], locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else if (choice_of_origin == 2)
            soldiers[i] = new Rashidun_soldier(Names.Rashidun[random_number.Next(0, Names.Rashidun.Length - 1)], locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else if (choice_of_origin == 3)
            soldiers[i] = new Spanish_soldier(Names.Spanish[random_number.Next(0, Names.Spanish.Length - 1)], locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else if (choice_of_origin == 4)
            soldiers[i] = new Mongol_soldier(Names.Mongol[random_number.Next(0, Names.Mongol.Length - 1)], locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
        else
            soldiers[i] = new Byzantine_soldier(Names.Byzantine[random_number.Next(0, Names.Byzantine.Length - 1)], locationX, locationY, i < first_group_soldiers ? (short)1 : (short)2);
    }
    battlefield[locationY, locationX] = i < first_group_soldiers ? (short)1 : (short)2;
}

Console.WriteLine("\nThe battlefield now looks like this:\n");
battlefield.Show(soldiers);

Console.WriteLine("\nThe composition of the teams before the battle:");
for (short i = 0; i < 2 * soldiers.Length; i++)
{
    if (i == 0)
        Console.WriteLine("\nBlue team:\n");
    else if (i == first_group_soldiers)
        Console.WriteLine("\nRed team:\n");
    if (i < soldiers.Length)
    {
        if (soldiers[i].GroupNumber == 1)
            Console.WriteLine($"{soldiers[i].Name} ({soldiers[i].LocationX}, {soldiers[i].LocationY})");
    }
    else
    {
        if (soldiers[i - soldiers.Length].GroupNumber == 2)
            Console.WriteLine($"{soldiers[i - soldiers.Length].Name} ({soldiers[i - soldiers.Length].LocationX}, {soldiers[i - soldiers.Length].LocationY})");
    }
}

Console.WriteLine("\nIf you want the battle to start, press any key");
Console.ReadKey();

Console.Clear();
battlefield.Show(soldiers);
short frame_number = 1;
while (!battlefield.IsTheBattleOver(soldiers))
{
    System.Threading.Thread.Sleep(1000);
    if (frame_number % 2 == 1)
    {
        for (short i = 0; i < soldiers.Length; i++)
        {
            if (i != 0 && soldiers[i - 1].EnemyIsDefeated)
                break;
            if (soldiers[i].HitPoint != 0)
                soldiers[i].Attack(battlefield.Champaign, soldiers);
        }
    }
    else
    {
        for (short i = Convert.ToInt16(soldiers.Length); i > 0; i--)
        {
            if (i != soldiers.Length && soldiers[i].EnemyIsDefeated)
                break;
            if (soldiers[i - 1].HitPoint != 0)
                soldiers[i - 1].Attack(battlefield.Champaign, soldiers);
        }
    }
    frame_number++;
}
Console.SetCursorPosition(0, battlefield.Height);

short all_blue_soldiers = 0;
short all_survivors = 0;
short all_red_soldiers = 0;
short survivor_group_number = 0;
for (short i = 0; i < soldiers.Length; i++)
{
    if (soldiers[i].GroupNumber == 1)
        all_blue_soldiers++;
    else
        all_red_soldiers++;
    if (soldiers[i].HitPoint != 0)
    {
        all_survivors++;
        survivor_group_number = soldiers[i].GroupNumber;
    }
}

Singleton connection = Singleton.GetInstance("Server=DESKTOP-32NV42E;Database=Medieval Armies Battles Results;Trusted_Connection=True;");
DataBase dataBase = new DataBase(connection);
using (dataBase.SqlConnection)
{
    dataBase.SqlConnection.Open();
    SqlCommand command_1 = dataBase.Request("SELECT TOP 1 * FROM Results ORDER BY ID DESC;");
    SqlDataReader reader = command_1.ExecuteReader();
    short number = 0;
    while (reader.Read())
        number = Convert.ToInt16(reader.GetValue(1));
    reader.Close();

    SqlCommand command_2 = dataBase.Request(String.Format("INSERT INTO Winner_Info(All_Soldiers, Survivors) VALUES({0}, {1}); INSERT INTO Loser_Info(All_Soldiers) VALUES({2}); INSERT INTO Results(Winner_Id, Loser_Id) VALUES({3}, {3}); ", survivor_group_number == 1 ? all_blue_soldiers : all_red_soldiers, all_survivors, survivor_group_number == 1 ? all_red_soldiers : all_blue_soldiers, number + 1));
    if (command_2.ExecuteNonQuery() > 0)
        Console.WriteLine("The battle is over");
    dataBase.SqlConnection.Close();
}

string color_of_winner = survivor_group_number == 1 ? new string("blue") : new string("red");
string names_of_survivors = String.Empty;
for (short i = 0; i < soldiers.Length; i++)
{
    if (soldiers[i].HitPoint != 0)
        names_of_survivors += soldiers[i].Name + ", ";
}
names_of_survivors = names_of_survivors.Remove(names_of_survivors.Length - 2);
Console.WriteLine($"A total of {soldiers.Length} fighters participated in the battle. The {color_of_winner} team won.\n{all_survivors} people survived - {names_of_survivors}.");
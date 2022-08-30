using PlayingCard;

short[] forHearts = new short[9];
short[] forClubs = new short[9];
short[] forDiamonds = new short[9];
short[] forSpades = new short[9];

Random rnd = new Random();
for (short i = 0; i < 9; i++)
{
    do
    {
        short tmp = (short)rnd.Next(6, 15);
        if (!Array.Exists(forHearts, element => element == tmp))
            forHearts[i] = tmp;
    } while (forHearts[i] == 0);
    do
    {
        short tmp = (short)rnd.Next(6, 15);
        if (!Array.Exists(forClubs, element => element == tmp))
            forClubs[i] = tmp;
    } while (forClubs[i] == 0);
    do
    {
        short tmp = (short)rnd.Next(6, 15);
        if (!Array.Exists(forDiamonds, element => element == tmp))
            forDiamonds[i] = tmp;
    } while (forDiamonds[i] == 0);
    do
    {
        short tmp = (short)rnd.Next(6, 15);
        if (!Array.Exists(forSpades, element => element == tmp))
            forSpades[i] = tmp;
    } while (forSpades[i] == 0);
}

Stack<Card> deck = new Stack<Card>();
short heartsAmount = 0;
short clubsAmount = 0;
short diamondsAmount = 0;
short spadesAmount = 0;

for (short i = 0; i < 36; i++)
{
    short tmp = 0;
    do
    {
        tmp = (short)rnd.Next(1, 5);
    } while ((tmp == 1 && heartsAmount > 8) || (tmp == 2 && clubsAmount > 8) || (tmp == 3 && diamondsAmount > 8) || (tmp == 4 && spadesAmount > 8));

    if (tmp == 1)
    {
        deck.Push(new Card(new Hearts(), forHearts[heartsAmount]));
        heartsAmount++;
    }
    else if (tmp == 2)
    {
        deck.Push(new Card(new Clubs(), forClubs[clubsAmount]));
        clubsAmount++;
    }
    else if (tmp == 3)
    {
        deck.Push(new Card(new Diamonds(), forDiamonds[diamondsAmount]));
        diamondsAmount++;
    }
    else
    {
        deck.Push(new Card(new Spades(), forSpades[spadesAmount]));
        spadesAmount++;
    }
}

Card[] player = new Card[6];
Card[] bot = new Card[6];
for (short i = 0; i < 6; i++)
{
    deck.TryPop(out player[i]);
    deck.TryPop(out bot[i]);
}

string trumpCard = deck.Peek().SuitName;
Console.WriteLine($"{char.ToUpper(trumpCard.First()) + trumpCard.Substring(1)} are the trump card\n");

short temporary = 1;
while (true)
{
    if (temporary % 2 == 1)
    {
        Console.WriteLine("You have:");
        for (int i = 0; i < player.Length; i++)
            Console.WriteLine($"{i + 1}) {player[i].ToString()}");
        short cardNumber = 0;
        do
        {
            Console.Write("Write the sequence number of the card you are going to use: ");
            cardNumber = short.Parse(Console.ReadLine());
        } while (cardNumber < 1 || cardNumber > player.Length);
        Console.WriteLine($"You played the {player[cardNumber - 1].ToString()} card");
        for (short i = 0; i < bot.Length; i++)
        {
            if ((player[cardNumber - 1].SuitName.Equals(bot[i].SuitName) && player[cardNumber - 1].Number < bot[i].Number) || (!player[cardNumber - 1].SuitName.Equals(trumpCard) && bot[i].SuitName.Equals(trumpCard)) || (player[cardNumber - 1].SuitName.Equals(trumpCard) && bot[i].SuitName.Equals(trumpCard) && player[cardNumber - 1].Number < bot[i].Number))
            {
                Console.WriteLine($"Bot fought back with the card {bot[i].ToString()}");
                bot[i] = new Card(new Hearts(), (short)0);
                break;
            }
        }
        if (Array.Exists(bot, element => element.Number == (short)0))
        {
            player[cardNumber - 1] = new Card(new Hearts(), (short)0);
            if (deck.Count != 1)
            {
                deck.TryPop(out Card card);
                if (player.Length < 7)
                    deck.TryPop(out player[cardNumber - 1]);
                if (bot.Length < 7)
                {
                    for (short i = 0; i < bot.Length; i++)
                    {
                        if (bot[i].Number == (short)0)
                            deck.TryPop(out bot[i]);
                    }
                }
                deck.Push(card);
            }
            else if (player.Length < 7)
                deck.TryPop(out player[cardNumber - 1]);
        }
        else
        {
            Console.WriteLine("Bot has nothing to beat your card. Bot take this card.");
            temporary--;
            Array.Resize<Card>(ref bot, bot.Length + 1);
            bot[bot.Length - 1] = player[cardNumber - 1];
            player[cardNumber - 1] = new Card(new Hearts(), (short)0);
            if (deck.Count != 1 && player.Length < 7)
            {
                deck.TryPop(out Card card);
                deck.TryPop(out player[cardNumber - 1]);
                deck.Push(card);
            }
            else if (player.Length < 7)
                deck.TryPop(out player[cardNumber - 1]);
        }
    }
    else
    {
        short cardNumber = (short)rnd.Next(0, bot.Length);
        Console.WriteLine($"Bot played the {bot[cardNumber].ToString()} card");
        Console.WriteLine("This is how you can beat your opponent's card:");
        short temp = 1;
        Card[] cards = new Card[1];
        for (short i = 0; i < player.Length; i++)
        {
            if ((bot[cardNumber].SuitName.Equals(player[i].SuitName) && bot[cardNumber].Number < player[i].Number) || (!bot[cardNumber].SuitName.Equals(trumpCard) && player[i].SuitName.Equals(trumpCard)) || (bot[cardNumber].SuitName.Equals(trumpCard) && player[i].SuitName.Equals(trumpCard) && bot[cardNumber].Number < player[i].Number))
            {
                Console.WriteLine($"{temp}) {player[i].ToString()}");
                cards[cards.Length - 1] = player[i];
                Array.Resize<Card>(ref cards, cards.Length + 1);
                temp++;
            }
        }
        if (temp == (short)1)
        {
            Console.WriteLine("You have nothing to beat your opponent's card. You take this card.");
            temporary--;
            Array.Resize<Card>(ref player, player.Length + 1);
            player[player.Length - 1] = bot[cardNumber];
            bot[cardNumber] = new Card(new Hearts(), (short)0);
            if (deck.Count != 1 && bot.Length < 7)
            {
                deck.TryPop(out Card card);
                deck.TryPop(out bot[cardNumber]);
                deck.Push(card);
            }
            else if (bot.Length < 7)
                deck.TryPop(out bot[cardNumber]);
        }
        else
        {
            short playerCardNumber = 0;
            do
            {
                Console.Write("Write the sequence number of the card you are going to use: ");
                playerCardNumber = short.Parse(Console.ReadLine());
            } while (playerCardNumber < 1 || playerCardNumber > temp);

            bot[cardNumber] = new Card(new Hearts(), (short)0);
            short num = 0;
            for (short i = 0; i < player.Length; i++)
            {
                if (player[i].SuitName.Equals(cards[playerCardNumber - 1].SuitName) && player[i].Number == cards[playerCardNumber - 1].Number)
                {
                    player[i] = new Card(new Hearts(), (short)0);
                    num = i;
                    break;
                }
            }
            if (deck.Count != 1)
            {
                deck.TryPop(out Card card);
                if (bot.Length < 7)
                    deck.TryPop(out bot[cardNumber]);
                if (player.Length < 7)
                    deck.TryPop(out player[num]);
                deck.Push(card);
            }
            else if (bot.Length < 7)
                deck.TryPop(out bot[cardNumber]);
        }
    }
    for (short i = 0; i < player.Length; i++)
    {
        if (player[i] == null || player[i].Number == (short)0)
        {
            for (short j = i; j < player.Length - 1; j++)
                player[j] = player[j + 1];
            Array.Resize<Card>(ref player, player.Length - 1);
        }
    }
    for (short i = 0; i < bot.Length; i++)
    {
        if (bot[i] == null || bot[i].Number == (short)0)
        {
            for (short j = i; j < bot.Length - 1; j++)
                bot[j] = bot[j + 1];
            Array.Resize<Card>(ref bot, bot.Length - 1);
        }
    }
    if (player.Length == 0 || bot.Length == 0)
        break;
    Console.WriteLine($"\nNow you have {player.Length} cards;");
    Console.WriteLine($"And bot has {bot.Length} cards.");
    Console.WriteLine($"There are {deck.Count} cards left in the deck.\n");
    temporary++;
}
Console.WriteLine();
if (player.Length == 0)
{
    Console.WriteLine("You won! Congratulations!");
    Console.WriteLine("\nAfter the game, bot has the following cards:");
    foreach (var item in bot)
        Console.WriteLine(item.ToString());
}
else
    Console.WriteLine("Bot won. Better luck next time.");
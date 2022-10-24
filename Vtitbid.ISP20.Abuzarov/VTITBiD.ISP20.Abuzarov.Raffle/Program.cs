Random rnd = new Random();
Console.Write("Введите количество игроков:");
int players = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количесвто победителей:");
int winners = Convert.ToInt32(Console.ReadLine());
int[] nplayers = new int[players];
int[] win = new int[winners];

for (int i = 0; i < winners; i++)
{
    win[i] = rnd.Next(2, players);
    Console.Write(" " + win[i]);

}




for (int i = 0; i < winners; i++)
{
    for (int j = i + 1; j < winners; j++)
    {
        if (win[i] == win[j])
        {
            win[j] = rnd.Next(1, players);

        }

    }
}



Console.WriteLine();

for (int i = 0; i < winners; i++)
{
    Console.Write(" " + win[i]);
}

Console.WriteLine("\nПобеда номера 1");
for (int i = 0; i < players + 1; i++)
{
    for (int j = 0; j < winners; j++)
    {
        if (i == win[j])
        {

            Console.WriteLine($"\nПобеда номера: {i}");
            i++;

        }
    }

}
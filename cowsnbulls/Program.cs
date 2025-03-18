using System;
var r = new Random();
string num = "";
int atts = 1;
for (int i = 0; i < 4; i++)
{
    char number = Convert.ToChar(r.Next(49, 58));
    while (num.Contains(number))
    {
        number = Convert.ToChar(r.Next(49, 58));
    }
    num = num + Convert.ToString(number);
}
Console.WriteLine(num);
while (true)
{
    int cows = 0;
    int bulls = 0;
    Console.Write("Enter 4 digit number: ");
    string guess = Console.ReadLine();
    while (guess != num)
    {
        if (guess == "")
        {
            Console.WriteLine("Invalid guess!");
            break;
        }
        atts++;
        for (int i = 49; i < 58; i++)
        {
            char c = Convert.ToChar(i);
            int index = guess.IndexOf(c);
            int numdex = num.IndexOf(c);
            if (index >= 0 && index == numdex)
            {
                cows++;
            }
            else if (index >= 0 && guess.Contains(c) && num.Contains(c))
            {
                bulls++;
            }
        }
        Console.WriteLine("Cows: " + cows + "\nBulls: " + bulls);
        break;
    }
    if (guess == num)
    {
        break; 
    }
    else 
    {
        Console.WriteLine("");
    }
}
Console.WriteLine("Congrats! Attempts: " + atts);
using System;
using System.Linq;
var r = new Random();
while (true)
{
	string num = "";
	string lower = "10";
	string upper = "98";
	Console.Write("Enter digits: ");
	int digits = Convert.ToInt32(Console.ReadLine());
	if (digits < 3)
	{
		Console.WriteLine("Can't be lower than 3, setting to default (4)");
		digits = 4;
	}
	int atts = 1;
	for (int i = 0; i < digits; i++)
	{
		char number = Convert.ToChar(r.Next(49, 58));
		while (num.Contains(number))
		{
			number = Convert.ToChar(r.Next(49, 58));
		}
		num = $"{num}{number}";
	}
	for (int i = 1; lower.Length != digits; i++)
	{
		lower = $"{lower}{i + 1}";
		upper = $"{upper}{8 - i}";
	}
	while (true)
	{
		int cows = 0;
		int bulls = 0;
		Console.Write($"Enter {digits} digit number: ");
		string guess = Console.ReadLine();
		while (guess != num)
		{
			if (guess.GroupBy(x => x).Any(g => g.Count() > 1) || guess == "" || Convert.ToInt32(guess) < Convert.ToInt32(lower) || Convert.ToInt32(guess) > Convert.ToInt32(upper) || guess.Length > digits)
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
					bulls++;
				}
				else if (index >= 0 && guess.Contains(c) && num.Contains(c))
				{
					cows++;
				}
			}
			break;
		}
		if (guess == num || bulls == digits)
		{
			Console.Write($"Congrats! Attempts: {atts}\nDo you wish to play again? Press 1 if so: ");
			var restart = Console.ReadLine();
			if (restart == "1")
			{
				break;
			}
			else
			{
				goto leave;
			}
		}
		else
		{
			Console.WriteLine($"Cows: {cows}\nBulls: {bulls}");
		}
	}
}
leave:;
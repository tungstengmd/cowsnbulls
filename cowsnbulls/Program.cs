using System;
var r = new Random();
string num = "";
string lower = "10";
string upper = "98";
while (true)
{
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
		num = num + Convert.ToString(number);
	}
	for (int i = 1; lower.Length != digits; i++)
	{
		lower = lower + Convert.ToString(i + 1);
		upper = upper + Convert.ToString(8 - i);
		Console.WriteLine($"{lower} {upper}");
	}
	while (true)
	{
		int cows = 0;
		int bulls = 0;
		Console.Write($"Enter {digits} digit number: ");
		string guess = Console.ReadLine();
		while (guess != num)
		{
			if (guess == "" || Convert.ToInt32(guess) > 9876 || Convert.ToInt32(guess) < 1023)
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
			Console.WriteLine($"Cows: {cows}\nBulls: {bulls}");
			break;
		}
		if (guess == num)
		{
			Console.Write($"Congrats! Attempts: {atts}\nDo you wish to play again? Press 1 if so: ");
			var restart = Console.ReadLine();
			if (restart == "1")
			{
				break;
			}
		}
		else
		{
			Console.Write("");
		}
	}
}
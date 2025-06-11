using System;
using System.Linq;
using System.Runtime.InteropServices;
var r = new Random();
int atts = 1;
//back:;
Console.Clear();
Console.WriteLine("Welcome to Cows & Bulls!");
while (true)
{
	string[] lines = new string[1000000];
	//if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) lines = File.ReadAllLines($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\scores.txt"); else lines = File.ReadAllLines($"{Environment.GetEnvironmentVariable("HOME")}/scores.txt");
	//int[] lint = Array.ConvertAll(lines, int.Parse);
	Console.WriteLine("Menu:\n1: Play game\n2: High score\n3: Quit");
	var option = Console.ReadLine();
	if (option == "3") break;
	/*else if (option == "2")
	{
		foreach (var i in lint)
		{
			if (i == 0) Console.WriteLine("No high score :(");
			else
			{
				Console.Clear();
				Console.WriteLine($"The lowest attempt count was {lint.Min()}.");
				Console.ReadLine();
				goto back;
			}
		}
	}*/
	else
	{
		var num = "";
		string lower = "10";
		string upper = "98";
		Console.Write("Enter digits: ");
		int digits = Convert.ToInt32(Console.ReadLine());
		if (digits < 3)
		{
			Console.WriteLine("Can't be lower than 3, setting to default (4)");
			digits = 4;
		}
		else if (digits > 9) throw new ArgumentOutOfRangeException("\e[91mERROR: \e[0mOUT OF RANGE, NUMBER CANNOT BE BIGGER THAN 9"); 
		atts = 1;
		ffs:;
		for (int i = 0; i < digits; i++)
		{
			char number = Convert.ToChar(r.Next(48, 58));
			while (num.Contains(number))
			{
				number = Convert.ToChar(r.Next(48, 58));
			}
			num = $"{num}{number}";
		}
		for (int i = 1; lower.Length != digits; i++)
		{
			lower = $"{lower}{i + 1}";
			upper = $"{upper}{8 - i}";
		}
		if (Convert.ToInt32(num) < Convert.ToInt32(lower) || Convert.ToInt32(num) > Convert.ToInt32(upper)) goto ffs;
		while (true)
		{
			int cows = 0;
			int bulls = 0;
			Console.Write($"Enter {digits} digit number: ");
			var guess = Console.ReadLine();
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
					if (index >= 0 && index == numdex) bulls++; else if (index >= 0 && guess.Contains(c) && num.Contains(c)) cows++;
				}
				break;
			}
			if (guess == num || bulls == digits)
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					var read = File.ReadAllText($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\scores.txt");
					File.WriteAllText($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\scores.txt", $"{read}{atts}\n");
				}
				else
				{
					var read = File.ReadAllText($"{Environment.GetEnvironmentVariable("HOME")}/scores.txt");
					File.WriteAllText($"{Environment.GetEnvironmentVariable("HOME")}/scores.txt", $"{read}{atts}\n");
				}
				Console.Write($"\e[32mCongrats! Attempts: {atts}\n\e[39mDo you wish to play again? Press 1 if so: ");
				var restart = Console.ReadLine();
				if (restart == "1")
				{
					Console.Clear();
					Console.WriteLine("Welcome back!");
					break;
				}
				else goto leave;
			}
			else
			{
				Console.WriteLine($"Cows: {cows}\nBulls: {bulls}");
			}
		}
	}
}
leave:;

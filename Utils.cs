using System;

namespace MazeTraversal
{
	internal class Utils
	{
		public static void PrintUsage()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Usage: MazeTraversal <inputfile>");
		}

		public static void ShowErrorMessage(string error)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Could not open file {error}");
			Environment.Exit(1);
		}

		public static void PrintSolution(string[][] maze)
		{
			foreach (var i in maze)
			{
				foreach (var j in i)
				{
					if (j == "X")
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write($"{j} ");
						Console.ResetColor();
					}
					else if (j == "?") // unfinished path
					{
						Console.Write("  ");
					}
					else
					{
						Console.Write($"{j} ");
					}
				}

				Console.WriteLine();
			}


			Console.ReadLine();
			Environment.Exit(0);
		}
	}
}
using System;
using System.IO;

namespace MazeTraversal
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0 || args.Length > 1)
			{
				Utils.PrintUsage();
				Environment.Exit(1);
			}

			var maze = new MazeCreator($"{Directory.GetCurrentDirectory()}\\{args[0]}");
			Init(maze);
		}

		public static void Init(MazeCreator maze) => new MoveProcessor(maze);
	}
}

using System;
using System.IO;

namespace MazeTraversal
{
    internal class MazeCreator
    {
	    public readonly string[] RawFile;
	    public readonly string[] MazeTemplate;
	    public readonly int StartX;
	    public readonly int StartY;
		public readonly int EndX;
	    public readonly int EndY;
	    public string[][] Maze;

		public MazeCreator(string inputFile)
	    {
		    try
		    {
			    RawFile = File.ReadAllLines(inputFile);
			    if (RawFile == null) throw new Exception();
		    }
		    catch (Exception e)
		    {
			    Utils.ShowErrorMessage(e.ToString());
		    }

		    var dimensions = RawFile[0].Split(' ');
			var height = int.Parse(dimensions[1]);

			var start = RawFile[1].Split(' ');
		    StartX = int.Parse(start[0]);
		    StartY = int.Parse(start[1]);

		    var end = RawFile[2].Split(' ');

		    EndX = int.Parse(end[0]);
		    EndY = int.Parse(end[1]);


			MazeTemplate = new string[height];
		    Array.Copy(RawFile, 3, MazeTemplate, 0, height);
			CreateInitialMaze();
	    }

	    public void CreateInitialMaze()
	    {
			Maze = new string[MazeTemplate.Length][];

		    for (var i = 0; i < MazeTemplate.Length; i++)
		    {
			    Maze[i] = MazeTemplate[i].Split(' ');
		    }

			for (var i = 0; i < MazeTemplate.Length; i++)
		    {
			    for (var j = 0; j < Maze[i].Length; j++)
			    {
				    if (Maze[i][j] == "1")
				    {
					    Maze[i][j] = "#";					    
				    }
				    else
				    {
					    Maze[i][j] = " ";
				    }
				}
		    }

		    Maze[StartY][StartX] = "S";
		    Maze[EndY][EndX] = "E";	
		}
    }
}
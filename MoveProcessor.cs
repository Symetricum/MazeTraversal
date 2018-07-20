using System.Collections.Generic;

namespace MazeTraversal
{
	internal class MoveProcessor
	{
		private readonly string[][] _maze;

		public MoveProcessor(MazeCreator mc)
		{
			var mazeCreator = mc;
			_maze = mc.Maze;

			MakeMove(mazeCreator.StartX, mazeCreator.StartY);
		}

		public void MakeMove(int x, int y)
		{
			var queue = new Queue<Position>();
			var position = new Position
			{
				X = x,
				Y = y,
				Previous = null
			};

			queue.Enqueue(position);

			while (queue.Count != 0)
			{
				var pos = queue.Dequeue();

				if (IsEndPoint(pos.X, pos.Y)) // first check whether we have a solution
				{
					var route = pos.Previous;
					while (route.Previous != null)
					{
						_maze[route.X][route.Y] = "X";
						route = route.Previous;
					}
					Utils.PrintSolution(_maze);
				}

				if (IsValidMove(pos.X + 1, pos.Y)) // Attempt to move East
				{
					SetPathVisited(pos.X, pos.Y);
					var next = new Position
					{
						X = pos.X + 1,
						Y = pos.Y,
						Previous = pos
					};

					queue.Enqueue(next);
				}

				if (IsValidMove(pos.X - 1, pos.Y)) //  West
				{
					SetPathVisited(pos.X, pos.Y);
					var next = new Position
					{
						X = pos.X - 1,
						Y = pos.Y,
						Previous = pos
					};

					queue.Enqueue(next);
				}

				if (IsValidMove(pos.X, pos.Y + 1)) // North
				{
					SetPathVisited(pos.X, pos.Y);
					var next = new Position
					{
						X = pos.X,
						Y = pos.Y + 1,
						Previous = pos
					};

					queue.Enqueue(next);
				}

				if (IsValidMove(pos.X, pos.Y - 1)) // South
				{
					SetPathVisited(pos.X, pos.Y);
					var next = new Position
					{
						X = pos.X,
						Y = pos.Y - 1,
						Previous = pos
					};

					queue.Enqueue(next);
				}
			}
		}

		//Check move is within maze boundaries, is a pathway or the exit 
		private bool IsValidMove(int x, int y)
		{
			return (x >= 0 && x < _maze.Length) && (y >= 0 && y < _maze[x].Length) && (_maze[x][y] == " " || _maze[x][y] == "E");
		}

		//Mark visited paths to block moves to already-attempted paths
		public void SetPathVisited(int x, int y)
		{
			if (_maze[x][y] != "S")
			{
				_maze[x][y] = "?";
			}
		}

		public bool IsEndPoint(int x, int y)
		{
			return _maze[x][y] == "E";
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsCrosses
{
	class Game
	{
		// using a jagged array
		private Square[][] _board =
		{
			new Square[3],
			new Square[3],
			new Square[3]
		};

		// replace with this definition of board to see how to delare
		// with a multi-dimensional array. 
		// You'll then need to replace all [][] operators with [,] for the code to compile
		//		private Square[,] _board = new Square[3, 3];


		// replace with this definition of board to see how to
		// work with lists instead of arrays
		// (but this demo is really best suited to a multi-dimensional array)
		//private List<List<Square>> _board = new List<List<Square>>()
		//{
		//	new List<Square>{ new Square(), new Square(), new Square()},
		//	new List<Square>{ new Square(), new Square(), new Square()},
		//	new List<Square>{ new Square(), new Square(), new Square()}
		//};

		public void PlayGame()
		{
			Player player = Player.Crosses;

			bool @continue = true;
			while (@continue)
			{
				DisplayBoard();
				@continue = PlayMove(player);
				if (!@continue)
					return;
				player = 3 - player;	// swaps player between X and O
			}
		}

		private void DisplayBoard()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
					Console.Write(" " + _board[i][j]);
				Console.WriteLine();
			}

		}

		private bool PlayMove(Player player)
		{
			Console.WriteLine("Invalid input quits game");
			Console.Write($"{player}: Enter row comma column, eg. 3,3 > ");
			string input = Console.ReadLine();
			string[] parts = input.Split(',');
			if (parts.Length != 2)
				return false;
			int.TryParse(parts[0], out int row);
			int.TryParse(parts[1], out int column);

			if (row < 1 || row > 3 || column < 1 || column > 3)
				return false;

			if (_board[row - 1][column - 1].Owner != Player.None)
			{
				Console.WriteLine("Square is already occupied");
				return false;
			}

			_board[row - 1][column - 1] = new Square(player);
			return true;
		}
	}
}

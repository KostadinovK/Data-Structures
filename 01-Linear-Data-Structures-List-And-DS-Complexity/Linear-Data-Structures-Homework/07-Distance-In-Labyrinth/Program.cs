using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class Tile
{
	public int Row { get; private set; }
	public int Col { get; private set; }

	public int Number { get; private set; }

	public Tile(int row, int col, int number)
	{
		Row = row;
		Col = col;
		Number = number;
	}
}

public class Program
{
	
	private static void SetUnreachableTiles(string[,] maze,int size)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				if (maze[i,j] == "0")
				{
					maze[i, j] = "u";
				}
			}
		}

	}
	
	private static void CheckInFourDirections(Tile tile,string[,] maze, int size,List<Tile> tilesToCheck)
	{
		int row = tile.Row;
		int col = tile.Col;
		int number = tile.Number;

		//Up
		if (row-1 >= 0 && maze[row-1,col] == "0")
		{
			Tile upperTile = new Tile(row-1,col,number+1);
			maze[row - 1, col] = (number + 1).ToString();
			tilesToCheck.Add(upperTile);
		}

		//Right
		if (col+1 < size && maze[row,col+1] == "0")
		{
			Tile rightTile = new Tile(row, col+1, number + 1);
			maze[row, col+1] = (number + 1).ToString();
			tilesToCheck.Add(rightTile);
		}

		//Down
		if (row+1 < size && maze[row+1,col] == "0")
		{
			Tile downTile = new Tile(row + 1, col, number + 1);
			maze[row + 1, col] = (number + 1).ToString();
			tilesToCheck.Add(downTile);
		}

		//Left
		if (col-1 >= 0 && maze[row,col-1] == "0")
		{
			Tile leftTile = new Tile(row, col-1, number + 1);
			maze[row, col-1] = (number + 1).ToString();
			tilesToCheck.Add(leftTile);
		}
	}

	public static void Main()
	{
		int size = int.Parse(Console.ReadLine());

		string[,] maze = new string[size,size];

		int startingRow = 0;
		int startingCol = 0;
		for (int i = 0;i < size;i++)
		{
			string line = Console.ReadLine();
			for (int j = 0;j < size;j++)
			{
				maze[i, j] = line[j].ToString();
				if (line[j] == '*')
				{
					startingRow = i;
					startingCol = j;
				}
			}
		}

		List<Tile> tilesToCheck = new List<Tile>();
		Tile start = new Tile(startingRow,startingCol,0);
		tilesToCheck.Add(start);

		while (tilesToCheck.Count != 0)
		{
			
			int endIndex = tilesToCheck.Count;
			for (int i = 0; i < endIndex; i++)
			{
				CheckInFourDirections(tilesToCheck[i],maze, size, tilesToCheck);
			}

			for (int i = 0; i < endIndex; i++)
			{
				tilesToCheck.RemoveAt(0);
			}
		}

		SetUnreachableTiles(maze, size);

		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				Console.Write(maze[i,j]);
			}

			Console.WriteLine();
		}


	}
}

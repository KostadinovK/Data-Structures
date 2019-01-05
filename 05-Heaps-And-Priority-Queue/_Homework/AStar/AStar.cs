using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AStar
{
	public char[,] Map { get; set; }
	public PriorityQueue<Node> Nodes { get; set; }
	public Dictionary<Node, Node> CameFrom { get; set; }

	private Node start;
	private Node goal;

	public AStar(char[,] map)
	{
		Map = map;
		Nodes = new PriorityQueue<Node>();
		CameFrom = new Dictionary<Node, Node>();
		start = GetStartNode();
		goal = GetGoalNode();

		Nodes.Enqueue(start);
		CameFrom[start] = null;
	}

	public static int GetH(Node current, Node goal)
	{
		int deltaX = Math.Abs(current.Col - goal.Col);
		int deltaY = Math.Abs(current.Row - goal.Row);

		return deltaX + deltaY;
	}

	public static int GetG(Node current, Node start)
	{
		int deltaX = Math.Abs(current.Col - start.Col);
		int deltaY = Math.Abs(current.Row - start.Row);

		return deltaX + deltaY;
	}

	public static int GetF(Node current, Node start, Node goal)
	{
		return GetG(current,start) + GetH(current,goal);
	}


	public IEnumerable<Node> GetPath(Node start, Node goal)
    {
	    while (Nodes.Count > 0)
	    {
		    Node current = Nodes.Dequeue();

		    if (current.Row == goal.Row && current.Col == goal.Col)
		    {
			    break;
		    }

		    List<Node> neighbors = GetNeighborsNodes(current);
		    foreach (var neighbor in neighbors)
		    {
			    if (!CameFrom.ContainsKey(neighbor) && Map[neighbor.Row,neighbor.Col] != 'W')
			    {
				    neighbor.F = GetF(neighbor, start, goal);
					Nodes.Enqueue(neighbor);
				    CameFrom[neighbor] = current;
			    }
		    }
	    }

	    if (!CameFrom.ContainsKey(goal))
	    {
			return new List<Node>(){start};
	    }

	    List<Node> path = new List<Node>();
	    Node currentNode = goal;
	    while (currentNode.Row != start.Row || currentNode.Col != start.Col)
	    {
		    path.Add(currentNode);
		    currentNode = CameFrom[currentNode];
	    }
		path.Add(start);
		path.Reverse();
	    return path;
    }

	private Node GetStartNode()
	{
		for (int row = 0; row < Map.GetLength(0); row++)
		{
			for (int col = 0; col < Map.GetLength(1); col++)
			{
				if (Map[row,col] == 'P')
				{
					return new Node(row,col);
				}
			}
		}

		throw new ArgumentException("Start was not found");
	}

	private Node GetGoalNode()
	{
		for (int row = 0; row < Map.GetLength(0); row++)
		{
			for (int col = 0; col < Map.GetLength(1); col++)
			{
				if (Map[row, col] == '*')
				{
					return new Node(row, col);
				}
			}
		}

		throw new ArgumentException("Goal was not found");
	}

	private List<Node> GetNeighborsNodes(Node current)
	{
		List<Node> neighbors = new List<Node>();

		if (current.Col - 1 >= 0)
		{
			neighbors.Add(new Node(current.Row,current.Col - 1));
		}

		if (current.Col + 1 < Map.GetLength(1))
		{
			neighbors.Add(new Node(current.Row, current.Col + 1));
		}

		if (current.Row - 1 >= 0)
		{
			neighbors.Add(new Node(current.Row - 1, current.Col));
		}

		if (current.Row + 1 < Map.GetLength(0))
		{
			neighbors.Add(new Node(current.Row + 1, current.Col));
		}

		return neighbors;
	}
}


using System;

public class KdTree
{
    private Node root;

    public class Node
    {
        public Node(Point2D point)
        {
            this.Point = point;
        }

        public Point2D Point { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public Node Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(Point2D point)
    {
        Node current = root;

        int depth = 0;

        while (current != null)
        {
            if (current.Point.CompareTo(point) == 0)
            {
                return true;
            }

            if (depth % 2 == 0)
            {
                if (current.Point.X.CompareTo(point.X) > 0)
                {
                    current = current.Left;
                }
                else if(current.Point.X.CompareTo(point.X) < 0)
                {
                    current = current.Right;
                }
            }
            else
            {
                if (current.Point.Y.CompareTo(point.Y) > 0)
                {
                    current = current.Left;
                }
                else if (current.Point.Y.CompareTo(point.Y) < 0)
                {
                    current = current.Right;
                }
            }

            depth++;
        }

        return false;
    }

    public void Insert(Point2D point)
    {
        root = Insert(this.root, point, 0);
    }

    private Node Insert(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return new Node(point);
        }

        if (depth % 2 == 0)
        {
            if (node.Point.X.CompareTo(point.X) > 0)
            {
                node.Left = Insert(node.Left, point, depth + 1);
            }else if (node.Point.X.CompareTo(point.X) < 0)
            {
                node.Right = Insert(node.Right, point, depth + 1);
            }
        }else
        {
            if (node.Point.Y.CompareTo(point.Y) > 0)
            {
                node.Left = Insert(node.Left, point, depth + 1);
            }else if (node.Point.Y.CompareTo(point.Y) < 0)
            {
                node.Right = Insert(node.Right, point, depth + 1);
            }
        }


        return node;
    }

    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }
}

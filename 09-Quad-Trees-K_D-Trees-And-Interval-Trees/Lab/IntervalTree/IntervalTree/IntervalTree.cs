using System;
using System.Collections.Generic;

public class IntervalTree
{
    private class Node
    {
        internal Interval interval;
        internal double max;
        internal Node right;
        internal Node left;

        public Node(Interval interval)
        {
            this.interval = interval;
            this.max = interval.Hi;
        }
    }

    private Node root;

    public void Insert(double lo, double hi)
    {
        this.root = this.Insert(this.root, lo, hi);
    }

    public void EachInOrder(Action<Interval> action)
    {
        EachInOrder(this.root, action);
    }

    public Interval SearchAny(double lo, double hi)
    {
        Node current = root;
        while (current != null && !current.interval.Intersects(lo,hi))
        {
            if (GetMax(current.left) > lo)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        return current?.interval;
    }

    public IEnumerable<Interval> SearchAll(double lo, double hi)
    {
        List<Interval> result = new List<Interval>();
        SearchAll(this.root,result,lo,hi);
        return result;
    }

    private void SearchAll(Node node, List<Interval> result, double lo, double hi)
    {
        if (node == null)
        {
            return;
        }

        if (GetMax(node.left) > lo)
        {
            SearchAll(node.left, result, lo, hi);
        }

        if (node.interval.Intersects(lo, hi))
        {
            result.Add(node.interval);
        }

        if (GetMax(node.right) > lo)
        {
            SearchAll(node.right, result, lo, hi);
        }
    }

    private void EachInOrder(Node node, Action<Interval> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.left, action);
        action(node.interval);
        EachInOrder(node.right, action);
    }

    private Node Insert(Node node, double lo, double hi)
    {
        if (node == null)
        {
            return new Node(new Interval(lo, hi));
        }

        int cmp = lo.CompareTo(node.interval.Lo);
        if (cmp < 0)
        {
            node.left = Insert(node.left, lo, hi);
        }
        else if (cmp > 0)
        {
            node.right = Insert(node.right, lo, hi);
        }

        UpdateMax(node);

        return node;
    }

    private void UpdateMax(Node node)
    {
        double max = Math.Max(GetMax(node.left), GetMax(node.right));

        node.max = Math.Max(max, node.max);
    }

    private double GetMax(Node node)
    {
        if (node == null)
        {
            return 0.0;
        }

        return node.max;
    }
}

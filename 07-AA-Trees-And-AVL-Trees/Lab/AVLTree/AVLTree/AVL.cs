using System;

public class AVL<T> where T : IComparable<T>
{
    private Node<T> root;

    public Node<T> Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(T item)
    {
        var node = this.Search(this.root, item);
        return node != null;
    }

    public void Insert(T item)
    {
        this.root = this.Insert(this.root, item);
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private Node<T> Insert(Node<T> node, T item)
    {
        if (node == null)
        {
            return new Node<T>(item);
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = this.Insert(node.Left, item);
        }
        else if (cmp > 0)
        {
            node.Right = this.Insert(node.Right, item);
        }

        node.Height = 1 + Math.Max(GetHeight(node.Left),GetHeight(node.Right));

        int balance = GetHeight(node.Left) - GetHeight(node.Right);

        if (balance < -1)
        {
            int childBalance = GetHeight(node.Right.Left) - GetHeight(node.Right.Right);
            if (childBalance > 0)
            {
                node.Right = RightRotation(node.Right);
            }

            node = LeftRotation(node);
        }else if (balance > 1)
        {
            int childBalance = GetHeight(node.Left.Left) - GetHeight(node.Left.Right);
            if (childBalance < 0)
            {
                node.Left = LeftRotation(node.Left);
            }

            node = RightRotation(node);
        }

        return node;
    }

    private Node<T> LeftRotation(Node<T> node)
    {
        Node<T> temp = node.Right;
        node.Right = temp.Left;
        temp.Left = node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        temp.Height = 1 + Math.Max(GetHeight(temp.Left), GetHeight(temp.Right));

        return temp;
    }

    private Node<T> RightRotation(Node<T> node)
    {
        Node<T> temp = node.Left;
        node.Left = temp.Right;
        temp.Right = node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        temp.Height = 1 + Math.Max(GetHeight(temp.Right), GetHeight(temp.Left));

        return temp;
    }

    private int GetHeight(Node<T> node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Height;
    }

    private Node<T> Search(Node<T> node, T item)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            return Search(node.Left, item);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, item);
        }

        return node;
    }

    private void EachInOrder(Node<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }
}

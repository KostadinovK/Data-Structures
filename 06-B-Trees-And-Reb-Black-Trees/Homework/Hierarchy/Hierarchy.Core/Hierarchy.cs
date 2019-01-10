namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class Hierarchy<T> : IHierarchy<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public List<Node> Children { get; set; }
            public Node Parent { get; set; }

            public Node(T value, Node parent = null,params T[] children)
            {
                Value = value;
                Parent = parent;
                Children = new List<Node>();
                foreach (var child in children)
                {
                    Children.Add(new Node(child,this));
                }
            }
        }

        public Node Root { get; set; }

        public Hierarchy(T root)
        {
            Root = new Node(root);
        }

        public int Count
        {
            get { return GetCount(); }
        }

        private int GetCount()
        {
            if (Root == null)
            {
                return 0;
            }

            int count = 0;
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(Root);
            while (nodes.Count > 0)
            {
                Node current = nodes.Dequeue();
                count++;
                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return count;
        }

        public void Add(T element, T child)
        {
            if (!Contains(element))
            {
                throw new ArgumentException("Element not in Hierarchy!");
            }

            if (Contains(child))
            {
                throw new ArgumentException("No duplicates of child allowed!");
            }

            Node parent = GetNode(element);
            parent.Children.Add(new Node(child,parent));
        }

        private Node GetNode(T value)
        {
            Node res = null;

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(Root);
            while (nodes.Count > 0)
            {
                Node current = nodes.Dequeue();
                if (current.Value.Equals(value))
                {
                    res = current;
                    break;
                }

                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);

                }
            }
            return res;
        }

        public void Remove(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T item)
        {
            throw new NotImplementedException();
        }

        public T GetParent(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(Root);
            while (nodes.Count > 0)
            {
                Node current = nodes.Dequeue();
                if (current.Value.Equals(value))
                {
                    return true;
                }

                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return false;
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            throw new NotImplementedException();
        } 

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
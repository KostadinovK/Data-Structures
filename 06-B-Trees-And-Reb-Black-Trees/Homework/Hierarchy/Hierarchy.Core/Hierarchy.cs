using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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
            if (!Contains(element))
            {
                throw new ArgumentException("Element not in Hierarchy!");
            }

            Node toRemove = GetNode(element);
            if (toRemove == Root)
            {
                throw new InvalidOperationException("Cannot remove root!");
            }

            if (toRemove.Children.Count != 0)
            {
                foreach (var child in toRemove.Children)
                {
                    toRemove.Parent.Children.Add(child);
                    child.Parent = toRemove.Parent;
                }
            }

            toRemove.Parent.Children.Remove(toRemove);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!Contains(item))
            {
                throw new ArgumentException();
            }

            List<T> nodes = new List<T>();
            Node node = GetNode(item);

            return node.Children.Select(x => x.Value).ToList();
        }

        public T GetParent(T item)
        {
            if (!Contains(item))
            {
                throw new ArgumentException();
            }

            Node node = GetNode(item);

            if (node == Root)
            {
                return default(T);
            }

            return node.Parent.Value;
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
            List<Node> commonNodes = new List<Node>();

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(other.Root);

            while (nodes.Count > 0)
            {
                Node current = nodes.Dequeue();

                if (this.Contains(current.Value))
                {
                    commonNodes.Add(current);
                }

                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return commonNodes.Select(x => x.Value).ToList();
        } 

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(Root);

            while (nodes.Count > 0)
            {
                Node current = nodes.Dequeue();

                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);
                }

                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
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

        private Node root;
        private Dictionary<T, Node> valueNodesDic;

        public Hierarchy(T root)
        {
            this.root = new Node(root, new Node(default(T)));
            valueNodesDic = new Dictionary<T, Node>();
            valueNodesDic.Add(root,this.root);
        }

        public int Count
        {
            get { return valueNodesDic.Count; }
        }

        public void Add(T element, T child)
        {
            if (!valueNodesDic.ContainsKey(element))
            {
                throw new ArgumentException("Element not in Hierarchy!");
            }

            if (valueNodesDic.ContainsKey(child))
            {
                throw new ArgumentException("No duplicates of child allowed!");
            }
            valueNodesDic.Add(child,new Node(child,valueNodesDic[element]));
            valueNodesDic[element].Children.Add(valueNodesDic[child]);
        }

        public void Remove(T element)
        {
            if (!valueNodesDic.ContainsKey(element))
            {
                throw new ArgumentException("Element not in Hierarchy!");
            }
            
            if (valueNodesDic[element].Parent.Value.Equals(default(T)))
            {
                throw new InvalidOperationException("Cannot remove root!");
            }

            Node toRemove = valueNodesDic[element];
            toRemove.Parent.Children.Remove(toRemove);

            if (toRemove.Children.Count != 0)
            {
                toRemove.Parent.Children.AddRange(toRemove.Children);
                foreach (var child in toRemove.Children)
                {
                    child.Parent = toRemove.Parent;
                }
            }

            valueNodesDic.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!valueNodesDic.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            return valueNodesDic[item].Children.Select(x => x.Value).ToList();
        }

        public T GetParent(T item)
        {
            if (!valueNodesDic.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            return valueNodesDic[item].Parent.Value;
        }

        public bool Contains(T value)
        {
            return valueNodesDic.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            HashSet<T> h1 = new HashSet<T>(this.valueNodesDic.Keys);
            HashSet<T> h2 = new HashSet<T>(other.valueNodesDic.Keys);

            h1.IntersectWith(h2);

            return h1;
        } 

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);

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
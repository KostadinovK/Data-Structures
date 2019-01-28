using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int DefaultCapacity = 16;
    private const double LoadFactor = 0.7;

    private LinkedList<KeyValue<TKey, TValue>>[] elements;
    

    public int Count { get; private set; }

    public int Capacity
    {
        get { return elements.Length; }
    }

    public HashTable(int capacity = DefaultCapacity)
    {
        elements = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    public void Add(TKey key, TValue value)
    {
        GrowIfNeeded();
        int index = Math.Abs(key.GetHashCode()) % Capacity;

        if (elements[index] == null)
        {
            elements[index] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var kvp in elements[index])
        {
            if (kvp.Key.Equals(key))
            {
                throw new ArgumentException();
            }
        }

        elements[index].AddLast(new KeyValue<TKey, TValue>(key, value));
        Count++;
    }

    private void GrowIfNeeded()
    {
        double loadFactor = (this.Count + 1) / this.Capacity;
        if (loadFactor >= LoadFactor)
        {
            Grow();
        }
    }

    private void Grow()
    {
        HashTable<TKey, TValue> newTable = new HashTable<TKey, TValue>(this.Capacity * 2);

        foreach (var kvp in this)
        {
            newTable.Add(kvp.Key, kvp.Value);
        }

        this.Count = newTable.Count;
        this.elements = newTable.elements;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        GrowIfNeeded();

        int index = Math.Abs(key.GetHashCode()) % Capacity;

        if (elements[index] == null)
        {
            elements[index] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var kvp in elements[index])
        {
            if (kvp.Key.Equals(key))
            {
                kvp.Value = value;
                return false;
            }
        }

        elements[index].AddLast(new KeyValue<TKey, TValue>(key, value));
        Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        var kvp = Find(key);

        if (kvp == null)
        {
            throw new KeyNotFoundException();
        }

        return kvp.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
        }
        set
        {
            this.AddOrReplace(key,value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var kvp = Find(key);

        if (kvp == null)
        {
            value = default(TValue);
            return false;
        }

        value = kvp.Value;
        return true;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int index = Math.Abs(key.GetHashCode()) % Capacity;
        if (elements[index] == null)
        {
            return null;
        }

        foreach (var kvp in elements[index])
        {
            if (kvp.Key.Equals(key))
            {
                return kvp;
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var kvp = Find(key);

        return kvp != null;
    }

    public bool Remove(TKey key)
    {
        int index = Math.Abs(key.GetHashCode()) % Capacity;

        if (elements[index] == null)
        {
            return false;
        }

        KeyValue<TKey, TValue> toRemove = null;
        foreach (var kvp in elements[index])
        {
            if (kvp.Key.Equals(key))
            {
                toRemove = kvp;
            }
        }

        if (toRemove == null)
        {
            return false;
        }

        elements[index].Remove(toRemove);
        this.Count--;
        return true;
    }

    public void Clear()
    {
        this.elements = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            foreach (var list in elements.Where(x => x != null))
            {
                foreach (var kvp in list)
                {
                    yield return kvp.Key;
                }
            }
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            foreach (var list in elements.Where(x => x != null))
            {
                foreach (var kvp in list)
                {
                    yield return kvp.Value;
                }
            }
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var kvp in elements.Where(x => x != null))
        {
            foreach (var item in kvp)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

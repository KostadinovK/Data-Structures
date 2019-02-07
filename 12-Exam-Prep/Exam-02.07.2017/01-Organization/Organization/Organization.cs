using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Organization : IOrganization
{
    private List<Person> byIndex;
    private Dictionary<string, List<Person>> byName;
    private Dictionary<int, List<Person>> byNameLength;

    public Organization()
    {
        byIndex = new List<Person>();
        byName = new Dictionary<string, List<Person>>();
        byNameLength = new Dictionary<int, List<Person>>();
    }

    public int Count
    {
        get { return byIndex.Count; }
    }
    public bool Contains(Person person)
    {
        if (byName.ContainsKey(person.Name) && byName[person.Name].Contains(person))
        {
            return true;
        }

        return false;
    }

    public bool ContainsByName(string name)
    {
        if (byName.ContainsKey(name))
        {
            return true;
        }

        return false;
    }

    public void Add(Person person)
    {
        byIndex.Add(person);

        if (!byName.ContainsKey(person.Name))
        {
            byName[person.Name] = new List<Person>();
        }

        byName[person.Name].Add(person);

        if (!byNameLength.ContainsKey(person.Name.Length))
        {
            byNameLength[person.Name.Length] = new List<Person>();
        }

        byNameLength[person.Name.Length].Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if (index < 0 || index >= byIndex.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return byIndex[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        if (!byName.ContainsKey(name))
        {
            return new List<Person>();
        }

        return byName[name];
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        if (count < 1)
        {
            return new List<Person>();
        }

        if (count > Count)
        {
            return byIndex.GetRange(0, Count);
        }

        return byIndex.GetRange(0, count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        var result = byNameLength.Where(x => x.Key >= minLength && x.Key <= maxLength)
            .ToDictionary(x => x.Key, y => y.Value);

        List<Person> res = new List<Person>();

        foreach (var kvp in result)
        {
            res.AddRange(kvp.Value);
        }

        return res;
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!byNameLength.ContainsKey(length))
        {
            throw new ArgumentException();
        }

        return byNameLength[length];
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return byIndex;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in byIndex)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}
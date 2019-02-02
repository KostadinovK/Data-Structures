using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> byEmail;
    private Dictionary<string, SortedDictionary<string, Person>> byDomain;
    private Dictionary<string, SortedDictionary<string, Person>> byNameAndTown;
    private OrderedDictionary<int, SortedDictionary<string, Person>> byAge;
    private OrderedDictionary<int, Dictionary<string, SortedDictionary<string, Person>>> byAgeAndTown;


    public PersonCollection()
    {
        byEmail = new Dictionary<string, Person>();
        byDomain = new Dictionary<string, SortedDictionary<string, Person>>();
        byNameAndTown = new Dictionary<string, SortedDictionary<string, Person>>();
        byAge = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        byAgeAndTown = new OrderedDictionary<int, Dictionary<string, SortedDictionary<string, Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (byEmail.ContainsKey(email))
        {
            return false;
        }

        Person toAdd = new Person(email, name, age, town);

        byEmail.Add(email, toAdd);
        string domain = email.Split('@').ToArray()[1];

        if (!byDomain.ContainsKey(domain))
        {
            byDomain[domain] = new SortedDictionary<string, Person>();
        }

        byDomain[domain].Add(email, toAdd);

        if (!byNameAndTown.ContainsKey(name + " " + town))
        {
            byNameAndTown[name + " " + town] = new SortedDictionary<string, Person>();
        }

        byNameAndTown[name + " " + town].Add(email, toAdd);

        if (!byAge.ContainsKey(age))
        {
            byAge[age] = new SortedDictionary<string, Person>();
        }

        byAge[age].Add(email, toAdd);

        if (!byAgeAndTown.ContainsKey(age))
        {
            byAgeAndTown[age] = new Dictionary<string, SortedDictionary<string, Person>>();
        }

        if (!byAgeAndTown[age].ContainsKey(town))
        {
            byAgeAndTown[age][town] = new SortedDictionary<string, Person>();
        }

        byAgeAndTown[age][town].Add(email,toAdd);

        return true;
    }

    public int Count
    {
        get { return byEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        if (!byEmail.ContainsKey(email))
        {
            return null;
        }

        return byEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!byEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = byEmail[email];

        byEmail.Remove(email);

        string domain = email.Split('@').ToArray()[1];
        byDomain[domain].Remove(email);

        byNameAndTown[person.Name + " " + person.Town].Remove(email);
        byAge[person.Age].Remove(email);
        byAgeAndTown[person.Age][person.Town].Remove(email);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!byDomain.ContainsKey(emailDomain))
        {
            return new List<Person>();
        }

        return byDomain[emailDomain].Values;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        if (!byNameAndTown.ContainsKey(name + " " + town))
        {
            return new List<Person>();
        }

        return byNameAndTown[name + " " + town].Values;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        List<Person> result = new List<Person>();

        foreach (var kvp in byAge.Range(startAge,true,endAge,true).Values)
        {
            result.AddRange(kvp.Values);
        }

        return result;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        List<Person> result = new List<Person>();

        foreach (var kvp in byAgeAndTown.Range(startAge,true,endAge,true).Values)
        {
            foreach (var kvp2 in kvp.Values)
            {
                result.AddRange(kvp2.Values.Where(x => x.Town == town));
            }
        }

        return result;
    }
}

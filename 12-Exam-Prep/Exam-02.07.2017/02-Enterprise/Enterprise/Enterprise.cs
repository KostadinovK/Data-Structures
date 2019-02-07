using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enterprise : IEnterprise
{
    private Dictionary<Guid, Employee> byGuid;
   

    public Enterprise()
    {
        byGuid = new Dictionary<Guid, Employee>();
    }

    public int Count => byGuid.Count;

    public void Add(Employee employee)
    {
        if (!byGuid.ContainsKey(employee.Id))
        {
            byGuid.Add(employee.Id, employee);
        }

    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        var result = byGuid.Values.Where(x => x.Salary >= minSalary && x.Position.Equals(position));

        return result;
    }

    public bool Change(Guid guid, Employee employee)
    {
        if (!byGuid.ContainsKey(guid))
        {
            return false;
        }

        byGuid[guid] = employee;
       
        return true;
    }

    public bool Contains(Guid guid)
    {
        return byGuid.ContainsKey(guid);
    }

    public bool Contains(Employee employee)
    {
        return byGuid.ContainsKey(employee.Id);
    }

    public bool Fire(Guid guid)
    {
        if (!byGuid.ContainsKey(guid))
        {
            return false;
        }

        byGuid.Remove(guid);
        return true;
    }

    public Employee GetByGuid(Guid guid)
    {
        if (!byGuid.ContainsKey(guid))
        {
            throw new ArgumentException();
        }

        return byGuid[guid];
    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        var result = byGuid.Values.Where(x => x.Position.Equals(position));

        if (!result.Any())
        {
            throw new ArgumentException();
        }

        return result;
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        var result = byGuid.Values.Where(x => x.Salary >= minSalary);

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        var result = byGuid.Values.Where(x => x.Salary == salary && x.Position.Equals(position));

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    

    public Position PositionByGuid(Guid guid)
    {
        if (!byGuid.ContainsKey(guid))
        {
            throw new InvalidOperationException();
        }

        return byGuid[guid].Position;
    }

    public bool RaiseSalary(int months, int percent)
    {
        bool result = false;
        foreach (var kvp in byGuid)
        {
            if (kvp.Value.HireDate.AddMonths(months) <= DateTime.Now)
            {
                kvp.Value.Salary += kvp.Value.Salary * (percent / 100);
                result = true;
            }
        }

        return result;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        return byGuid.Values.Where(x => x.FirstName == firstName);
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        return byGuid.Values.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Position.Equals(position));
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        return byGuid.Values.Where(x => positions.Contains(x.Position));
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        return byGuid.Values.Where(x => x.Salary >= minSalary && x.Salary <= maxSalary);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        foreach (var kvp in byGuid)
        {
            yield return kvp.Value;
        }
    }
}


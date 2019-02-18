

using System;

public class Battlecard : IComparable<Battlecard>
{

    public int Id { get; private set; }
    public CardType Type { get; set; }
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double Swag { get; private set; }


    public Battlecard(int id, CardType type, string name, double damage, double swag)
    {
        this.Id = id;
        this.Type = type;
        this.Name = name;
        this.Damage = damage;
        this.Swag = swag;
    }

    public int CompareTo(Battlecard other)
    {
        int compare = other.Damage.CompareTo(this.Damage);

        if(compare == 0)
        {
            return this.Id.CompareTo(other.Id);
        }

        return compare;
    }
}
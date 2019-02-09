using System;

public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        Damage = damage;
        Distance = distance;
    }
    
    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        int compare = other.Distance.CompareTo(this.Distance);

        if (compare == 0)
        {
            compare = this.Damage.CompareTo(other.Damage);
        }

        return compare;
    }
}

using System;

public class Card
{

    public Card(string name, int damage, int score, int level)
    {
        this.Name = name;
        this.Damage = damage;
        this.Score = score;
        this.Level = level;
        this.Health = 20;
        this.Available = true;
    }

    public string Name { get; set; }

    public int Damage { get; set; }

    public int Score { get; set; }

    public int Health { get; set; }

    public int Level { get; set; }

    public bool Available { get; set; }

    public override bool Equals(object obj)
    {
        var item = obj as Card;

        return Name == item.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

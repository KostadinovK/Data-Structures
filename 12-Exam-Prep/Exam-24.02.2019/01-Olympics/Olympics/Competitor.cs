public class Competitor
{
    public Competitor(int id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.TotalScore = 0;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public long TotalScore { get; set; }

    public override bool Equals(object obj)
    {
        var item = obj as Competitor;

        return this.Id == item.Id && this.Name == item.Name;
    }
}

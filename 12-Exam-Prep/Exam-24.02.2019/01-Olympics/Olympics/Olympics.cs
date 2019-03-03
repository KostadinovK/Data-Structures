using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Olympics : IOlympics
{
    private Dictionary<int, Competitor> competitorsById;

    private Dictionary<int, Competition> competitionsById;


    public Olympics()
    {
        competitionsById = new Dictionary<int, Competition>();
        competitorsById = new Dictionary<int, Competitor>();
    }

    public void AddCompetitor(int id, string name)
    {
        if (competitorsById.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        Competitor c = new Competitor(id,name);

        competitorsById.Add(id, c);
    }

    public void AddCompetition(int id, string name, int score)
    {
        if (competitionsById.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        Competition c = new Competition(name, id, score);

        competitionsById.Add(id,c);
    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!competitionsById.ContainsKey(competitionId) || !competitorsById.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        Competitor c = competitorsById[competitorId];
        c.TotalScore += competitionsById[competitionId].Score;

        competitionsById[competitionId].Competitors.Add(c);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!competitionsById.ContainsKey(competitionId) || !competitorsById.ContainsKey(competitorId)
            || !competitionsById[competitionId].Competitors.Contains(competitorsById[competitorId]))
        {
            throw new ArgumentException();
        }
        competitorsById[competitorId].TotalScore -= competitionsById[competitionId].Score;

        competitionsById[competitionId].Competitors.Remove(competitorsById[competitorId]);
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        return competitorsById.Values.Where(x => x.TotalScore > min && x.TotalScore <= max).OrderBy(x => x.Id);
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        var result = competitorsById.Values.Where(x => x.Name == name).OrderBy(x => x.Id);

        if (!result.Any())
        {
            throw new ArgumentException();
        }

        return result;
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        return competitorsById.Values.Where(x => x.Name.Length >= min && x.Name.Length <= max).OrderBy(x => x.Id);
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        if (!competitionsById.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        return competitionsById[competitionId].Competitors.Contains(comp);
        
    }

    public int CompetitionsCount()
    {
        return competitionsById.Count;
    }

    public int CompetitorsCount()
    {
        return competitorsById.Count;
    }

    public Competition GetCompetition(int id)
    {
        if (!competitionsById.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return competitionsById[id];
    }
}
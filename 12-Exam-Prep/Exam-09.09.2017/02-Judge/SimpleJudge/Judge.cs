using System;
using System.Collections.Generic;
using System.Linq;

public class Judge : IJudge
{
    private HashSet<int> users;
    private HashSet<int> contests;
    private Dictionary<int, Submission> byId;

    public Judge()
    {
        users = new HashSet<int>();
        contests = new HashSet<int>();
        byId = new Dictionary<int, Submission>();
    }

    public void AddContest(int contestId)
    {
        if (!contests.Contains(contestId))
        {
            contests.Add(contestId);
        }

    }

    public void AddSubmission(Submission submission)
    {
        if (!users.Contains(submission.UserId))
        {
            throw new InvalidOperationException();
        }

        if (!contests.Contains(submission.ContestId))
        {
            throw new InvalidOperationException();
        }

        if (!byId.ContainsKey(submission.Id))
        {
            byId.Add(submission.Id, submission);
        }
        
    }

    public void AddUser(int userId)
    {
        if (!users.Contains(userId))
        {
            users.Add(userId);
        }
    }

    public void DeleteSubmission(int submissionId)
    {
        if (byId.ContainsKey(submissionId))
        {
            byId.Remove(submissionId);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return byId.Values.OrderBy(x => x.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return users.OrderBy(x => x);
    }

    public IEnumerable<int> GetContests()
    {
        return contests.OrderBy(x => x);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        var submissions = byId.Values.Where(x => x.Type == submissionType && x.Points >= minPoints && x.Points <= maxPoints);

        return submissions;
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        var submissions = byId.Values.Where(x => x.UserId == userId).OrderByDescending(x => x.Points).ThenBy(x => x.Id)
            .Select(x => x.ContestId).Distinct();

        return submissions;
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
      
        var submissions = byId.Values.Where(x => x.ContestId == contestId && x.UserId == userId && x.Points == points);

        if (!submissions.Any())
        {
            throw new InvalidOperationException();
        }

        return submissions;
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
 
        var submissions = byId.Values.Where(x => x.Type == submissionType).Select(x => x.ContestId).Distinct();

        return submissions;
    }
}

using System;
using System.Collections.Generic;

public class Judge : IJudge
{
    public void AddContest(int contestId)
    {
        throw new NotImplementedException();
    }

    public void AddSubmission(Submission submission)
    {
        throw new NotImplementedException();
    }

    public void AddUser(int userId)
    {
        throw new NotImplementedException();
    }

    public void DeleteSubmission(int submissionId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> GetUsers()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> GetContests()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        throw new NotImplementedException();
    }
}

class Job 
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void DisplayJobDescription()
    {
        string description = $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
        Console.WriteLine(description);
    }
}
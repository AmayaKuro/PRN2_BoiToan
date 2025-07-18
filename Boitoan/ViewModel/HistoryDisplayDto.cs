public class HistoryDisplayDto
{
    public string TestName { get; set; }
    public string UserName { get; set; }
    public string Result { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, int> AnswerCounts { get; set; }
}
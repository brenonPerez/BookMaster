namespace BookMaster.Domain.Entities;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Summary { get; set; } = string.Empty;
}

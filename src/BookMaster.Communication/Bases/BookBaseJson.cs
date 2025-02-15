﻿namespace BookMaster.Communication.Bases;
public class BookBaseJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int Year { get; set; }
    public string? Summary { get; set; } = string.Empty;
}

namespace ArdalisRating.Policies;

public class AutoPolicy : Policy
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Miles { get; set; }
    public decimal Deductible { get; set; }
}

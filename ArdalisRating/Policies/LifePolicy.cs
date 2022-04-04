using System;

namespace ArdalisRating.Policies;

public class LifePolicy : Policy
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsSmoker { get; set; }
    public decimal Amount { get; set; }
}

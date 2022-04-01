
using Xunit;

namespace ArdalisRating.Tests;

public class PolicySerializerTests
{
    [Fact]
    public void DeserializeJson_EmptyJson_ReturnsDefaultPolicy()
    {
        var json = "{}";
        var policySerializer = new PolicySerializer();

        var actual = policySerializer.DeserializeJson(json);
        var expected = new Policy();

        AssertPoliciesEqual(expected, actual);
    }

    private static void AssertPoliciesEqual(Policy expected, Policy actual)
    {
        Assert.Equal(actual.Address, expected.Address);
        Assert.Equal(actual.Amount, expected.Amount);
        Assert.Equal(actual.BondAmount, expected.BondAmount);
        Assert.Equal(actual.DateOfBirth, expected.DateOfBirth);
        Assert.Equal(actual.Deductible, expected.Deductible);
        Assert.Equal(actual.FullName, expected.FullName);
        Assert.Equal(actual.IsSmoker, expected.IsSmoker);
        Assert.Equal(actual.Make, expected.Make);
        Assert.Equal(actual.Miles, expected.Miles);
        Assert.Equal(actual.Model, expected.Model);
        Assert.Equal(actual.Type, expected.Type);
        Assert.Equal(actual.Valuation, expected.Valuation);
        Assert.Equal(actual.Year, expected.Year);
    }
}

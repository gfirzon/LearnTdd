namespace DecisioningEngineLib.UnitTests.Services;

public class CreditRulesServiceTests
{
    private readonly ICreditRulesService creditRulesService = null!;

    public CreditRulesServiceTests()
    {
        creditRulesService = new CreditRulesService();
    }

    [Theory]
    [InlineData(700, 35000, 35000)]
    [InlineData(620, 35000, 17500)]
    [InlineData(null, 35000, 10500)]
    public void GetLoanDecision_Should_Return_Valid_Decision_InlineDataDataVariation(int? score, decimal salary, decimal expectedQualifiedAmount)
    {
        // Arrange

        // Act
        decimal actualQualifiedAmount = creditRulesService.GetMaxQualifiedAmount(score, salary);

        // Asserts
        Assert.Equal(expectedQualifiedAmount, actualQualifiedAmount);
    }

    [Theory]
    [MemberData(nameof(GetScenarioData))]
    public void GetLoanDecision_Should_Return_Valid_Decision_MemberDataVariation(int? score, decimal salary, decimal expectedQualifiedAmount)
    {
        // Arrange

        // Act
        decimal actualQualifiedAmount = creditRulesService.GetMaxQualifiedAmount(score, salary);

        // Asserts
        Assert.Equal(expectedQualifiedAmount, actualQualifiedAmount);
    }

    public static IEnumerable<object[]> GetScenarioData()
    {
        yield return new object[] { 700, 35000, 35000 };
        yield return new object[] { 620, 35000, 17500 };
        yield return new object[] { null!, 35000, 10500 };
    }
}

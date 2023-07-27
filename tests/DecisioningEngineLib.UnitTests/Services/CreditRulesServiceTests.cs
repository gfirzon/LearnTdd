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
    [InlineData(null, 35000, 7000)]
    public void GetLoanDecision_Should_Return_Valid_Decision(int? score, decimal salary, decimal expectedQualifiedAmount)
    {
        // Arrange

        // Act
        decimal actualQualifiedAmount = creditRulesService.GetMaxQualifiedAmount(score, salary);

        // Asserts
        actualQualifiedAmount.Should().Be(expectedQualifiedAmount);
    }
}

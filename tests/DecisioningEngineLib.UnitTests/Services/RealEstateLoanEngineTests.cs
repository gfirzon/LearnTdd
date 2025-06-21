using DecisioningEngine.Models;
using DecisioningEngineLib.Models;

namespace DecisioningEngineLib.UnitTests.Services;

public class RealEstateLoanEngineTests
{
    private readonly RealEstateLoanEngine realEstateLoanEngine = null!;

    private readonly Mock<ICreditService> mockCreditService = null!;
    private readonly ICreditRulesService creditRulesService = null!;
    private readonly Mock<ILoanDecisionEngine> mockLoanDecisionEngine = null!;

    public RealEstateLoanEngineTests()
    {
        mockCreditService = new();
        creditRulesService = new CreditRulesService();
        mockLoanDecisionEngine = new();

        realEstateLoanEngine = new RealEstateLoanEngine(mockCreditService.Object,
            creditRulesService,
            mockLoanDecisionEngine.Object);

        SetDefaultMocks();
    }

    [Fact]
    public void GetLoanDecision_Should_Return_Valid_Decision()
    {
        // Arrange
        string ssn = "111-11-1111";
        decimal amountRequested = 30000.00M;
        decimal salary = 75000;

        CreditApplication creditApplication = new CreditApplication()
        {
            SSN = ssn,
            AmountRequested = amountRequested,
            CurrentSalary = salary
        };

        // Act
        var serviceResult = realEstateLoanEngine.GetLoanDecision(creditApplication);
        LoanDecision loanDecision = serviceResult.Data!;

        // Asserts
        Assert.True(loanDecision.IsApproved);
    }

    private void SetDefaultMocks()
    {
        mockCreditService.Setup(m => m.GetCreditScore(
            It.IsAny<string>()
            )).Returns(new CreditScoreResult
            {
                BureauAvailable = true,
                CreditScore = 720
            });

        mockLoanDecisionEngine.Setup(m => m.GetLoanDecision(
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<decimal>()
            )).Returns(new LoanDecision
            {
                AmountRequested = 100,
                BureauAvailable = true,
                IsApproved = true,
                MaxAmountQualified = 100,
                Reason = "some reason",
                SSN = "555-55-5555"
            });
    }
}

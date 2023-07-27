using DecisioningEngine.Models;
using DecisioningEngineLib.Services;
using Moq;

namespace DecisioningEngineLib.UnitTests.Services;

public class RealEstateLoanEngineTests
{
    private readonly RealEstateLoanEngine realEstateLoanEngine = null!;

    private readonly Mock<ICreditService> mockCreditService = null!;
    private readonly Mock<ICreditRulesService> mockCreditRulesService = null!;
    private readonly Mock<ILoanDecisionEngine> mockLoanDecisionEngine = null!;

    public RealEstateLoanEngineTests()
    {
        mockCreditService = new();
        mockCreditRulesService = new();
        mockLoanDecisionEngine = new();

        realEstateLoanEngine = new RealEstateLoanEngine(mockCreditService.Object,
            mockCreditRulesService.Object,
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
        LoanDecision loanDecision = realEstateLoanEngine.GetLoanDecision(creditApplication);

        // Asserts
    }

    private void SetDefaultMocks()
    {

    }
}

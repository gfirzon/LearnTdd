using DecisioningEngine.Models;
using DecisioningEngineLib.Services;

namespace DecisioningEngine.LocalIntegrationTests.Services;

public class RealEstateLoanEngineTests : IClassFixture<StartupContainer>
{
    private readonly IRealEstateLoanEngine realEstateLoanEngine = null!;

    public RealEstateLoanEngineTests(StartupContainer fixture)
    {
        ServiceProvider serviceProvider = fixture.ServiceProvider;
        realEstateLoanEngine = serviceProvider.GetService<IRealEstateLoanEngine>()!;
    }

    [Fact]
    public void IRealEstateLoanEngine_Should_Be_Provided_By_DI_ServiceProvider()
    {
        // Asserts
        realEstateLoanEngine.Should().NotBeNull();
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

        // Asserts
        LoanDecision loanDecision = serviceResult.Data!;
        loanDecision.IsApproved.Should().BeTrue();
    }
}

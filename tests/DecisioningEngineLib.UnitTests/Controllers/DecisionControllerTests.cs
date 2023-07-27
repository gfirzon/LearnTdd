using DecisioningEngine.Api.Controllers;
using DecisioningEngine.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecisioningEngineLib.UnitTests.Controllers;

public class DecisionControllerTests
{
    private readonly DecisionController decisionController = null!;

    private readonly Mock<IRealEstateLoanEngine> mockRealEstateLoanEngine = null!;

    public DecisionControllerTests()
    {
        mockRealEstateLoanEngine = new();

        decisionController = new DecisionController(mockRealEstateLoanEngine.Object);
    }

    [Fact]
    public void Post_Should_Return_Valid_Decision()
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

        mockRealEstateLoanEngine.Setup(m => m.GetLoanDecision(
            It.IsAny<CreditApplication>()
            )).Returns(new LoanDecision
            {
                IsApproved = true,
                AmountRequested = 4000,
                BureauAvailable = true,
                MaxAmountQualified = 1000,
                SSN = ssn,
                Reason = "some reason"
            });

        // Act
        IActionResult actionResult = decisionController.Post(creditApplication);

        // Asserts
        var actualResult = actionResult.As<OkObjectResult>();
        LoanDecision loanDecision = actualResult.Value.As<LoanDecision>();

        loanDecision.IsApproved.Should().BeTrue();
    }
}

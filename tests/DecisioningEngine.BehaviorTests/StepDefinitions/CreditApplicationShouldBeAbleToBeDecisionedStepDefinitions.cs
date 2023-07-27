using DecisioningEngine.Models;
using DecisioningEngineLib.Services;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DecisioningEngine.BehaviorTests.StepDefinitions
{
    [Binding]
    public class CreditApplicationShouldBeAbleToBeDecisionedStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext = null!;
        private readonly IRealEstateLoanEngine _realEstateLoanEngine = null!;

        public CreditApplicationShouldBeAbleToBeDecisionedStepDefinitions(
            ScenarioContext scenarioContext,
            IRealEstateLoanEngine realEstateLoanEngine)
        {
            _scenarioContext = scenarioContext;
            _realEstateLoanEngine = realEstateLoanEngine;
        }

        [Given(@"Credit Application is submitted")]
        public void GivenCreditApplicationIsSubmitted()
        {
            string ssn = "111-11-1111";
            decimal amountRequested = 30000.00M;
            decimal salary = 75000;

            CreditApplication creditApplication = new CreditApplication()
            {
                SSN = ssn,
                AmountRequested = amountRequested,
                CurrentSalary = salary
            };

            _scenarioContext["CreditApplication"] = creditApplication;
        }

        [When(@"Credit Application is decisioned")]
        public void WhenCreditApplicationIsDecisioned()
        {
            bool valueExists = _scenarioContext.TryGetValue("CreditApplication", out CreditApplication creditApplication);
            valueExists.Should().BeTrue();

            LoanDecision loanDecision = _realEstateLoanEngine.GetLoanDecision(creditApplication);
            // your call to check or not here, we can talk about it
            loanDecision.Should().NotBeNull();

            _scenarioContext["loanDecision"] = loanDecision;
        }

        [Then(@"decision is to approve")]
        public void ThenDecisionIsToApprove()
        {
            bool valueExists = _scenarioContext.TryGetValue("loanDecision", out LoanDecision loanDecision);
            valueExists.Should().BeTrue();

            loanDecision.IsApproved.Should().BeTrue();
        }
    }
}

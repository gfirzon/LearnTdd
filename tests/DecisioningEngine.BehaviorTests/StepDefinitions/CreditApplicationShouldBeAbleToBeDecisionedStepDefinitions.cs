using DecisioningEngine.Models;
using System;
using TechTalk.SpecFlow;

namespace DecisioningEngine.BehaviorTests.StepDefinitions
{
    [Binding]
    public class CreditApplicationShouldBeAbleToBeDecisionedStepDefinitions
    {
        private readonly ScenarioContext scenarioContext = null!;

        public CreditApplicationShouldBeAbleToBeDecisionedStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
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

            scenarioContext["CreditApplication"] = creditApplication;

            throw new PendingStepException();
        }
    }
}

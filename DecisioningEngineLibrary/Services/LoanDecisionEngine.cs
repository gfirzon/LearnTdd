using DecisioningEngine.Models;

namespace DecisioningEngine.Services
{
    public class LoanDecisionEngine
    {
        public LoanDecision GetLoanDecision(string ssn, decimal requestedAmount, decimal maxAmountQualified)
        {
            LoanDecision loanDecision = new LoanDecision
            {
                SSN = ssn,
                IsApproved = requestedAmount <= maxAmountQualified,
                MaxAmountQualified = maxAmountQualified,
                AmountRequested = requestedAmount,
                Reason = requestedAmount <= maxAmountQualified ? "OK" : "Requested amount greater than qualified amount",
            };

            return loanDecision;
        }
    }
}

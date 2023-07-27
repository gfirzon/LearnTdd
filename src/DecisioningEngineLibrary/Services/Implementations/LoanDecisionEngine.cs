using DecisioningEngine.Models;

namespace DecisioningEngineLib.Services;

public class LoanDecisionEngine : ILoanDecisionEngine
{
    /// <summary>
    /// Generate application decision
    /// </summary>
    /// <param name="ssn"></param>
    /// <param name="requestedAmount"></param>
    /// <param name="maxAmountQualified"></param>
    /// <returns></returns>
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

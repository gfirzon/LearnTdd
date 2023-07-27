using DecisioningEngine.Models;

namespace DecisioningEngineLib.Services
{
    public interface ILoanDecisionEngine
    {
        LoanDecision GetLoanDecision(string ssn, decimal requestedAmount, decimal maxAmountQualified);
    }
}
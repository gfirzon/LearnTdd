using DecisioningEngine.Models;

namespace DecisioningEngineLib.Services
{
    public interface IRealEstateLoanEngine
    {
        LoanDecision GetLoanDecision(CreditApplication creditApplication);
    }
}
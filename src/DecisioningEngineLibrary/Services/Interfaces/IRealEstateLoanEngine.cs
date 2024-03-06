using DecisioningEngine.Models;

namespace DecisioningEngineLib.Services;

public interface IRealEstateLoanEngine
{
    ServiceResult<LoanDecision> GetLoanDecision(CreditApplication creditApplication);
}
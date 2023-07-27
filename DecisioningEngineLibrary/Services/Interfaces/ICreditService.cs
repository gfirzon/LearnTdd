using DecisioningEngineLib.Models;

namespace DecisioningEngineLib.Services
{
    public interface ICreditService
    {
        CreditScoreResult GetCreditScore(string ssn);
    }
}
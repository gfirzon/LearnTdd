using DecisioningEngine.Models;

namespace DecisioningEngineLib.Services
{
    public interface ICreditPullingService
    {
        CreditBureauInfoItem GetCreditData(string ssn);
    }
}
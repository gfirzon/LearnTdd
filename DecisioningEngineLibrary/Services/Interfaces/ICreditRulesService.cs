namespace DecisioningEngineLib.Services
{
    public interface ICreditRulesService
    {
        decimal GetMaxQualifiedAmount(int? score, decimal salary);
    }
}
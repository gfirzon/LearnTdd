using DecisioningEngineLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DecisioningEngineLib;

public static class ServiceRegistrar
{
    public static IServiceCollection AddDecisioningServices(this IServiceCollection services)
    {
        services.AddTransient<ICreditPullingService, CreditPullingService>();
        services.AddTransient<ICreditService, CreditService>();
        services.AddTransient<ICreditRulesService, CreditRulesService>();
        services.AddTransient<ILoanDecisionEngine, LoanDecisionEngine>();
        services.AddTransient<IRealEstateLoanEngine, RealEstateLoanEngine>();

        return services;
    }
}

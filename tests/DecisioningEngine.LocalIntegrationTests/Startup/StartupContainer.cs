using DecisioningEngineLib;

namespace DecisioningEngine.LocalIntegrationTests.Startup;

public class StartupContainer : IDisposable
{
    private ServiceProvider serviceProvider = null!;
    public ServiceProvider ServiceProvider => serviceProvider;

    public StartupContainer()
    {
        var serviceCollection = CreateServices();

        serviceCollection.AddDecisioningServices();

        serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private IServiceCollection CreateServices()
    {
        IServiceCollection services = null!;

        services = new ServiceCollection();

        return services;
    }

    /// <summary>
    /// Put code here to clean up test scenarios
    /// </summary>
    public void Dispose()
    {
        
    }
}

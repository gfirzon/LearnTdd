﻿using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace ComponentTests.Hooks;

public class TestingServices
{
    private static IServiceCollection? services = null;

    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Do not rebuild for each scenario.
        return services;
    }
}
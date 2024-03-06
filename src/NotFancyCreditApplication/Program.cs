// https://github.com/gfirzon/LearnTDD.git

using DecisioningEngine.Models;
using DecisioningEngineLib.Services;
using Microsoft.Extensions.DependencyInjection;

static ServiceProvider CreateServices()
{
    var services = new ServiceCollection();

    // configuration
    services.AddTransient<ICreditPullingService, CreditPullingService>();
    services.AddTransient<ICreditService, CreditService>();
    services.AddTransient<ICreditRulesService, CreditRulesService>();
    services.AddTransient<ILoanDecisionEngine, LoanDecisionEngine>();
    services.AddTransient<IRealEstateLoanEngine, RealEstateLoanEngine>();

    var serviceProvider = services.BuildServiceProvider();

    return serviceProvider;
}

//---------------------------------------------------
// create the credit application
//---------------------------------------------------
string ssn = "111-11-1111";
decimal amountRequested = 30000.00M;
decimal salary = 75000;

CreditApplication creditApplication = new CreditApplication
{
    SSN = ssn,
    AmountRequested = amountRequested,
    CurrentSalary = salary
};

//---------------------------------------------------
// get the application decision
//---------------------------------------------------

ServiceProvider serviceProvider = CreateServices();

IRealEstateLoanEngine? loanEngine = serviceProvider.GetService<IRealEstateLoanEngine>();

var serviceResult = loanEngine.GetLoanDecision(creditApplication);
LoanDecision decision = serviceResult.Data!;
//---------------------------------------------------
// display results
//---------------------------------------------------

Console.WriteLine(new string('▓', 50));
Console.WriteLine($"Credit decision for applicant {decision.SSN}");

Console.Write($"Approval status: ");
Console.ForegroundColor = decision.IsApproved ? ConsoleColor.Green : ConsoleColor.Yellow;
Console.WriteLine($"{(decision.IsApproved ? "Approved" : "Not Approved")}");
Console.ForegroundColor = ConsoleColor.Gray;

Console.WriteLine($"Reason: {decision.Reason}");
Console.WriteLine($"Max amount qualified: {decision.MaxAmountQualified:C}");
Console.WriteLine($"Amount requested: {decision.AmountRequested:C}");

Console.ForegroundColor = decision.BureauAvailable ? ConsoleColor.Green : ConsoleColor.Yellow;
Console.WriteLine($"{(decision.BureauAvailable ? "Bureau pull returned data" : "Bureau pull did not return data")}");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine(new string('▓', 50));

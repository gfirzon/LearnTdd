using DecisioningEngine.Models;
using DecisioningEngineLib.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecisioningEngine.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DecisionController : ControllerBase
{
    private readonly IRealEstateLoanEngine _realEstateLoanEngine = null!;

    public DecisionController(IRealEstateLoanEngine realEstateLoanEngine)
    {
        _realEstateLoanEngine = realEstateLoanEngine;
    }

    [HttpPost] 
    public IActionResult Post(CreditApplication creditApplication)
    {
        IActionResult actionResult = null!;

        LoanDecision loanDecision = _realEstateLoanEngine.GetLoanDecision(creditApplication);

        actionResult = Ok(loanDecision);

        return actionResult;
    }
}

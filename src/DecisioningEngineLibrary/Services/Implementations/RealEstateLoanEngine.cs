using DecisioningEngine.Models;
using DecisioningEngineLib.Models;

namespace DecisioningEngineLib.Services;

public class RealEstateLoanEngine : IRealEstateLoanEngine
{
    private readonly ICreditService _creditService = null;
    private readonly ICreditRulesService _creditRulesService = null;
    private readonly ILoanDecisionEngine _loanDecisionEngine = null;

    public RealEstateLoanEngine(ICreditService creditService,
                ICreditRulesService creditRulesService,
                ILoanDecisionEngine loanDecisionEngine)
    {
        _creditService = creditService;
        _creditRulesService = creditRulesService;
        _loanDecisionEngine = loanDecisionEngine;
    }

    /// <summary>
    /// Get Loan decision based on credit application and credit bureau information
    /// </summary>
    /// <param name="creditApplication"></param>
    /// <returns></returns>
    public LoanDecision GetLoanDecision(CreditApplication creditApplication)
    {
        CreditScoreResult creditScoreResult = _creditService.GetCreditScore(creditApplication.SSN);

        decimal maxQualifiedAmount = _creditRulesService.GetMaxQualifiedAmount(creditScoreResult.CreditScore, creditApplication.CurrentSalary);

        LoanDecision loanDecision = _loanDecisionEngine.GetLoanDecision(creditApplication.SSN, creditApplication.AmountRequested, maxQualifiedAmount);

        loanDecision.BureauAvailable = creditScoreResult.BureauAvailable;

        return loanDecision;
    }
}
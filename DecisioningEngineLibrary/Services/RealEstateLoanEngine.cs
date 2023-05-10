using DecisioningEngine.Models;
using DecisioningEngineLib.Models;

namespace DecisioningEngine.Services
{
    public class RealEstateLoanEngine
    {
        private readonly CreditService _creditService = null;
        private readonly CreditRulesService _creditRulesService = null;
        private readonly LoanDecisionEngine _loanDecisionEngine = null;
      
        public RealEstateLoanEngine(CreditService creditService,
                    CreditRulesService creditRulesService,
                    LoanDecisionEngine loanDecisionEngine)
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
}
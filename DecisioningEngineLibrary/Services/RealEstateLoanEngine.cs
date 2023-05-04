using DecisioningEngine.Models;
using DecisioningEngineLib.Models;

namespace DecisioningEngine.Services
{
    public class RealEstateLoanEngine
    {
        /// <summary>
        /// Get Loan decision based on credit application and credit bureau information
        /// </summary>
        /// <param name="creditApplication"></param>
        /// <returns></returns>
        public LoanDecision GetLoanDecision(CreditApplication creditApplication)
        {
            CreditService creditService = new CreditService();
            CreditScoreResult creditScoreResult = creditService.GetCreditScore(creditApplication.SSN);

            CreditRulesService creditRulesService = new CreditRulesService();
            decimal maxQualifiedAmount = creditRulesService.GetMaxQualifiedAmount(creditScoreResult.CreditScore, creditApplication.CurrentSalary);

            LoanDecisionEngine loanDecisionEngine = new LoanDecisionEngine();
            LoanDecision loanDecision = loanDecisionEngine.GetLoanDecision(creditApplication.SSN, creditApplication.AmountRequested, maxQualifiedAmount);

            loanDecision.BureauAvailable = creditScoreResult.BureauAvailable;

            return loanDecision;
        }
    }
}
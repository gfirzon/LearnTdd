using DecisioningEngine.Models;
using DecisioningEngineLib.Models;

namespace DecisioningEngine.Services
{
    public class CreditService
    {
        /// <summary>
        /// Obtain credit score on the applicant based on SSN
        /// </summary>
        /// <param name="ssn">Applicant's SSN</param>
        /// <returns>credit score and fact of bureau availability </returns>
        public CreditScoreResult GetCreditScore(string ssn)
        {
            CreditPullingService creditPullingService = new CreditPullingService();
            CreditBureauInfoItem pulledCredit = creditPullingService.GetCreditData(ssn);

            CreditScoreResult creditScoreResult = new CreditScoreResult
            {
                CreditScore = pulledCredit is not null
                ? pulledCredit.Score
                : null,
                BureauAvailable = pulledCredit is not null
            };

            return creditScoreResult;
        }
    }
}

using DecisioningEngine.Models;
using DecisioningEngineLib.Models;

namespace DecisioningEngineLib.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditPullingService _creditPullingService = null;

        public CreditService(ICreditPullingService creditPullingService)
        {
            _creditPullingService = creditPullingService;
        }

        /// <summary>
        /// Obtain credit score on the applicant based on SSN
        /// </summary>
        /// <param name="ssn">Applicant's SSN</param>
        /// <returns>credit score and fact of bureau availability </returns>
        public CreditScoreResult GetCreditScore(string ssn)
        {
            CreditBureauInfoItem pulledCredit = _creditPullingService.GetCreditData(ssn);

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

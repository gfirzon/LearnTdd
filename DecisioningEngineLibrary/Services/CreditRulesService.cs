namespace DecisioningEngine.Services
{
    public class CreditRulesService
    {
        /// <summary>
        /// Get Maximum qualified amount based on credit score and applicant's salary
        /// </summary>
        /// <param name="score">Applicant's credit score</param>
        /// <param name="salary">Applicant's salary</param>
        /// <returns>Maximum amount applicant is qualified</returns>
        public decimal GetMaxQualifiedAmount(int? score, decimal salary)
        {
            decimal maxAmount = 0;

            if (score.HasValue == false)
            {
                maxAmount = salary * 200 / 100;
            }
            else
            {
                if (score.Value < 700)
                {
                    maxAmount = salary;
                }
                else if (score.Value >= 700)
                {
                    maxAmount = salary;
                }
            }

            return maxAmount;
        }
    }
}

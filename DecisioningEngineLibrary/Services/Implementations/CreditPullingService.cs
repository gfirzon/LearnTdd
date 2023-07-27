using DecisioningEngine.Models;
using System.Text.Json;

namespace DecisioningEngineLib.Services
{
    public class CreditPullingService : ICreditPullingService
    {
        private readonly string dataDir = null;

        public CreditPullingService()
        {
            dataDir = Path.Combine(Environment.CurrentDirectory, "data");
        }

        /// <summary>
        /// Pulls outside sources for credit information on the applicant
        /// </summary>
        /// <param name="ssn">Applicant's SSN</param>
        /// <returns>Complete information on applicant</returns>
        public CreditBureauInfoItem GetCreditData(string ssn)
        {
            string fileName = "creditBureau.json";
            string filePath = Path.Combine(dataDir, fileName);

            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var list = JsonSerializer.Deserialize<List<CreditBureauInfoItem>>(json, options);

            return list.FirstOrDefault(m => m.SSN.Equals(ssn));
        }
    }
}

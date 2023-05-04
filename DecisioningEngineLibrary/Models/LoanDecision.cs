namespace DecisioningEngine.Models
{
    public class LoanDecision
    {
        public string SSN { get; set; }
        public bool IsApproved { get; set; }
        public decimal MaxAmountQualified { get; set; }
        public decimal AmountRequested { get; set; }
        public string Reason { get; set; }
        public bool BureauAvailable { get; set; }
    }
}

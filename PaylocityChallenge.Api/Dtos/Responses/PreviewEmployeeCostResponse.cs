namespace PaylocityChallenge.Api.Dtos.Responses
{
    public class PreviewEmployeeCostsResponse
    {
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal GrossPerPaycheck { get; set; }
        public decimal NetPerPaycheck { get; set; }
        public decimal BenefitsCostAnnual { get; set; }
        public decimal BenefitsCostPerPaycheck { get; set; }
    }
}

using PaylocityChallenge.Api.Dtos.Partial;

namespace PaylocityChallenge.Api.Dtos.Responses
{
    public class PreviewEmployeeCostsResponse
    {
        public EmployeePayDto AnnualPay { get; set; }
        public EmployeePayDto PaycheckPay { get; set; }
    }
}

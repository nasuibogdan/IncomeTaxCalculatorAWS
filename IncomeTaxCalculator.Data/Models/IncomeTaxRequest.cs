namespace IncomeTaxCalculator.Data.Models
{
    public class IncomeTaxRequest
    {
        public decimal Income { get; set; }

        public bool Detailed { get; set; } = false;
    }
}

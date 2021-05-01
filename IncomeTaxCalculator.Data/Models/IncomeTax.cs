using System;
using System.Collections.Generic;

#nullable disable

namespace IncomeTaxCalculator.Data.Models
{
    public partial class IncomeTax
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
    }
}

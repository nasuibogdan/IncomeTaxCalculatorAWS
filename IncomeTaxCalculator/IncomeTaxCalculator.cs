
using Amazon.Lambda.Core;
using IncomeTaxCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IncomeTaxCalculator
{
    public class IncomeTaxCalculator

    {
        public List<decimal> IncomeTaxCalculatorHandler(IncomeTaxRequest request, ILambdaContext context)
        {
            if(request.Income < 0)
            {
                throw new ArgumentException("Income value must not be null.");
            }

            var calculatedIncomeTaxes = new List<decimal>();

            using(var dbContext = new IncomeTaxDbContext())
            {
                foreach(var incomeTax in dbContext.IncomeTaxes)
                {
                    if(request.Income > incomeTax.UpperLimit
                        && incomeTax.UpperLimit > 0)
                    {
                        var tax = ((incomeTax.UpperLimit - incomeTax.LowerLimit) * incomeTax.Percentage) / 100;
                        calculatedIncomeTaxes.Add(Math.Round(tax, 2));
                    }

                    if(request.Income > incomeTax.LowerLimit
                        && ((request.Income <= incomeTax.UpperLimit && incomeTax.UpperLimit > 0) || incomeTax.UpperLimit == 0))
                    {
                        var tax = ((request.Income - incomeTax.LowerLimit) * incomeTax.Percentage) / 100;
                        calculatedIncomeTaxes.Add(Math.Round(tax, 2));
                    }
                }
            }

            return request.Detailed ? calculatedIncomeTaxes : new List<decimal> { Math.Round(calculatedIncomeTaxes.Sum(), 2) };
        }
    }
}

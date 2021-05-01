using Xunit;
using Amazon.Lambda.TestUtilities;
using System;
using System.Linq;

namespace IncomeTaxCalculator.Tests
{
    public class IncomeTaxCalculatorTest
    {
        private IncomeTaxCalculator function;
        private TestLambdaContext context;

        public IncomeTaxCalculatorTest()
        {
            function = new IncomeTaxCalculator();
            context = new TestLambdaContext();
        }

        [Theory]
        [InlineData(5000, 0)]
        [InlineData(12500, 0)]
        [InlineData(45000, 6500)]
        [InlineData(50000, 7500)]
        [InlineData(52000, 8300)]
        [InlineData(200000, 70000)]
        public void Test_That_IncomeTax_Calculator_Valid_Input_Returns_Expected_Result(decimal input, decimal output)
        {
            //Act
            var incomeTax = function.IncomeTaxCalculatorHandler(input, context);

            //Assert
            Assert.Equal(output, incomeTax.Sum());
        }

        [Fact]
        public void Test_That_IncomeTax_Calculator_Valid_Input_Returns_Expected_Result_As_Detailed()
        {
            //Act
            var incomeTax = function.IncomeTaxCalculatorHandler(52000, context, true);

            //Assert
            Assert.Equal(3, incomeTax.Count);
        }

        [Fact]
        public void Test_That_IncomeTax_Calculator_Invalid_Input_Throws_Exception()
        {
            //Act & Assert
            Assert.Throws<ArgumentException>(() => function.IncomeTaxCalculatorHandler(-4, context));
        }
    }
}

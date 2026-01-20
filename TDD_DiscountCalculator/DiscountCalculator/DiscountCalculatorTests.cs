using DiscountCalculatorPr;
namespace DiscountCalculatorXUnit
{

    /**
     * Sample Requirements:
        A higher sales amount results in a higher discount.
        The discount percentage should be determined based on predefined ranges:
            Sales amount below 100: 0% discount
            Sales amount between 100 and 500: 10% discount
            Sales amount between 500 and 1000: 20% discount
            Sales amount above 1000: 30% discount
    
    Calculate the final price based on the discount percentage.

     * */

    // Sales amount below 100: 0% discount
    public class DiscountCalculatorTests
    {
        [Fact]
        public void salesBelow100ShouldHave_0_Discount()
        {
            // Arrange

            var discCalc = new DiscountCalculator();
            decimal salesAmount = 50;


            // Act

            var finalPrice = discCalc.CalculateTheFinalPrice(salesAmount);

            // Assert

            Assert.Equal(50, finalPrice);
        }


        // Sales amount between 100 and 500: 10% discount

        [Fact]

        public void salesBetween100And500ShouldHave_10Percent_Discount()
        {
            // Arrange

            var discCalc = new DiscountCalculator();
            decimal salesAmount = 250;


            // Act

            var finalPrice = discCalc.CalculateTheFinalPrice(salesAmount);

            // Assert

            Assert.Equal(225, finalPrice);

        }
    }
}
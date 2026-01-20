namespace DiscountCalculatorPr
{
    public class DiscountCalculator
    {
        public decimal CalculateTheFinalPrice(decimal salesAmount)
        {
            decimal discountPercentage = GetDiscountPercentage(salesAmount);
            decimal discountAmount = salesAmount * discountPercentage / 100;
            decimal finalPrice = salesAmount - discountAmount;
            return finalPrice;
        }

        public decimal GetDiscountPercentage(decimal salesAmount)
        {
            if (salesAmount < 100)
            {
                return 0;
            }
            if (salesAmount >= 100 && salesAmount < 500)
            {
                return 10;
            }

            
            else if (salesAmount >= 500 && salesAmount < 1000)
            {
                return 20;
            }
            else // salesAmount >= 1000
            {
                return 30;
            }
            
        }
        

    }
}

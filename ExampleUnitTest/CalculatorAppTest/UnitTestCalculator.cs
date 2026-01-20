using ExampleCalculator;



namespace CalculatorAppTest
{
    public class UnitTestCalculator
    {
        [Fact]
        public void verify_Addition_of_TwoNumbers0()
        {
            // Arrange- intitalize variables and objects- set up the preconditions or the initial state for your test.
            int a = 5;
            int b = 10;
            var cal = new Calculator();

            //Act

            var result = cal.AddTwoNumbers(a, b);

            //Assert

            Assert.Equal(15, result);

        }


        [Fact]

        public void verify_Addition_of_TwoNumbers1()
        {
            // Arrange- intitalize variables and objects- set up the preconditions or the initial state for your test.
            int a = 51;
            int b = 11;
            var cal = new Calculator();

            //Act

            var result = cal.AddTwoNumbers(a, b);

            //Assert

            Assert.Equal(62, result);

        }


        [Theory]
        [InlineData(5, 10, 15)]
        [InlineData(20, 30, 50)]
        [InlineData(100, 200, 300)]
        [InlineData(-5, 5, 0)]

        public void verify_Addition_of_TwoNumbers_Theory(int a, int b, int expectedResult)
        {
            //arrange

            var cal = new Calculator();

            //act

            var result = cal.AddTwoNumbers(a, b);
            //assert

            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(50, 20, 30)]
        [InlineData(200, 100, 100)]

        public void verify_Subtraction_of_TwoNumbers_Theory(int a, int b, int expectedResult)
        {
            //arrange
            var cal = new Calculator();
            //act
            var result = cal.SubtractTwoNumbers(a, b);
            //assert
            Assert.Equal(expectedResult, result);

        }
    }
}
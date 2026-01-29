using FluentAssertions;
using OOPsReview;
using System.Runtime.Intrinsics.X86;
{
    
}
namespace TestPerson
{

    #region Constructors
    public class Person_Should
    {
        [Fact]
        public void Create_An_Instance_Using_the_Default_Constructor()
        {
            //Arrange- initialize variables and objects needed in the test

            // test variables- so you can use expected as prefix

            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";



            //Act - perform the functionality being tested
            // sut- subject under test

            Person sut = new Person();


            //Assert

            // Using FluentAssertions library for assertions

            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count.Should().Be(0);

            // Assert.Equal(expectedFirstName, sut.FirstName);
            // Assert.Equal(expectedLastName, sut.LastName);


        }

        [Fact]
        public void Create_An_Instance_Using_the_Greedy_Constructor()
        {
            // Arrange- initialize variables and objects needed in the test
            // test variables- so you can use expected as prefix
            string expectedFirstName = "Baljeet";
            string expectedLastName = "Kaur";
            ResidentAddress expectedAddress = new ResidentAddress(222, "oak street", "Edmonton", "AB", "T5T2Y5");
            Employment one = new Employment("PG-1", SupervisoryLevel.TeamMember, DateTime.Parse("2014/10/04"), 6.4);
            Employment two = new Employment("PG-2", SupervisoryLevel.TeamLeader, DateTime.Parse("2015/10/04"), 5.4);

            List<Employment> employmentPositions = new List<Employment>();
            employmentPositions.Add(one);
            employmentPositions.Add(two);
            int expectedEmploymentCount = employmentPositions.Count;


            //Act - perform the functionality being tested

            Person sut = new Person(expectedFirstName, expectedLastName, expectedAddress, employmentPositions);

            //Assert

            Assert.Equal(expectedFirstName, sut.FirstName);
            Assert.Equal(expectedLastName, sut.LastName);
            Assert.Equal(expectedAddress, sut.Address);
            Assert.Equal(expectedEmploymentCount, sut.EmploymentPositions.Count);

        }


        [Fact]

        public void Retun_The_Full_Name()
        {
            // Arrange - initialize variables and objects needed in the test
            string expectedFullName = "Kaur, Baljeet";
            ResidentAddress expectedAddress = new ResidentAddress(222, "oak street", "Edmonton", "AB", "T5T2Y5");
            Employment one = new Employment("PG-1", SupervisoryLevel.TeamMember, DateTime.Parse("2014/10/04"), 6.4);
            Employment two = new Employment("PG-2", SupervisoryLevel.TeamLeader, DateTime.Parse("2015/10/04"), 5.4);

            List<Employment> employmentPositions = new List<Employment>();
            employmentPositions.Add(one);
            employmentPositions.Add(two);
            int expectedEmploymentCount = employmentPositions.Count;


            // Act - perform the functionality being tested

            Person sut = new Person("Baljeet", "Kaur", expectedAddress, employmentPositions);
            string fullName = sut.FullName;

            // Assert

            sut.Address.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentCount);
            sut.FullName.Should().Be(expectedFullName);

    }


        #endregion

        #region Invalid Valid tests
        //the second test annotation used is called [Theory]
        //it will execute n number of times as a loop
        //n is determind by the number [InlineData()] annotations following the [Theory]
        //to setup the test header, you must include a parameter in a parameter list
        //  one for each value in the InlineData set of values
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_Creating_Instance_Missing_FirstName(string testvalue)
        {
            //Arrange
            //for this test, no instance is expected to be created.
            //because the firstname is invalid, an exception is to be thrown
            //  thus, no instance to be created to be tested


            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person(testvalue, "Welch", null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Exception_Creating_Instance_Missing_LastName(string testvalue)
        {
            //Arrange
            //for this test, no instance is expected to be created.
            //because the firstname is invalid, an exception is to be thrown
            //  thus, no instance to be created to be tested


            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person("Don", testvalue, null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion


        //directly change the firstname via property (character string exists)
        [Fact]
        public void Directly_Change_First_Name_Via_Property()
        {

            // arrange

            string expectedFirstName = "Kirat";
            //since we are trying to use the property of an instance.
            //  one needs to have an instance in the first place.
            Person sut = new Person("Baljeet", "Kaur", null, null);

            // act


            sut.FirstName = expectedFirstName;


            // assert

            sut.FirstName.Should().Be(expectedFirstName);
        }

        //directly change the Lasttname via property (character string exists)
        [Fact]
        public void Directly_Change_Last_Name_Via_Property() {

            // arrange

            string expectedLastName = "Rayat";
            //since we are trying to use the property of an instance.
            //  one needs to have an instance in the first place.
            Person sut = new Person("Baljeet", "Kaur", null, null);

            // act


            sut.LastName = expectedLastName;


            // assert

            sut.LastName.Should().Be(expectedLastName);

            }





    }
}
using OOPsReview;
using FluentAssertions;
{
    
}
namespace TestPerson
{
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
            sut.EmploymentPositions.count.Should().Be(0);

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
            ResidentAddress expectedAddress = new ResidentAddress ( 222, "oak street", "Edmonton" , "AB", "T5T2Y5" );
            Employment one = new Employment( "PG-1", SupervisoryLevel.TeamMember, DateTime.Parse("2014/10/04"), 6.4);
            Employment two = new Employment("PG-2", SupervisoryLevel.TeamLeader, DateTime.Parse("2015/10/04"), 5.4);

            List<Employment> employmentPositions = new List<Employment>();
            employmentPositions.Add(one);
            employmentPositions.Add(two);
            int expectedEmploymentCount = employmentPositions.Count;


            //Act - perform the functionality being tested

            Person sut = new Person(expectedFirstName, expectedLastName, expectedAddress);

            //Assert

            Assert.Equal(expectedFirstName, sut.FirstName);
            Assert.Equal(expectedLastName, sut.LastName);
            Assert.Equal(expectedAddress, sut.Address);
            Assert.Equal(expectedEmploymentCount, sut.EmploymentPositions.Count);

        }
    }
}
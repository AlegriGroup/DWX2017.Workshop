using System;
using System.Globalization;
using DWX.Workshop.UnitTests.Environment;
using DWX17.Workshop.Database;
using DWX17.Workshop.Services;
using Xunit;

namespace DWX.Workshop.UnitTests
{
    public class PersonServiceTests
    {
        [Fact]
        public void Person_Should_Be_Added()
        {
            // Arrange
            IPersonRepository personRepository = new InMemoryPersonRepository();
            PersonService personService = new PersonService(personRepository);

            // Act
            string name = "Ben";
            DateTimeOffset dateOfBirth = DateTimeOffset.Parse("2017-06-29", CultureInfo.InvariantCulture, DateTimeStyles.None);

            Person person = personService.Add(name, dateOfBirth);

            // Assert
            Assert.NotEqual(null, person);
            Assert.Equal(name, person.Name);
            Assert.Equal(dateOfBirth, person.DateOfBirth);

        
        }
    }
}

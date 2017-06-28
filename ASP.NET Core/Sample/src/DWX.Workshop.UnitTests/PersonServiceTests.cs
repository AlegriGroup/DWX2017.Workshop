using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using DWX.Workshop.UnitTests.Environment;
using DWX17.Workshop.Database;
using DWX17.Workshop.Database.Entities;
using DWX17.Workshop.Services;
using Moq;
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

        [Fact]
        public void Person_GetAll_Should_Return_One()
        {
            // Arrange
            string name = "Ben";
            DateTimeOffset dateOfBirth = DateTimeOffset.Parse("2017-06-29", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Mock<IPersonRepository> personRepositoryMock = new Mock<IPersonRepository>();
            {
                // Mock Config
                personRepositoryMock.Setup(pr => pr.GetAll()).Returns(() => new[]{ PersonEntity.New(name, dateOfBirth) }.ToList());
            }
            PersonService personService = new PersonService(personRepositoryMock.Object);

            // Act
            List<Person> persons = personService.GetAll();
            int count =persons.Count;
            Person firstPerson = persons.First();

            // Assert
            Assert.Equal(count, 1);
            Assert.NotEqual(null, firstPerson);
            Assert.Equal(name, firstPerson.Name);
            Assert.Equal(dateOfBirth, firstPerson.DateOfBirth);

        }


    }
}

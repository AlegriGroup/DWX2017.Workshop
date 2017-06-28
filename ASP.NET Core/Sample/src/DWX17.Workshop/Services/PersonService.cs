using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWX17.Workshop.Database;
using DWX17.Workshop.Database.Entities;
using DWX17.Workshop.Extensions;

namespace DWX17.Workshop.Services
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public int Age => Convert.ToInt32(DateTimeOffset.Now.Subtract(DateOfBirth).TotalDays /365.0);
    }

    public interface IPersonService
    {
        Person Add(string name, DateTimeOffset dateOfBirth);

        List<Person> GetAll();
    }
    public class PersonService :IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Person Add(string name, DateTimeOffset dateOfBirth)
        {
            PersonEntity personEntity = _personRepository.Add(name, dateOfBirth);

            return personEntity.ToPersonModel();
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll()
                                        .Select(p => p.ToPersonModel())
                                        .ToList();
        }
    }
}

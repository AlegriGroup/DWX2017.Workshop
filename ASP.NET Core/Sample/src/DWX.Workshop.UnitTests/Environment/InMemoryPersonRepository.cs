using DWX17.Workshop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWX17.Workshop.Database.Entities;

namespace DWX.Workshop.UnitTests.Environment
{
    public class InMemoryPersonRepository :IPersonRepository
    {
        private readonly List<PersonEntity> _personCache;

        public InMemoryPersonRepository()
        {
            _personCache = new List<PersonEntity>();
        }
        public PersonEntity Add(string name, DateTimeOffset dateOfBirth)
        {
            PersonEntity person = PersonEntity.New(name, dateOfBirth);
            
            lock (_personCache)
            {
                _personCache.Add(person);
            }

            return person;
        }

        public List<PersonEntity> GetAll()
        {
            lock (_personCache)
            { 
                return _personCache.ToList();
            }
        }
    }
}

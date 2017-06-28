using System;
using System.Collections.Generic;
using System.Text;

namespace DWX17.Workshop.Database.Entities
{
    public class PersonEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public static PersonEntity New(string name, DateTimeOffset dateOfBirth)
        {
            return new PersonEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                DateOfBirth = dateOfBirth
            };
        }
    }
}

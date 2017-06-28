using System;
using System.Collections.Generic;
using System.Text;
using DWX17.Workshop.Database.Entities;

namespace DWX17.Workshop.Database
{
    public interface IPersonRepository
    {
        PersonEntity Add(string name, DateTimeOffset dateOfBirth);

        List<PersonEntity> GetAll();
    }
}

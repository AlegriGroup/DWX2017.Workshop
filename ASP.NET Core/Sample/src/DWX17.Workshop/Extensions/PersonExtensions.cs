using DWX17.Workshop.Database.Entities;
using DWX17.Workshop.Services;

namespace DWX17.Workshop.Extensions
{
    public static class PersonExtensions
    {
        public static Person ToPersonModel(this PersonEntity entity)
        {
            return new Person
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth,
                Name = entity.Name
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DWX17.Workshop.Database.Entities;
using Newtonsoft.Json;

namespace DWX17.Workshop.Database.Json
{
    public class PersonJsonRepository : IPersonRepository
    {
        private readonly string _file;

        public static object JsonFileLock = new object();

        public PersonJsonRepository(string file)
        {
            _file = file;

        }

        public PersonEntity Add(string name, DateTimeOffset dateOfBirth)
        {
            PersonEntity entity = PersonEntity.New(name, dateOfBirth);

            List<PersonEntity> entities = ReadEntities();
            entities.Add(entity);
            WriteEntities(entities);

            return entity;
        }

        public List<PersonEntity> GetAll()
        {
            List<PersonEntity> entities = ReadEntities();

            return entities.OrderBy(p => p.Name).ToList();
        }

        private List<PersonEntity> ReadEntities()
        {
            string jsonFileContents;

            lock (JsonFileLock)
            {
                if (!File.Exists(_file))
                {
                    return new List<PersonEntity>();
                }

                jsonFileContents = File.ReadAllText(_file);
            }
            return JsonConvert.DeserializeObject<List<PersonEntity>>(jsonFileContents);
        }

        private void WriteEntities(List<PersonEntity> entities)
        {
            string jsonFileConents = JsonConvert.SerializeObject(entities);
            lock (JsonFileLock)
            {
                File.WriteAllText(_file, jsonFileConents);
            }
        }
    }
}

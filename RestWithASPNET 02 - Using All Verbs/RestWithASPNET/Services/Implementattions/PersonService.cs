using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Services.Implementattions
{
    public class PersonService : IPersonService
    {
        private List<Person> lstPerson = new List<Person>(){
                new Person()
                {
                    Id = 1,
                    FirstName = "André",
                    LastName = "Alves",
                    Address = "Rua do labirinto, 66 - Altinópolis",
                    Gender = "Male"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Lariel",
                    LastName = "Bezerra",
                    Address = "Rua das cagibrinas, 99 - Altinópolis",
                    Gender = "Male"
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "Zamira",
                    LastName = "Sunchine",
                    Address = "Rua das balelas, 100 - Muzieal do Norte",
                    Gender = "Female"
                },
                new Person()
                {
                    Id = 4,
                    FirstName = "Barizo",
                    LastName = "BeNhanikzerra",
                    Address = "Alamed Petisburg, 1 - Baruk",
                    Gender = "Male"
                }
            };

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            return lstPerson;
        }

        public Person FindById(long id)
        {
            var person = lstPerson.Where(p => p.Id.Equals(id)).FirstOrDefault();
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}

using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository.Implementattions
{
    public class PersonRepository : IPersonRepository
    {
        private SqlContext _context;


        public PersonRepository(SqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public Person Update(Person person)
        {
            try
            {
                if (!Exists(person.Id)) return null;//verifica se Person existe

                var result = _context.person.SingleOrDefault(p => p.Id.Equals(person.Id));
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var result = _context.person.SingleOrDefault(p => p.Id.Equals(id));
                if (result != null)
                {
                    _context.person.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person FindById(long id)
        {
            try
            {
               return  _context.person.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            try
            {
                return _context.person.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.person.Any(p => p.Id.Equals(id));
        }

    }
}

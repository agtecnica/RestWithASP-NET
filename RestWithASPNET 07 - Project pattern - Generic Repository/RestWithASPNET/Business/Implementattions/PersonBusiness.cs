﻿using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Business.Implementattions
{
    public class PersonBusiness : IPersonBusiness
    {
        //private SqlContext _context;
        private IRepository<Person> _repository;

        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}

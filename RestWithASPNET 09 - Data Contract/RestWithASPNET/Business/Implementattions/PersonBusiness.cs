using RestWithASPNET.Data.Converter.Converters;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
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
        private readonly PersonConveter _conveter;

        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
            _conveter = new PersonConveter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _conveter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _conveter.Parse(personEntity);
        }

        public PersonVO FindById(long id)
        {
            return _conveter.Parse(_repository.FindById(id));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _conveter.ParseList(_repository.FindAll());
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _conveter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _conveter.Parse(personEntity);
        }
    }
}

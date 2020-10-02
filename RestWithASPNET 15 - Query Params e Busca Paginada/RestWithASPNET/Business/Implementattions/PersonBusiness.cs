using RestWithASPNET.Data.Converter.Converters;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using Tapioca.HATEOAS.Utils;

namespace RestWithASPNET.Business.Implementattions
{
    public class PersonBusiness : IPersonBusiness
    {
        //private SqlContext _context;
        private IPersonRepository _repository;
        private readonly PersonConveter _conveter;

        public PersonBusiness(IPersonRepository repository)
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

        public List<PersonVO> FindByName(string firstname, string lastname)
        {
            return _conveter.ParseList(_repository.FindByName(firstname, lastname));
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

        public PagedSearchDTO<PersonVO> FindWtihPagedSearch(string name, string sortDirection, int pagesize, int page)
        {
            page = (page > 0) ? page - 1 : 0;
            string query = @"select * from Person p WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(name)) 
                query = query + $"and p.firstname like '%{ name }%'";

            query = query + $" ORDER BY p.firstname { sortDirection } LIMIT { pagesize } OFFSET { page }";

            var persons = _repository.FindWithPagedSearch(query);

            //string countQuery = @"select * from Person p WHERE 1 = 1 ";

            //if (!string.IsNullOrEmpty(name))
            //    countQuery = countQuery + $"and p.firstname like '%{ name }%'";

            var totalResults = _repository.FindWithPagedSearch(query).Count();

            var ret = new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page + 1,
                List = _conveter.ParseList(persons),
                PageSize = pagesize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
            return ret;

        }
    }
}

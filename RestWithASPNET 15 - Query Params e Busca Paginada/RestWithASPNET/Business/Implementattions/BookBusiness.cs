using RestWithASPNET.Data.Converter.Converters;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Business.Implementattions
{
    public class BookBusiness : IBookBusiness
    {
        //private SqlContext _context;
        private IRepository<Book> _repository;
        private readonly BookConveter _conveter;

        public BookBusiness(IRepository<Book> repository)
        {
            _repository = repository;
            _conveter = new BookConveter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _conveter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _conveter.Parse(bookEntity);
        }

        public BookVO FindById(long id)
        {
            return _conveter.Parse(_repository.FindById(id));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _conveter.ParseList(_repository.FindAll());
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _conveter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _conveter.Parse(bookEntity);
        }
    }
}

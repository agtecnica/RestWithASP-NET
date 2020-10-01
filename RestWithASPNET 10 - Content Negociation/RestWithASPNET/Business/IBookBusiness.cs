using RestWithASPNET.Model;
using RestWithASPNET.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO item);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO item);
        void Delete(long id);
    }
}

using RestWithASPNET.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstname, string lastname);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        List<PersonVO> FindAll();
        PagedSearchDTO<PersonVO> FindWtihPagedSearch(string name, string sortDirection, int pagesize, int page);
    }
}

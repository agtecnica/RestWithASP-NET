using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
        List<Person> FindAll();
    }
}

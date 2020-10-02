using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository.Implementattions
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(SqlContext context) : base(context) { }

        public List<Person> FindByName(string firstname, string lasstname)
        {
            if (firstname == null) firstname = string.Empty;
            if (lasstname == null) lasstname = string.Empty;
            firstname = firstname.ToLower();
            lasstname = lasstname.ToLower();

            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lasstname))
            {
                return _context.person.Where(p => p.FirstName.ToLower().Contains(firstname) && p.LastName.ToLower().Contains(lasstname)).ToList();
            }
            else if (string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lasstname))
            {
                return _context.person.Where(p => p.LastName.ToLower().Contains(lasstname)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lasstname))
            {
                return _context.person.Where(p => p.FirstName.ToLower().Contains(firstname)).ToList();
            }
            else
            {
                return _context.person.ToList();
            }
        }
    }
}

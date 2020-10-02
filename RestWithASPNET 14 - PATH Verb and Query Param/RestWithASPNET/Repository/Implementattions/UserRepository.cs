using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository.Implementattions
{
    public class UserRepository : ILoginRepository
    {
        private SqlContext _context;


        public UserRepository(SqlContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            try
            {
               return  _context.user.SingleOrDefault(p => p.Login.Equals(login));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

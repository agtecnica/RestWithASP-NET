using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlContext _context;
        private DbSet<T> dataset;


        public GenericRepository(SqlContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public T Update(T item)
        {
            try
            {
                if (!Exists(item.Id)) return null;//verifica se Person existe

                var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Delete(long id)
        {
            try
            {
                var result = dataset.Where(p => p.Id.Equals(id)).FirstOrDefault();
                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T FindById(long id)
        {
            try
            {
                return dataset.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            try
            {
                return dataset.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}

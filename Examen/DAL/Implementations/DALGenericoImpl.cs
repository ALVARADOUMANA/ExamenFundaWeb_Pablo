using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        private Adventureworks2016Context _Context;

        public DALGenericoImpl(Adventureworks2016Context context)
        {
            
            _Context = context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _Context.Add(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity FindById(string id)
        {

            return _Context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Attach(entity);
                _Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

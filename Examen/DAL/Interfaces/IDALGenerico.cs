using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDALGenerico<TEntity> where TEntity : class
    {

        List<TEntity> GetAll();
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        bool Update(TEntity entity);
        TEntity FindById(string id);

    }
}

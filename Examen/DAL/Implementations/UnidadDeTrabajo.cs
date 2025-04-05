using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public ICultureDAL CultureDAL { get; set; }

        private Adventureworks2016Context _context;

        public UnidadDeTrabajo(Adventureworks2016Context context,
                        ICultureDAL cultureDAL                       
            ) 
        {
                this._context = context;
                this.CultureDAL = cultureDAL; 
        }
       

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}

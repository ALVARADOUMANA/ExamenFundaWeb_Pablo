using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CultureDALImpl : DALGenericoImpl<Culture>, ICultureDAL
    {
        Adventureworks2016Context context { get; set; }

        public CultureDALImpl(Adventureworks2016Context context) : base(context)
        {
            this.context = context;
        }

    }
}

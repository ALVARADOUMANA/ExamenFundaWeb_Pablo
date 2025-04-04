using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class EmpleadoDALImpl : GenericDALImpl<Empleado>, IEmpleadoDAL
    {
        QuizContext NorthWindContext { get; set; }

        public EmpleadoDALImpl(QuizContext northWindContext)
            : base(northWindContext)
        {
            this.NorthWindContext = northWindContext;
        }
    }
}

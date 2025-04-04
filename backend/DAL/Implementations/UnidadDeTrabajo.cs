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
        public IEmpleadoDAL EmpleadoDAL { get; set; }

        QuizContext context;

        public UnidadDeTrabajo(IEmpleadoDAL empleadoDAL, QuizContext context)
        {
            EmpleadoDAL = empleadoDAL;
            this.context = context;
        }
        public void Dispose()
        {
            this.context.Dispose();
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}

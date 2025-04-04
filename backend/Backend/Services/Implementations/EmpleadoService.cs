using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public EmpleadoService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        EmpleadoDTO Convertir(Empleado empleado)
        {
            return new EmpleadoDTO
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        Empleado Convertir(EmpleadoDTO empleado)
        {
            return new Empleado
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        public EmpleadoDTO AddEmpleado(EmpleadoDTO empleado)
        {
            _unidadDeTrabajo.EmpleadoDAL.Add(Convertir(empleado));
            _unidadDeTrabajo.Complete();
            return empleado;
        }

        public EmpleadoDTO DeleteEmpleado(int id)
        {
            var shipper = new Empleado { EmpleadoId = id };
            _unidadDeTrabajo.EmpleadoDAL.Remove(shipper);
            _unidadDeTrabajo.Complete();
            return Convertir(shipper);
        }

        public List<EmpleadoDTO> GetEmpleados()
        {
            var empleados = _unidadDeTrabajo.EmpleadoDAL.Get();
            List<EmpleadoDTO> empleadoDTOs = new List<EmpleadoDTO>();
            foreach (var empleado in empleados)
            {
                empleadoDTOs.Add(this.Convertir(empleado));
            }
            return empleadoDTOs;
        }

        public EmpleadoDTO GetEmpleadoById(int id)
        {
            var result = _unidadDeTrabajo.EmpleadoDAL.FindById(id);
            return Convertir(result);
        }

        public EmpleadoDTO UpdateEmpleado(EmpleadoDTO empleado)
        {
            var entity = Convertir(empleado);
            _unidadDeTrabajo.EmpleadoDAL.Update(entity);
            _unidadDeTrabajo.Complete();

            return empleado;
        }
    }
}

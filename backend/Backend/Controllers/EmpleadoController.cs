using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        public IEnumerable<EmpleadoDTO> Get()
        {
            return _empleadoService.GetEmpleados();
        }

        // GET api/<EmpleadoController>/
        [HttpGet("{id}")]
        public EmpleadoDTO Get(int id)
        {
            return _empleadoService.GetEmpleadoById(id);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public void Post([FromBody] EmpleadoDTO empleado)
        {
            _empleadoService.AddEmpleado(empleado);
        }

        // PUT api/<EmpleadoController>/
        [HttpPut]
        public void Put([FromBody] EmpleadoDTO empleado)
        {
            _empleadoService.UpdateEmpleado(empleado);
        }

        // DELETE api/<EmpleadoController>/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _empleadoService.DeleteEmpleado(id);
        }
    }
}

using BackEnd.DTO;
using BackEnd.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        ICultureService _cultureService;

        public CultureController(ICultureService cultureService)
        {
            _cultureService = cultureService;
        }

        // GET: api/<CultureController>
        [HttpGet]
        public IEnumerable<CultureDTO> Get()
        {
            return _cultureService.GetCultures();
        }

        // GET api/<CultureController>/
        [HttpGet("{id}")]
        public CultureDTO Get(string id)
        {
            return _cultureService.GetCultureById(id);
        }

        // POST api/<CultureController>
        [HttpPost]
        public void Post([FromBody] CultureDTO culture)
        {
            _cultureService.AddCulture(culture);
        }

        // PUT api/<CultureController>/
        [HttpPut]
        public void Put([FromBody] CultureDTO culture)
        {
            _cultureService.UpdateCulture(culture);
        }

        // DELETE api/<CultureController>/
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _cultureService.DeleteCulture(id);
        }
    }
}
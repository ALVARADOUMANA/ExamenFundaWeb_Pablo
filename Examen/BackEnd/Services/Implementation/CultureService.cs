using BackEnd.DTO;
using BackEnd.Service.Interface;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Service.Implementation
{
    public class CultureService : ICultureService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public CultureService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        CultureDTO Convertir(Culture culture)
        {
            return new CultureDTO
            {
                CultureId = culture.CultureId,
                Name = culture.Name,
                ModifiedDate = culture.ModifiedDate
            };
        }

        Culture Convertir(CultureDTO culture)
        {
            return new Culture
            {
                CultureId = culture.CultureId,
                Name = culture.Name,
                ModifiedDate = culture.ModifiedDate
            };
        }

        public CultureDTO AddCulture(CultureDTO culture)
        {
            _unidadDeTrabajo.CultureDAL.Add(Convertir(culture));
            _unidadDeTrabajo.Complete();
            return culture;
        }

        public CultureDTO DeleteCulture(string id)
        {
            var culture = new Culture { CultureId = id };
            _unidadDeTrabajo.CultureDAL.Remove(culture);
            _unidadDeTrabajo.Complete();
            return Convertir(culture);
        }

        public List<CultureDTO> GetCultures()
        {
            var cultures = _unidadDeTrabajo.CultureDAL.GetAll();
            List<CultureDTO> cultureDTOs = new List<CultureDTO>();
            foreach (var culture in cultures)
            {
                cultureDTOs.Add(this.Convertir(culture));
            }
            return cultureDTOs;
        }

        public CultureDTO GetCultureById(string id)
        {
            var result = _unidadDeTrabajo.CultureDAL.FindById(id);
            return Convertir(result);
        }

        public CultureDTO UpdateCulture(CultureDTO culture)
        {
            culture.ModifiedDate = DateTime.Now;

            var entity = Convertir(culture);
            _unidadDeTrabajo.CultureDAL.Update(entity);
            _unidadDeTrabajo.Complete();
            return culture;
        }
    }
}
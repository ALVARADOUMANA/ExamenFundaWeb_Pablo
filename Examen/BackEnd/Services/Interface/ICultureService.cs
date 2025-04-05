using BackEnd.DTO;

namespace BackEnd.Service.Interface
{
    public interface ICultureService
    {
        List<CultureDTO> GetCultures();
        CultureDTO GetCultureById(string id);
        CultureDTO AddCulture(CultureDTO culture);
        CultureDTO UpdateCulture(CultureDTO culture);
        CultureDTO DeleteCulture(string id);
    }
}
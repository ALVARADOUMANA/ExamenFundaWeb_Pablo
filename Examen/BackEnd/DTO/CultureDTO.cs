using Entities.Entities;

namespace BackEnd.DTO
{
    public class CultureDTO
    {
        public string CultureId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
        //public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } = new List<ProductModelProductDescriptionCulture>();
    }
}

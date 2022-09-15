using RestFulAPI.Models.Entities.Abstract;

namespace RestFulAPI.Models.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}

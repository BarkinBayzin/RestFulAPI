using RestFulAPI.Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFulAPI.Models.Entities.Concrete
{
    public class AppUser:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}

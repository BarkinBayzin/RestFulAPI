using System.ComponentModel.DataAnnotations;

namespace RestFulAPI.Models.DTOs
{
    public class AuthenticationDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password{ get; set; }

    }
}

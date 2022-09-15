using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Infrastructure.Repositories.Interface;
using RestFulAPI.Models.DTOs;
using RestFulAPI.Models.Entities.Concrete;

namespace RestFulAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AccountController(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationDTO model)
        {
            AppUser appUser = new AppUser()
            {
                UserName = model.UserName,
                Password = model.Password
            };

            var user = _repository.Authentication(appUser.UserName, appUser.Password);

            if (user == null) return BadRequest(new { message = "User name or password is incerrect...!" });

            return Ok(user);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Infrastructure.Repositories.Interface;
using RestFulAPI.Models.DTOs;
using RestFulAPI.Models.Entities.Concrete;
using System.Collections.Generic;

namespace RestFulAPI.Controllers
{

    /*
     ProduceResponseTypes => Bir action metodu içerisinde bir çok dönüş türü ve yolu bulunma ihtimali yüksektir. Örneğin aşağıda bulunan "CreateNationalPark" metodunun içeriisnde 2 adet değişik dönüş tipi bulunmaktadır.
     "ProduceResponseTypes" özniteliği kullanarak bu dönüş tiplerini Swagger gibi araçlar tarafından web API dökümantasyonlarında istemciler için daha açıklayıcı yanıt ayrıntıları üretir
     */
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(400)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        //Swagger UI aracılığı ile API üzerinde bazı testler yapmak isteyen geliştiriciler için bazı özet bilgiler ekliyoruz ki ilgili geliştirici API'yi rahatlıkla test edebilsin. Yani API'nin yetenekleri hakkında açıklama yapıyoruz. İlgili Action methodunun ne paratmetre aldığı ne iş yaptığı vb.
        /// <summary>
        /// Get list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GetCategoryDTO>))]
        public IActionResult GetCategory()
        {
            var categoryList = _categoryRepository.GetCategories();

            var objDto = new List<GetCategoryDTO>();

            foreach (var obj in categoryList)
            {
                objDto.Add(new GetCategoryDTO() { Id = obj.Id, Description = obj.Description, Name = obj.Name, Slug = obj.Slug});
            }

            //var objDto = new List<Category>();
            //foreach (var category in categoryList) objDto.Add(category);

            return Ok(objDto);
        }
        /// <summary>
        /// Get individual Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}",Name ="GetCategory")]
        [ProducesResponseType(200), ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            var obj = _categoryRepository.GetCategory(id);

            if (obj == null) return NotFound();
            else
            {
                GetCategoryDTO getCategoryDTO = new GetCategoryDTO()
                {
                    Id = obj.Id,
                    Description = obj.Description,
                    Name = obj.Name,
                    Slug = obj.Slug
                };
                //var objDto = _mapper.Map<GetCategoryDTO>(obj);
                //return Ok(objDto);
                return Ok(getCategoryDTO);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest();

            if(_categoryRepository.CategoryExists(categoryDto.Name))
            {
                ModelState.AddModelError("", "This category already exist..!");
                return StatusCode(404, ModelState);
            }

            Category cat = new Category()
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Slug = categoryDto.Slug
            };
            if (!_categoryRepository.CreateCategory(cat))
            {
                ModelState.AddModelError("", $"Something went wrong when creating a category {cat.Name} or {cat.Description}");

                return StatusCode(500, ModelState);
            }

            return Ok(cat);
        }

        [HttpPut("{id}",Name ="UpdateCategory")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDTO categoryDTO)
        {
            if (categoryDTO == null || categoryDTO.Id != id) return BadRequest(ModelState);

            Category cat = new Category()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                Slug = categoryDTO.Slug,
                Id = categoryDTO.Id
            };

            if(!_categoryRepository.UpdateCategory(categoryDTO.Id, cat))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {categoryDTO.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var categoryObj = _categoryRepository.GetCategory(id);

            if(!_categoryRepository.DeleteCategory(categoryObj.Id))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the this record {categoryObj.Id}");
            }
            return Ok(categoryObj);
        }
    }
}

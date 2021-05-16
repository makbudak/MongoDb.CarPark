using Microsoft.AspNetCore.Mvc;
using MongoDb.CarPark.DataAccess.Abstract;
using MongoDb.CarPark.Entities.Concrete;
using System.Linq;

namespace MongoDb.CarPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = brandRepository.Get();
            if (result == null)
            {
                return BadRequest("Not found");
            }
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = brandRepository.GetByIdAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Brand brand)
        {
            var result = brandRepository.AddAsync(brand).Result;
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Brand brand)
        {
            var result = brandRepository.UpdateAsync(id, brand).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = brandRepository.DeleteAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }
            return NoContent();
        }
    }
}

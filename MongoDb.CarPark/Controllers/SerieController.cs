using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDb.CarPark.DataAccess.Abstract;
using MongoDb.CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.CarPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly ISerieRepository serieRepository;
        private readonly IBrandRepository brandRepository;

        public SerieController(ISerieRepository serieRepository,
            IBrandRepository brandRepository)
        {
            this.serieRepository = serieRepository;
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = serieRepository.Get().ToList();

            foreach (var serie in list)
            {
                serie.Brand = brandRepository.GetByIdAsync(serie.BrandId).Result;
            }

            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Serie serie)
        {
            var result = serieRepository.AddAsync(serie).Result;
            return Ok(result);
        }
    }
}

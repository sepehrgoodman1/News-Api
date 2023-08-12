using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Cities.Contracts.Dtos;

namespace NewsApi.NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _service;

        public CityController(CityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<GetCityDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        public async Task Add(AddCityDto city)
        {
            await _service.Add(city);
        }

        [HttpPut]
        public async Task Update(int id, UpdateCityDto city)
        {
            await _service.Update(id, city);
        }
    }
}

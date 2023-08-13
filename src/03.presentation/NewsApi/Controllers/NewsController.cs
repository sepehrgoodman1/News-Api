using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Cities.Contracts.Dtos;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.News.Contracts;
using NewsApi.Services.News.Contracts.Dtos;

namespace NewsApi.NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _service;

        public NewsController(NewsService service)
        {
            _service = service;
        }

        [HttpGet("news/all")]
        public async Task<List<GetNewsDto>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("news/sliders")]
        public async Task<List<GetSlideNewsDto>> GetAllWithSliders()
        {
            return await _service.GetAllWithSliders();
        }
        [HttpGet("news/by-cities")]
        public async Task<List<GetNewsDto>> GetAllByCity( string cityName)
        {
            return await _service.GetAllByCity(cityName);
        }
        [HttpGet("news/by-groups")]
        public async Task<List<GetNewsDto>> GetAllByGroup(string groupName)
        {
            return await _service.GetAllByGroup(groupName);
        }
        [HttpGet("news/{id:int}")]
        public async Task<GetByIdDto> GetWithId(int id)
        {
            return await _service.GetWithId(id);
        }

        [HttpPost]
        public async Task Add( AddNewsDto news)
        {
            await _service.Add(news);
        }

        [HttpPut]
        public async Task Update( int id, UpdateNewsDto city)
        {
            await _service.Update(id, city);
        }

        [HttpPut("update-tag")]
        public async Task UpdateTags( int idNews , int idTag)
        {
            await _service.UpdateTags(idNews, idTag);
        }
    }
}

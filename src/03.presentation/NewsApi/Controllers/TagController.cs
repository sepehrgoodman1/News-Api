using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Groups.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts;
using NewsApi.Services.Tags.Contracts;
using NewsApi.Services.Tags.Contracts.Dtos;

namespace NewsApi.NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagService _service;

        public TagController(TagService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<GetTagDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        public async Task Add(AddTagDto tag)
        {
            await _service.Add(tag);
        }
    }
}

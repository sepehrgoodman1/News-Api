using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Cities.Contracts.Dtos;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Groups.Contracts;
using NewsApi.Services.Groups.Contracts.Dtos;

namespace NewsApi.NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _service;

        public GroupController(GroupService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<GetGroupDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        public async Task Add(AddGroupDto city)
        {
            await _service.Add(city);
        }
    }
}

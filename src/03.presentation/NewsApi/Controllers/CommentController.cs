using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Cities.Contracts.Dtos;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Comments.Contracts;
using NewsApi.Services.Comments.Contracts.Dtos;

namespace NewsApi.NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _service;

        public CommentController(CommentService service)
        {
            _service = service;
        }

        [HttpGet("comments")]
        public async Task<List<GetCommentDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("comments/{id:int}")]
        public async Task<List<GetCommentDto>> GetAllByNews(int id, [FromQuery] CommentStatus commentStatus)
        {
            return await _service.GetAllByNews(id , commentStatus);
        }

        [HttpPost]
        public async Task Add(AddCommentDto comment,[FromQuery] CommentStatus commentStatus)
        {
            await _service.Add(comment, commentStatus);
        }
        [HttpPatch]
        public async Task Update(int id, [FromQuery] CommentStatus commentStatus)
        {
            await _service.Update(id, commentStatus);
        }

        /*  [HttpPut]
          public async Task Update(int id, UpdateCityDto city)
          {
              await _service.Update(id, city);
          }*/
    }
}

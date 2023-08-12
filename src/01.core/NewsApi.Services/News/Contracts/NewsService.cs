using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.News.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.News.Contracts
{
    public interface NewsService
    {
        Task Add(AddNewsDto news);
        Task<List<GetNewsDto>> GetAll();
        Task<List<GetSlideNewsDto>> GetAllWithSliders();
        Task Update(int id, UpdateNewsDto city);
        Task<List<GetNewsDto>> GetAllByCity([FromBody] string cityName);
        Task<List<GetNewsDto>> GetAllByGroup(string groupName);
        Task<GetByIdDto> GetWithId(int id);
    }
}

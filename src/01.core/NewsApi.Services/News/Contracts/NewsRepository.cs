using Entities.Entities;
using NewsApi.Services.News.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApi.Services.New.Contracts
{
    public interface NewsRepository
    {
        void Add(News news);
        Task<List<GetNewsDto>> GetAll();
        Task<List<GetSlideNewsDto>> GetAllWithSliders();
        void Update(News news);
        Task<News> GetById(int id);
        Task<List<GetNewsDto>> GetAllByCity(string cityName);
        Task<List<GetNewsDto>> GetAllByGroup(string groupName);
        Task<GetByIdDto> GetWithId(int id);
        Task<bool> IsExistByTagName(string tagName);

    }
}

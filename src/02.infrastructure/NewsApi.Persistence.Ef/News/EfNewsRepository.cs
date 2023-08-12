using Azure;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewApi.Services.New.Contracts;
using NewsApi.Services.Groups.Contracts.Dtos;
using NewsApi.Services.News.Contracts;
using NewsApi.Services.News.Contracts.Dtos;
using NewsApi.Services.Tags.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;

namespace NewApi.Persistence.Ef.New
{
    public class EfNewsRepository : NewsRepository
    {
        private readonly DbSet<News> _news;

        public EfNewsRepository(EfDataContext efDataContext)
        {
            _news = efDataContext.News;
        }

        public void Add(News news)
        {
            _news.Add(news);

        }

        public async Task<List<GetNewsDto>> GetAll()
        {
            return await _news.OrderByDescending(_ => _.Date).Select(c => new GetNewsDto()
            {
                Title = c.Title,
                Text = c.Text,
                CountViews = c.CountViews,
                GroupName = c.Group.Name,
                CityName = c.City.Name,
                Date = c.Date,
                Tags = c.NewsTags.Select(t => t.Tags.Name)
            }).ToListAsync();
        }

    

        public async Task<List<GetSlideNewsDto>> GetAllWithSliders()
        {
            return await _news.OrderByDescending(_ => _.Date).Where(_ => _.IsSlider).Select(c => new GetSlideNewsDto()
                        {
                            Title = c.Title,
                            Date = c.Date,
                        }).ToListAsync();
        }
        public async Task<List<GetNewsDto>> GetAllByCity(string cityName)
        {
            return await _news.Where(_ => _.City.Name.ToUpper()
                        .Replace(" ", "") == cityName.ToUpper().Replace(" ", ""))
                    .OrderByDescending(_ => _.Date).Select(c => new GetNewsDto()
                        {
                            Title = c.Title,
                            Text = c.Text,
                            CountViews = c.CountViews,
                            GroupName = c.Group.Name,
                            CityName = c.City.Name,
                            Date = c.Date,
                            Tags = c.NewsTags.Select(t => t.Tags.Name)
                        }).ToListAsync();
        }
        public async Task<List<GetNewsDto>> GetAllByGroup(string groupName)
        {
            return await _news.Where(_ => _.Group.Name.ToUpper()
                       .Replace(" ", "") == groupName.ToUpper().Replace(" ", ""))
                   .OrderByDescending(_ => _.Date).Select(c => new GetNewsDto()
                   {
                       Title = c.Title,
                       Text = c.Text,
                       CountViews = c.CountViews,
                       GroupName = c.Group.Name,
                       CityName = c.City.Name,
                       Date = c.Date,
                       Tags = c.NewsTags.Select(t => t.Tags.Name)
                   }).ToListAsync();
        }

        public async Task<GetByIdDto> GetWithId(int id)
        {
            var FindedNews = await _news.FindAsync(id);

            var FindedNewsDto = new GetByIdDto
            {
                Title = FindedNews.Title,
                Text = FindedNews.Text,
                CountViews = FindedNews.CountViews,
                GroupName = FindedNews.Group.Name,
                CityName = FindedNews.City.Name,
                Comments = FindedNews.Comments.Where(_=> _.CommentStatus == CommentStatus.Confirmed)
                                            .Select(C => new ApprovalCommenstsDto
                                                        {
                                                            Name = C.Name,
                                                            Text = C.Text
                                                        }).ToList(),
                Date = FindedNews.Date,
                Tags = FindedNews.NewsTags.Select(t => t.Tags.Name)
            };

            return  FindedNewsDto;

                 
        }



        public async Task<News> GetById(int id)
        {
            return await _news.FindAsync(id);
        }

        public void Update( News news)
        {
            _news.Update(news);
        }
    }
}

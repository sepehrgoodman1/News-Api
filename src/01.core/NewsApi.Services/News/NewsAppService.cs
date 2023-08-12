using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using NewApi.Services.New.Contracts;
using NewsApi.Services.News.Contracts;
using NewsApi.Services.News.Contracts.Dtos;
using NewsApi.Services.NewsTags.Contracts;
using NewsApi.Services.Tags.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;

namespace NewApi.Services.New
{
    public class NewsAppService : NewsService
    {
        private readonly NewsRepository _repository;
        private readonly NewsTagRepository _newsTagRepository;
        private readonly TagRepository _tagRepository;
        private readonly UnitOfWork _unitOfWork;

        public NewsAppService(
            NewsRepository newsRepository,
            UnitOfWork unitOfWork,
            NewsTagRepository newsTagRepository,
            TagRepository tagRepository)
        {
            _repository = newsRepository;
            _unitOfWork = unitOfWork;
            _newsTagRepository = newsTagRepository;
            _tagRepository = tagRepository;
        }

        public async Task Add(AddNewsDto newsDto)
        {
            var news = new News
            {
                Title = newsDto.Title,
                Text = newsDto.Text,
                GroupId = newsDto.GroupId,
                CityId = newsDto.CityId,
                IsSlider = newsDto.IsSlider,
                Date = DateTime.Now
            };

            _repository.Add(news);

            foreach (var tagName in newsDto.Tags)
            {
                var _tag = new Tag
                {
                    Name = tagName
                };

                Tag? TagRegistered = await _tagRepository.FindTag(tagName);

                var newsTag = new NewsTag();

                if (TagRegistered == null)
                {
                    _tagRepository.Add(_tag);

                    newsTag = new NewsTag
                    {
                        NewsId = news.Id,
                        Newss = news,
                        TagsId = _tag.Id,
                        Tags = _tag
                    };
                }
                else
                {
                    newsTag = new NewsTag
                    {
                        NewsId = news.Id,
                        Newss = news,
                        TagsId = TagRegistered.Id,
                        Tags = TagRegistered
                    };
                }

                _newsTagRepository.Add(newsTag);

            }

            await _unitOfWork.Complete();
        }

        public async Task<List<GetNewsDto>> GetAll()
        {
            
            return await _repository.GetAll();
        }

        public async Task<List<GetSlideNewsDto>> GetAllWithSliders()
        {

            return await _repository.GetAllWithSliders();
        }
        public async Task<List<GetNewsDto>> GetAllByCity(string cityName)
        {
            return await _repository.GetAllByCity(cityName);
        }
        public async Task<List<GetNewsDto>> GetAllByGroup(string groupName)
        {
            return await _repository.GetAllByGroup(groupName);
        }
        public async Task<GetByIdDto> GetWithId(int id)
        {
            return await _repository.GetWithId(id);
        }

        public async Task Update(int id, UpdateNewsDto news)
        {
            var FindedNews = await _repository.GetById(id);

            FindedNews.Title = news.title;
            FindedNews.Text = news.text;
            FindedNews.IsSlider = news.IsSlider;

            _repository.Update(FindedNews);

            await _unitOfWork.Complete();

        }
    }
}

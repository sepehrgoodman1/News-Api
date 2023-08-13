using NewsApi.Services.Groups.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts;
using NewsApi.Services.Tags.Contracts;
using NewsApi.Services.Tags.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;
using Entities.Entities;
using NewApi.Services.New.Contracts;
using NewsApi.Services.Tags.Exceptions;

namespace NewsApi.Services.Tags
{
    public class TagAppService : TagService
    {
        private readonly TagRepository _repository;
        private readonly NewsRepository _newsRepository;
        private readonly UnitOfWork _unitOfWork;
        public TagAppService(TagRepository repository, NewsRepository newsRepository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _newsRepository = newsRepository;
        }
        public async Task<List<GetTagDto>> GetAll()
        {
            return await _repository.GetAll();

        }
        public async Task Add(AddTagDto tag)
        {
            var _tag = new Tag
            {
                Name = tag.Name,
            };

            _repository.Add(_tag);

            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var tag = await _repository.GetTag(id);

            if(tag == null)
            {
                throw new TagNotFoundException();
            }

            if(! await _newsRepository.IsExistByTagName(tag.Name))
            {
                _repository.Delete(tag);

                await _unitOfWork.Complete();
            }
        }


       

    }
}

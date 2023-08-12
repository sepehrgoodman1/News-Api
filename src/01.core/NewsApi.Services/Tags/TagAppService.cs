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

namespace NewsApi.Services.Tags
{
    public class TagAppService : TagService
    {
        private readonly TagRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public TagAppService(TagRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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


    }
}

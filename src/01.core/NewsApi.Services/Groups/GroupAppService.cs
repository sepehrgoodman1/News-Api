using Entities.Entities;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Groups.Contracts;
using NewsApi.Services.Groups.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;

namespace NewsApi.Services.Groups
{
    public class GroupAppService : GroupService
    {
        private readonly GroupRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public GroupAppService(GroupRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetGroupDto>> GetAll()
        {
            return await _repository.GetAll();

        }
        public async Task Add(AddGroupDto group)
        {
            var _group = new Group
            {
                Name = group.Name,
            };

            _repository.Add(_group);

            await _unitOfWork.Complete();
        }
    }
}

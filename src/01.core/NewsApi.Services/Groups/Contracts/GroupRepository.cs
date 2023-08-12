using Entities.Entities;
using NewsApi.Services.Cities.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Groups.Contracts
{
    public interface GroupRepository
    {
        void Add(Group city);
        Task<List<GetGroupDto>> GetAll();
    }
}

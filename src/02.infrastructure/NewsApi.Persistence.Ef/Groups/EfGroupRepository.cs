using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewsApi.Services.Cities.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts;
using NewsApi.Services.Groups.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.Groups
{
    public class EfGroupRepository : GroupRepository
    {
        private readonly DbSet<Group> _group;

        public EfGroupRepository(EfDataContext efDataContext)
        {
            _group = efDataContext.Groups;
        }

        public async Task<List<GetGroupDto>> GetAll()
        {
            var Cities = await _group.Select(c => new GetGroupDto
            {
                Name = c.Name,
            }).ToListAsync();

            return Cities;
        }

        public void Add(Group group)
        {
            _group.Add(group);

        }


    }
}

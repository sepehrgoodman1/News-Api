using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewsApi.Services.Groups.Contracts.Dtos;
using NewsApi.Services.Tags.Contracts;
using NewsApi.Services.Tags.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.Tags
{
    public class EfTagRepository : TagRepository
    {
        private readonly DbSet<Tag> _tags;

        public EfTagRepository(EfDataContext efDataContext)
        {
            _tags = efDataContext.Tags;
        }

        public async Task<List<GetTagDto>> GetAll()
        {
            var Tags = await _tags.Select(c => new GetTagDto
            {
                Name = c.Name,
            }).ToListAsync();

            return Tags;
        }

        public void Add(Tag tag)
        {
            _tags.Add(tag);

        }

        public async Task<Tag> FindTag(string name)
        {
            return await  _tags.Where(_ => _.Name == name).FirstOrDefaultAsync();
        }
    }
}

using Entities.Entities;
using NewsApi.Services.Tags.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Tags.Contracts
{
    public interface TagRepository
    {
        Task<List<GetTagDto>> GetAll();
        void Add(Tag city);
        Task<Tag> FindTag(string name);
        Task<Tag> GetTag(int id);
        void Delete(Tag tag);
    }
}

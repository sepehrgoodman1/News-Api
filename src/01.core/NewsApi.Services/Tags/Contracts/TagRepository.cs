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
    }
}

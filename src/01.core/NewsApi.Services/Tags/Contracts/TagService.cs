using NewsApi.Services.Tags.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Tags.Contracts
{
    public interface TagService
    {
        Task<List<GetTagDto>> GetAll();
        Task Add(AddTagDto tag);
        Task Delete(int id);
    
    }
}

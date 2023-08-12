using Entities.Entities;
using NewsApi.Services.Cities.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Cities.Contracts
{
    public interface CityService
    {
        Task Add(AddCityDto city);
        Task<List<GetCityDto>> GetAll();
        Task Update(int id , UpdateCityDto city);

    }
}

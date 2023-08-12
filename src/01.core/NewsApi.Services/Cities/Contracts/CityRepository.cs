using Entities.Entities;
using NewsApi.Services.Cities.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Cities.Contracts
{
    public interface CityRepository
    {
        void Add(City city);
        Task<List<GetCityDto>> GetAll();
        void Update(City city);

        Task<City> FindCity(int id);
    }
}

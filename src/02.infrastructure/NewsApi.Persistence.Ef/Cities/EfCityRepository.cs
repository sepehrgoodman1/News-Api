using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Cities.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.Cities
{
    public class EfCityRepository : CityRepository
    {
        private readonly DbSet<City> _cities;

        public EfCityRepository(EfDataContext efDataContext)
        {
            _cities = efDataContext.Cities;
        }

        public async Task<List<GetCityDto>> GetAll()
        {
            var Cities = await _cities.Select(c => new GetCityDto
            {
                Name = c.Name,
            }).ToListAsync();
            return Cities;
        }

        public void Add(City city)
        {
             _cities.Add(city);
        }
        public void Update( City city)
        {
            _cities.Update(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await _cities.FindAsync(id);
        }
    }
}

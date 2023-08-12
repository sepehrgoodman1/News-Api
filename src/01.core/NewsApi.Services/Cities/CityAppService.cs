using Entities.Entities;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Cities.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;

namespace NewsApi.Services.Cities
{
    public class CityAppService : CityService
    {
        private readonly CityRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public CityAppService(CityRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetCityDto>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task Add(AddCityDto city)
        {
            var _city = new City
            {
                Name = city.Name,
            };

             _repository.Add(_city);

            await _unitOfWork.Complete();

        }

        public async Task Update(int id, UpdateCityDto city)
        {
            var _city = await _repository.FindCity(id);
           
            _city.Name = city.Name;

            _repository.Update( _city);

            await _unitOfWork.Complete();

        }
    }
}

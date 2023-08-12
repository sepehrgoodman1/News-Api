using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Cities.Contracts.Dtos
{
    public class AddCityDto
    {
        [Required] public string Name { get; set; }

    }
}

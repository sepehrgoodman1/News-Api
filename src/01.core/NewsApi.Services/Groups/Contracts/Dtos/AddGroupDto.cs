using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Groups.Contracts.Dtos
{
    public class AddGroupDto
    {
        [Required]
        public string Name { get; set; }
    }
}

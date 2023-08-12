using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.News.Contracts.Dtos
{
    public class UpdateNewsDto
    {
        public string title { get; set; }
        public string text { get; set; }
        public bool IsSlider { get; set; }
    }
}

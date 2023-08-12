using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.News.Contracts.Dtos
{
    public class GetSlideNewsDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}

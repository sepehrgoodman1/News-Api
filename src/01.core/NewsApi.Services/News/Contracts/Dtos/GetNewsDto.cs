using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.News.Contracts.Dtos
{
    public class GetNewsDto
    {
        public string  Title { get; set; }
        public string Text { get; set; }
        public int CountViews { get; set; }
        public string GroupName { get; set; }
        public string CityName { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string> Tags { get; set; } 
        
    }






}

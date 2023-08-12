using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsApi.Services.News.Contracts.Dtos
{
    public class AddNewsDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int GroupId  { get; set; }
        public List<string> Tags { get; set; }
        public int CityId { get; set; }
        public bool IsSlider { get; set; }
        public DateTime Date { get; set; }
    }
}

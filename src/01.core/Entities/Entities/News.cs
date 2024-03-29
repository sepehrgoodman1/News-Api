﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class News
    {
        public News()
        {
            NewsTags = new();
            Comments = new();
        }
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Text { get; set; } 
        public bool IsSlider { get; set; } 
        public DateTime Date { get; set; } = DateTime.Now;
        public int CountViews { get; set; } 
        public int GroupId { get; set; } 
        public int CityId { get; set; }
        public Group Group { get; set; } 
        public City City { get; set; }
        public HashSet<NewsTag> NewsTags { get; set; }
        public HashSet<Comment> Comments { get; set; }
    }
}

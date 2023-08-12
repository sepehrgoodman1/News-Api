using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Tag
    {
        public Tag()
        {
            NewsTags = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<NewsTag> NewsTags { get; set; } 

    }
}

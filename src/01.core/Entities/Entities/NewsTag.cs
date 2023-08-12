using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class NewsTag
    {
        public int Id { get; set; }
        public int TagsId { get; set; }
        public int NewsId { get; set; }
        public Tag Tags { get; set; }
        public News News { get; set; }
    }
}

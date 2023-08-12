using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Comment
    {
        public Comment()
        {
            News = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public CommentStatus CommentStatus { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }

    }
}
public enum CommentStatus :int
{
    Confirmed = 1,
    Pending = 0
}

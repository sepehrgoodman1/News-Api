using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Comments.Contracts.Dtos
{
    public class AddCommentDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int NewsId { get; set; }
    }
}

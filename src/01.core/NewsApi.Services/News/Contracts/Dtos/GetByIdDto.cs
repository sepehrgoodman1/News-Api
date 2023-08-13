using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.News.Contracts.Dtos
{
    public class GetByIdDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int CountViews { get; set; }
        public string GroupName { get; set; }
        public string CityName { get; set; }
        public List<ApprovalCommenstsDto>? Comments { get; set; } = new List<ApprovalCommenstsDto>();
        public DateTime Date { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
    public class ApprovalCommenstsDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}

using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewApi.Services.New.Contracts;
using NewsApi.Services.NewsTags.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.NewsTags
{
    public class EfNewsTagRepository : NewsTagRepository
    {
        private readonly DbSet<NewsTag> _newsTag;

        public EfNewsTagRepository(EfDataContext efDataContext)
        {
            _newsTag = efDataContext.NewsTags;
        }

        public void Add(NewsTag newsTags)
        {
            _newsTag.Add(newsTags);

        }
    }
}

using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.NewsTags.Contracts
{
    public interface NewsTagRepository
    {
        void Add(NewsTag newsTag);

    }
}

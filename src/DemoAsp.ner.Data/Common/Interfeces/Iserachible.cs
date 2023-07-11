using DemoAsp.ner.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.ner.Data.Common.Interfeces
{
    public interface Iserachible<TModel>
    {
        public Task<(int ItemCount, IList<TModel>)> SearchgAsync(string search, PaginationParams paginationParams);
    }
}

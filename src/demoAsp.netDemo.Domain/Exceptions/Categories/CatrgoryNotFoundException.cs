using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoAsp.netDemo.Domain.Exceptions.Categories
{
    public class CatrgoryNotFoundException : NotFoundException
    {
        public CatrgoryNotFoundException()
        {
            this.TitilMessege = "Category Not found!";
        }
    }
}

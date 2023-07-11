using demoAsp.netDemo.Domain.Entities.Categoryes;
using DemoAsp.ner.Data.Common.Interfeces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoAsp.ner.Data.Interfeces.Categories
{
    public interface ICategoryRepository : IRepository<Category, Category>,
        IGetAll<Category>
    {
    }
}

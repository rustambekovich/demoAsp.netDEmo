using DemoAsp.ner.Data.Utils;
using demoAsp.netDemo.Domain.Entities.Categoryes;
using DemoAsp.net.Service.Dtos.CategoriesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.net.Service.Interfaces.ICategories
{
    public interface ICategory
    {
        public Task<bool> CreateAsync(CategoryDto dto);

        public Task<bool> DeleteAsync(long categoryId);

        public Task<long> CountAsync();

        public Task<IList<Category>> GetAllAsync(PaginationParams @params);

        public Task<Category> GetByIdAsync(long categoryId);

        public Task<bool> UpdateAsync(long categoryId, CategoryDto dto);
    }
}

using demoAsp.netDemo.Domain.Entities.Categoryes;
using DemoAsp.ner.Data.Interfeces.Categories;
using DemoAsp.ner.Data.Utils;
using DemoAsp.net.Service.Common.Helper;
using DemoAsp.net.Service.Dtos.CategoriesDto;
using DemoAsp.net.Service.Interfaces.Common;
using DemoAsp.net.Service.Interfaces.ICategories;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.net.Service.Services.CategotyServise
{
    public class CategoryServise : ICategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileServise _fileServise1;
        public CategoryServise(ICategoryRepository categoryRepository, IFileServise fileServise)
        {
            this._categoryRepository = categoryRepository;
            this._fileServise1 = fileServise;

        }
        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(CategoryDto dto)
        {
            string imagepath = await _fileServise1.UploadImageAsync(dto.Image);
            Category category = new Category();
            category.ImgaPath = imagepath;
            category.Name = dto.Name;
            category.Description = dto.Description;
            category.CareatAt = TimeHelper.GetDateTime();
            category.UpdateAt = TimeHelper.GetDateTime();

            var res = await _categoryRepository.CreateAsync(category);
            return res > 0;
        }

        public Task<bool> DeleteAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long categoryId, CategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

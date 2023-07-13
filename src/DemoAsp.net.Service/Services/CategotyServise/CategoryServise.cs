using demoAsp.netDemo.Domain.Entities.Categoryes;
using demoAsp.netDemo.Domain.Exceptions;
using demoAsp.netDemo.Domain.Exceptions.Categories;
using DemoAsp.ner.Data.Interfeces.Categories;
using DemoAsp.ner.Data.Utils;
using DemoAsp.net.Service.Common.Helper;
using DemoAsp.net.Service.Dtos.CategoriesDto;
using DemoAsp.net.Service.Interfaces.Common;
using DemoAsp.net.Service.Interfaces.ICategories;
using DemoAsp.net.Service.Services.Common;
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
        /// <summary>
        /// Count Category
        /// </summary>
        /// <returns></returns>
        public Task<long> CountAsync()
        {
            var result = _categoryRepository.CountAsync();
            return result;
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

        public async Task<bool> DeleteAsync(long categoryId)
        {
            var result = await _categoryRepository.GetByIdAsync(categoryId);
            if (result != null)
            {
                var res = await _categoryRepository.DeleteAsync(categoryId);
                if(res > 0)
                {
                     await _fileServise1.DeleteImageAsync(result.ImgaPath);
                }
                return res > 0;
            }
            return false;
        }

        public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
        {
            var result = await _categoryRepository.GetAllAsync(@params);
            return result;
        }

        public async Task<Category> GetByIdAsync(long categoryId)
        {
            var result = await _categoryRepository.GetByIdAsync(categoryId);
            return result;
        }

        public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
        {
            var result = await _categoryRepository.GetByIdAsync(categoryId);
            if (result != null)
            {
                result.Name = dto.Name;
                result.Description = dto.Description;
                if (dto.Image != null)
                {
                    await _fileServise1.DeleteImageAsync(result.ImgaPath);
                    string newImagePath = await _fileServise1.UploadImageAsync(dto.Image);
                    result.ImgaPath = newImagePath;
                    result.UpdateAt = TimeHelper.GetDateTime();
                }
            }
            var res = await _categoryRepository.UpdateAsync(categoryId, result);
            return res > 0;
        }
    }
}

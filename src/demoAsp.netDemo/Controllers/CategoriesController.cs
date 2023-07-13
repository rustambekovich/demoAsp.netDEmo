using demoAsp.netDemo.Domain.Entities.Categoryes;
using DemoAsp.ner.Data.Interfeces.Categories;
using DemoAsp.ner.Data.Repositories.Categories;
using DemoAsp.ner.Data.Utils;
using DemoAsp.net.Service.Common.Helper;
using DemoAsp.net.Service.Dtos.CategoriesDto;
using DemoAsp.net.Service.Interfaces.ICategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoAsp.netDemo.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        private readonly int maxPageSize = 30;

        public CategoriesController(ICategory servise) 
        {
             this._category = servise;
        }
        [HttpPost]
        public async Task<IActionResult> CreatedAsync([FromForm] CategoryDto dto)
        => Ok(await _category.CreateAsync(dto));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _category.CountAsync());

        [HttpGet("categoryId")]
        public async Task<IActionResult> GetByIdAasync(long CategoryId)
            =>Ok(await _category.GetByIdAsync(CategoryId));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _category.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long CategoryId)
            =>Ok(await _category.DeleteAsync(CategoryId));

        [HttpPut]
        public async Task<IActionResult> UpdetedAsync(long CategoryId, [FromForm] CategoryUpdateDto dto)
            =>Ok(await _category.UpdateAsync(CategoryId, dto));
    }
}

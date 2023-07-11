using demoAsp.netDemo.Domain.Entities.Categoryes;
using DemoAsp.ner.Data.Interfeces.Categories;
using DemoAsp.ner.Data.Repositories.Categories;
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
        public CategoriesController(ICategory servise) 
        {
             this._category = servise;
        }
        [HttpPost]
        public async Task<IActionResult> CreatedAsync([FromForm] CategoryDto dto)
        => Ok(await _category.CreateAsync(dto));
    }
}

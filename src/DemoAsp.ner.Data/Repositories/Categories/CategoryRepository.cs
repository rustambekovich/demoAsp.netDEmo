using demoAsp.netDemo.Domain.Entities;
using demoAsp.netDemo.Domain.Entities.Categoryes;
using DemoAsp.ner.Data.Common.Interfeces;
using DemoAsp.ner.Data.Interfeces;
using DemoAsp.ner.Data.Interfeces.Categories;
using DemoAsp.ner.Data.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DemoAsp.ner.Data.Repositories.Categories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Category entitiy)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"INSERT INTO Caregory(name, description, image_path, createdat, updatedat) " +
                                "VALUES (@Name, @Description, @ImgaPath, @CareatAt, @UpdateAt);";
                var result = await _connection.ExecuteAsync(query, entitiy);
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync(PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, Category entitiy)
        {
            throw new NotImplementedException();
        }
    }
}

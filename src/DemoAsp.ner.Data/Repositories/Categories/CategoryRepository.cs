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
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"Select Count(*) From Caregory;";
                var result = await _connection.QuerySingleAsync<long>(query);
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

        public async Task<int> DeleteAsync(long id)
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();
                string query = "DELETE from Caregory Where id=@Id";
                var result = await _connection.ExecuteAsync(query, new { Id = id });
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

        public async Task<IList<Category>> GetAllAsync(PaginationParams paginationParams)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"Select id, name, description, image_Path as ImgaPath , createdat as CareatAt, updatedat as UpdateAt  from Caregory order by id desc offset {paginationParams.GetSkipCount()} limit {paginationParams.PageSize}";
                var result = (await _connection.QueryAsync<Category>(query)).ToList();
                return result;
            }
            catch
            {
                IList<Category> result = new List<Category>();
                return result;
            }
            finally
            {
                await _connection.CloseAsync();
                if(_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
            }
        }

        public async Task<Category> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select id, name, description, image_Path as ImgaPath , createdat as CareatAt, updatedat as UpdateAt from Caregory Where id=@Id";
                var result = await _connection.QuerySingleAsync<Category>(query, new {Id = id});
                return result;
            }
            catch
            {
                Category category = new Category();
                return category;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> UpdateAsync(long id, Category entitiy)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE caregory " +
                               $"SET  name = @Name, description = @Description, image_path = @ImgaPath, createdat = @CareatAt, updatedat = @UpdateAt" +
                               $" WHERE id = {id};";
                var result = await _connection.ExecuteAsync(query, entitiy);
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}

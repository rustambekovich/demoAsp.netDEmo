
namespace DemoAsp.ner.Data.Interfeces;

public interface IRepository <TEntitiy, TViewModel>
{
    public Task<int> CreateAsync(TEntitiy entitiy);
    public Task<int> UpdateAsync(long id, TEntitiy entitiy);
    public Task<int> DeleteAsync(long id);
    public Task<TViewModel> GetByIdAsync(long id);
    public Task<long> CountAsync();
}

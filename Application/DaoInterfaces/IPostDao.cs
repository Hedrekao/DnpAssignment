using Model;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post postToCreate);

    Task<IEnumerable<Post>> GetAllAsync();

    Task<Post?> GetByIdAsync(int id);
}
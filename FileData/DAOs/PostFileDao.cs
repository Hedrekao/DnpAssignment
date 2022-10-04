using Application.DaoInterfaces;
using Model;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post postToCreate)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(u => u.Id);
            postId++;
        }

        postToCreate.Id = postId;

        context.Posts.Add(postToCreate);
        context.SaveChanges();

        return Task.FromResult(postToCreate); 
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        IEnumerable<Post> list = new List<Post>(context.Posts);
        return Task.FromResult(list);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? post = context.Posts.FirstOrDefault(item => item.Id == id);
        return Task.FromResult(post);
    }
}
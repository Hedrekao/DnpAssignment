using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        Post toCreate = new Post()
        {
            Body = dto.Body,
            Title = dto.Title
        };

        Post post = await postDao.CreateAsync(toCreate);
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await postDao.GetAllAsync();
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        return await postDao.GetByIdAsync(id);
    }
}
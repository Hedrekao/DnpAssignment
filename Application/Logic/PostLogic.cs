using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao PostDao;

    public PostLogic(IPostDao postDao)
    {
        PostDao = postDao;
    }
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        Post toCreate = new Post()
        {
            Body = dto.Body,
            Title = dto.Title
        };

        Post post = await PostDao.CreateAsync(toCreate);
        return post;
    }
}
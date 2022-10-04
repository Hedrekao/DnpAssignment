using System.Text.RegularExpressions;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao UserDao;

    public UserLogic(IUserDao userDao)
    {
        UserDao = userDao;
    }
    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existingUser = await UserDao.GetByUsernameAsync(userToCreate.Username);
        
        if (existingUser != null)
        {
            throw new Exception("User with that username already exists");
        }

        ValidateUserPassword(userToCreate.Password);

        User toCreate = new User()
        {
            UserName = userToCreate.Username,
            Password = userToCreate.Password
        };

        User user = await UserDao.CreateAsync(toCreate);
        
        return user;
    }

    private static void ValidateUserPassword(string password)
    {
        if (password.Length < 8)
        {
            throw new Exception("Password is too short");
        }

        if (!password.Any(c => char.IsDigit(c)))
        {
            throw new Exception("Password must contain at least one number");
        }
    }
}
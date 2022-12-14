using System.Security.Claims;
using Model;

namespace BlazorWasm.Services.HTTP;

public interface IAuthService
{ public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
   public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}
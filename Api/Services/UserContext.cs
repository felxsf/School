using System.Security.Claims;
using School.Application.Abstractions;

namespace School.Api.Services;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _http;
    public UserContext(IHttpContextAccessor http) => _http = http;

    public string? GetUser()
    {
        var u = _http.HttpContext?.User;
        return u?.FindFirstValue(ClaimTypes.Name)
            ?? u?.FindFirstValue("sub")
            ?? "system";
    }
}

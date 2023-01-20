using Microsoft.AspNetCore.Mvc;

namespace AuthFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register()
    {
        throw new NotImplementedException();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login()
    {
        throw new NotImplementedException();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Refresh()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Logout()
    {
        throw new NotImplementedException();
    }
}
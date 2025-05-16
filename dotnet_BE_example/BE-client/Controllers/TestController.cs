using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_client.Controllers;

public class TestController : Controller
{
    [Authorize(Roles = "User,Admin,MasterAdmin")]
    [HttpGet("/test")]
    public OkObjectResult Test()
    {
        return Ok(new
        {
            name = User.Identity?.Name
        });
    }
}
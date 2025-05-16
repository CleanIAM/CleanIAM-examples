using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_client.Controllers;

/// <summary>
/// Demo controller for testing authentication
/// </summary>
public class TestController : Controller
{
    
    /// <summary>
    /// Demo endpoint for testing authentication
    ///
    /// Endpoint is authorized using `OAuth2IntrospectionDefaults.AuthenticationScheme` (configured as default schema)
    ///
    /// Endpoint is also authorized based on roles allowing only users with `User`, `Admin` or `MasterAdmin` roles
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = "User,Admin,MasterAdmin")]
    [HttpGet("/test")]
    public OkObjectResult Test()
    {
        return Ok(new
        {
            // Scopes assigned by authorization server (CleanIAM) are accessible using ClaimsPrincipal
            name = User.Identity?.Name
        });
    }
}
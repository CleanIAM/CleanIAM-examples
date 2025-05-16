using CommunityToolkit.Diagnostics;
using IdentityModel.AspNetCore.OAuth2Introspection;

namespace BE_client;

public static class DependecyInjection
{
    /// <summary>
    /// Configure application authentication using introspection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAuth(
        this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration.GetSection("Authentication:OpenIddict")["Issuer"];
        var clientId = configuration.GetSection("Authentication:OpenIddict")["ClientId"];
        var clientSecret = configuration.GetSection("Authentication:OpenIddict")["ClientSecret"];

        Guard.IsNotNullOrEmpty(issuer, "Issuer not found in app settings");
        Guard.IsNotNullOrEmpty(clientId, "Client id not found in app settings");
        Guard.IsNotNullOrEmpty(clientSecret, "Client secret not found in app settings");

        // User special authentication scheme from `Microsoft.Extensions.DependencyInjection.OAuth2IntrospectionExtensions`
        // nuget package to allow introspection of access tokens
        services.AddAuthentication(OAuth2IntrospectionDefaults.AuthenticationScheme)
            .AddOAuth2Introspection(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.Authority = issuer;
            });


        services.AddAuthorization();
        return services;
    }


    /// <summary>
    /// Configure app auth
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication UseAuth(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}
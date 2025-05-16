# CleanIAM .NET Backend Example

A .NET API example demonstrating how to secure your backend services with CleanIAM OpenID Connect server.

## Features

- **Token introspection**: Validate CleanIAM-issued tokens with token introspection
- **Authorization Policies**: Role-based authorization
- **Resource Protection**: Secure API endpoints with OIDC
- **Swagger Integration**: API documentation with authorization support

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- CleanIAM server running locally or accessible URL

### Configuration

Edit the `appsettings.json` file to configure the OIDC settings. You can you seed script in base CleanIAM repository to create a client for the example app.

### Running the Example

```bash
# Navigate to the project directory
cd BE-client

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

## Learn More

For a complete understanding of securing services with CleanIAM, check the [official documentation](https://github.com/CleanIAM/CleanIAM).

## License

MIT

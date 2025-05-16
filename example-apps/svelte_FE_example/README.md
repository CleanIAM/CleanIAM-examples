# CleanIAM Svelte Frontend Example

A simple Svelte application demonstrating how to integrate with CleanIAM OpenID Connect server.

## Features

- **Complete OIDC Integration**: Full OpenID Connect authentication flow
- **API Authorization**: Using access tokens to authorize API requests
- **User Profile**: Display user information from ID tokens
- **Token Management**: Automatic token refresh and secure storage
- **Logout Flow**: Complete OIDC logout implementation

## Getting Started

### Prerequisites

- Node.js 18+ or Bun runtime
- CleanIAM server running locally or accessible URL

### Installation

```bash
# Install dependencies
npm install
# Or if using Bun
bun install
```

### Configuration

The base configuration is set to the values seeded in the CleanIAM server for demo apps.

To edit the oidc configuration, go to the `src/lib/stores/auth.svelte.ts` file and set the configuration values.

### Development

```bash
# Start development server
npm run dev
# Or if using Bun
bun run dev
```

## Project Structure

- `src/lib/stores/auth.svelte.ts` - OIDC client configuration and auth utilities
- `src/routes` - SvelteKit routes including login, callback, and protected pages

## Learn More

For a complete understanding of integrating with CleanIAM, check the [official documentation](https://github.com/CleanIAM/CleanIAM).

## License

MIT

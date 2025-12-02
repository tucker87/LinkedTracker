# Docker Setup for LinkedTracker

This guide explains how to run the LinkedTracker application using Docker.

## Prerequisites

- Docker Desktop installed (includes Docker and Docker Compose)
- At least 4GB of available RAM

## Quick Start

To build and start both the API and UI containers:

```bash
docker-compose up --build
```

This command will:
1. Build the .NET API container
2. Build the Vue.js UI container
3. Start both containers
4. Create a network for them to communicate

## Accessing the Application

Once the containers are running:

- **UI**: http://localhost:8080
- **API**: http://localhost:5000
- **API (HTTPS)**: https://localhost:5001

## Docker Commands

### Start containers (detached mode)
```bash
docker-compose up -d
```

### Stop containers
```bash
docker-compose down
```

### View logs
```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f api
docker-compose logs -f ui
```

### Rebuild containers after code changes
```bash
docker-compose up --build
```

### Remove containers and volumes
```bash
docker-compose down -v
```

## Container Details

### API Container
- **Base Image**: mcr.microsoft.com/dotnet/aspnet:10.0
- **Build Image**: mcr.microsoft.com/dotnet/sdk:10.0
- **Exposed Ports**: 5000 (HTTP), 5001 (HTTPS)
- **Project**: LinkedTracker.Api

### UI Container
- **Base Image**: nginx:alpine
- **Build Image**: node:20-alpine
- **Exposed Port**: 8080
- **Project**: LinkedTracker.UI
- **Web Server**: Nginx

## Environment Variables

You can customize the setup by modifying environment variables in `docker-compose.yml`:

### API Environment Variables
- `ASPNETCORE_ENVIRONMENT`: Set to Development or Production
- `ASPNETCORE_URLS`: URLs the API listens on

### UI Environment Variables
- `VITE_API_BASE_URL`: The base URL for API requests

## Troubleshooting

### Port conflicts
If ports 5000, 5001, or 8080 are already in use, modify the port mappings in `docker-compose.yml`:

```yaml
ports:
  - "YOUR_PORT:80"  # Change YOUR_PORT to an available port
```

### Build failures
1. Ensure you're in the root directory of the project
2. Clear Docker cache: `docker-compose build --no-cache`
3. Check Docker logs: `docker-compose logs`

### Container communication issues
- Ensure both containers are on the same network (linkedtracker-network)
- Check that the UI is pointing to the correct API URL

## Development Tips

For active development, you may want to:
1. Use volume mounts to sync code changes
2. Run the containers in watch mode
3. Use a separate `docker-compose.dev.yml` for development-specific settings

## Production Considerations

For production deployment:
1. Update `ASPNETCORE_ENVIRONMENT` to Production
2. Configure proper SSL certificates
3. Use environment-specific configuration files
4. Set up proper logging and monitoring
5. Configure resource limits in docker-compose.yml

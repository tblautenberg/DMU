# Official Microsoft .NET build image with .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory to /app
WORKDIR /app

# Copy the entire repository to the working directory in the container
COPY . .

# Change to the directory containing your main .csproj file
WORKDIR /app

# Restore any dependencies (e.g., NuGet packages) using the .csproj file
RUN dotnet restore "Calculator(GitHubActions).csproj"

# Build the application using the .csproj file
RUN dotnet build "Calculator(GitHubActions).csproj" --configuration Release --output /app/build

# Use the official .NET 8.0 runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output to the runtime container
COPY --from=build /app/build .

# Expose the port that your application is listening on
EXPOSE 8080

# Define the entry point for the container to run your app
ENTRYPOINT ["dotnet", "Calculator(GitHubActions).dll"]


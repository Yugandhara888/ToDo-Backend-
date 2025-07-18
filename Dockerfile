# Use official .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the code and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose port
EXPOSE 5055

# Run the app
ENTRYPOINT ["dotnet", "ToDoApi.dll"]

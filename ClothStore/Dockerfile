# base image for the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# set the working directory in the container
WORKDIR /app
# copy the csproj and restore as distinct layers
COPY . ./

# restore the dependencies
RUN dotnet restore

# publish the application
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
# set the working directory in the container
WORKDIR /app
# copy the build app to the runtime image
COPY --from=build /app/out .
# expose the port the app runs on

# set the environment variable for ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80
# define the entry point for the application
ENTRYPOINT ["dotnet", "ClothStore.dll"]



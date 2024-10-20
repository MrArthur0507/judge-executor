
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

COPY *.sln .
COPY Executor.Api/Executor.Api.csproj Executor.Api/
COPY Executor.Models/Executor.Models.csproj Executor.Models/


RUN dotnet restore

COPY . .


RUN dotnet publish Executor.Api/Executor.Api.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime


WORKDIR /app


COPY --from=build /app/publish .


EXPOSE 5000


ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "Executor.Api.dll"]

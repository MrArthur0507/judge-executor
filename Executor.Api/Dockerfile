
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source


COPY Executor.Api/Executor.Api.csproj Executor.Api/
COPY Executor.Models/Executor.Models.csproj Executor.Models/
COPY Executor.Contracts/Executor.Contracts.csproj Executor.Contracts/
COPY Executor.Services/Executor.Services.csproj Executor.Services/
RUN dotnet restore Executor.Api/Executor.Api.csproj

COPY Executor.Api/  Executor.Api/
COPY Executor.Models/ Executor.Models/
COPY Executor.Contracts/ Executor.Contracts/
COPY Executor.Services/ Executor.Services/

RUN dotnet publish Executor.Api/Executor.Api.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime


WORKDIR /app


COPY --from=build /app/publish .


EXPOSE 5900


ENV ASPNETCORE_URLS=http://*:5900
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "Executor.Api.dll"]

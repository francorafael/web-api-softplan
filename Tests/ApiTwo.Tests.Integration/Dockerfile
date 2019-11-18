FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Tests/ApiTwo.Tests.Integration/ApiTwo.Tests.Integration.csproj", "Tests/ApiTwo.Tests.Integration/"]
RUN dotnet restore "Tests/ApiTwo.Tests.Integration/ApiTwo.Tests.Integration.csproj"
COPY . .
WORKDIR "/src/Tests/ApiTwo.Tests.Integration"
RUN dotnet build "ApiTwo.Tests.Integration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTwo.Tests.Integration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTwo.Tests.Integration.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Tests/ApiOne.Tests.Integration/ApiOne.Tests.Integration.csproj", "Tests/ApiOne.Tests.Integration/"]
RUN dotnet restore "Tests/ApiOne.Tests.Integration/ApiOne.Tests.Integration.csproj"
COPY . .
WORKDIR "/src/Tests/ApiOne.Tests.Integration"
RUN dotnet build "ApiOne.Tests.Integration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiOne.Tests.Integration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiOne.Tests.Integration.dll"]
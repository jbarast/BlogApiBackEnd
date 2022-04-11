FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BlogApiBackEnd.Infrastructure.Api/BlogApiBackEnd.Infrastructure.Api.csproj", "BlogApiBackEnd.Infrastructure.Api/"]
RUN dotnet restore "BlogApiBackEnd.Infrastructure.Api/BlogApiBackEnd.Infrastructure.Api.csproj"
COPY . .
WORKDIR "/src/BlogApiBackEnd.Infrastructure.Api"
RUN dotnet build "BlogApiBackEnd.Infrastructure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogApiBackEnd.Infrastructure.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogApiBackEnd.Infrastructure.Api.dll"]

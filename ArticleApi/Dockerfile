#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ArticleApi/ArticleApi.csproj", "ArticleApi/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "ArticleApi/ArticleApi.csproj"
COPY . .
WORKDIR "/src/ArticleApi"
RUN dotnet build "ArticleApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArticleApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArticleApi.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FrontEndMicroService/BackAdmin/FrontEndMicroService.BackAdmin.csproj", "FrontEndMicroService/BackAdmin/"]
RUN dotnet restore "FrontEndMicroService/BackAdmin/FrontEndMicroService.BackAdmin.csproj"
COPY . .
WORKDIR "/src/FrontEndMicroService/BackAdmin"
RUN dotnet build "FrontEndMicroService.BackAdmin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrontEndMicroService.BackAdmin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrontEndMicroService.BackAdmin.dll"]
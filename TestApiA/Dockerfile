#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestApiA/TestApiA.csproj", "TestApiA/"]
RUN dotnet restore "TestApiA/TestApiA.csproj"
COPY . .
WORKDIR "/src/TestApiA"
RUN dotnet build "TestApiA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApiA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApiA.dll"]
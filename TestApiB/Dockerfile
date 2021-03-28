#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
RUN apt-get update && apt-get install -y libc-dev && apt-get clean
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestApiB/TestApiB.csproj", "TestApiB/"]
RUN dotnet restore "TestApiB/TestApiB.csproj"
COPY . .
WORKDIR "/src/TestApiB"
RUN dotnet build "TestApiB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApiB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApiB.dll"]
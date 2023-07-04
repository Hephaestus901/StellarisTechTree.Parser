FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/StellarisTechTree.WebApp/StellarisTechTree.WebApp.csproj", "src/StellarisTechTree.WebApp/"]
RUN dotnet restore "src/StellarisTechTree.WebApp/StellarisTechTree.WebApp.csproj"
COPY . .
WORKDIR "/src/src/StellarisTechTree.WebApp"
RUN dotnet build "StellarisTechTree.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StellarisTechTree.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StellarisTechTree.WebApp.dll"]

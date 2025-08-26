# Étape build : utiliser l'image officielle .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier le csproj et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier le reste du code et publier
COPY . ./
RUN dotnet publish -c Release -o out

# Étape runtime : image ASP.NET Core 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copier les fichiers publiés depuis l'étape build
COPY --from=build /app/out .

# Exposer le port
EXPOSE 7005

# Forcer ASP.NET Core à écouter sur toutes les interfaces
ENV ASPNETCORE_URLS=http://+:7005

# Lancer l'application
ENTRYPOINT ["dotnet", "ProjetTest.dll"]

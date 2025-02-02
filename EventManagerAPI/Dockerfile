# Koristi zvaničnu .NET SDK sliku za build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiraj .csproj fajlove i restore pakete
COPY *.csproj .
RUN dotnet restore

# Kopiraj sve fajlove i izvrši build
COPY . .
RUN dotnet publish -c Release -o /app

# Koristi zvaničnu .NET runtime sliku za pokretanje aplikacije
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Kopiraj buildovane fajlove iz build slike
COPY --from=build /app .

# Postavi port na kojem će aplikacija slušati
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Pokreni aplikaciju
ENTRYPOINT ["dotnet", "EventManagerAPI.dll"]
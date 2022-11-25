FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Aoc2022.csproj", "."]
RUN dotnet restore "Aoc2022.csproj"
COPY . .
RUN dotnet build "Aoc2022.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aoc2022.csproj" -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80

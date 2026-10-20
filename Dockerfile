 HEAD
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY ["HoraDeAprender.API/HoraDeAprender.API.csproj", "HoraDeAprender.API/"]
RUN dotnet restore "HoraDeAprender.API/HoraDeAprender.API.csproj"
COPY . .
WORKDIR "/app/HoraDeAprender.API"
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY ["HoraDeAprender.API/HoraDeAprender.API.csproj", "HoraDeAprender.API/"]
RUN dotnet restore "HoraDeAprender.API/HoraDeAprender.API.csproj"
COPY . .
WORKDIR "/app/HoraDeAprender.API"
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "HoraDeAprender.API.dll"]
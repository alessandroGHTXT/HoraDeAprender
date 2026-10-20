FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar os ficheiros de projeto e restaurar dependências
COPY ["HoraDeAprender.API/HoraDeAprender.API.csproj", "HoraDeAprender.API/"]
RUN dotnet restore "HoraDeAprender.API/HoraDeAprender.API.csproj"

# Copiar o resto do código e compilar
COPY . .
WORKDIR "/app/HoraDeAprender.API"
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "HoraDeAprender.API.dll"]
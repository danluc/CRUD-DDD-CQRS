FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS iniciar-sdk
WORKDIR /app

WORKDIR /src
COPY ["Usuarios.API/Usuarios.API.csproj", "Usuarios.API/"]
COPY ["Usuario.Servico/Usuario.Servico.csproj", "Usuario.Servico/"]
COPY ["Usuario.Data/Usuario.Data.csproj", "Usuario.Data/"]
COPY ["Usuarios.Dominio/Usuarios.Dominio.csproj", "Usuarios.Dominio/"]
RUN dotnet restore "Usuarios.API/Usuarios.API.csproj"
COPY . .
WORKDIR "/src/Usuarios.API"
RUN dotnet build "Usuarios.API.csproj" -c Release -o /app/build

FROM iniciar-sdk AS publish
RUN dotnet publish "Usuarios.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/runtime:2.2
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Usuarios.API.dll"]
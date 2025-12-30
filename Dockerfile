# Use a imagem de runtime do .NET Core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copie o arquivo csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o resto do código e compila
COPY . ./
RUN dotnet publish -c Release -o out

# Construa a imagem de runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expõe a porta e inicia o aplicativo
EXPOSE 80
ENTRYPOINT ["dotnet", "MeuSite.dll"]

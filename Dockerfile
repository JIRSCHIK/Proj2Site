# Construa a imagem de runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expõe a porta e inicia o aplicativo
EXPOSE 80
ENTRYPOINT ["dotnet", "MeuSite.dll"]

# Publish o projeto na opção Publish to Folder
# docker build -t produtoapi/testegslab-luicil -f Dockerfile .

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ProdutoAPI.dll"]

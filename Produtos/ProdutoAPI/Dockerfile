# Publish o projeto na opção Publish to Folder
# docker build -t produtoapi/testegslab-luicil -f Dockerfile .

#docker container create -p 5000:5000 --name produtoapi -e DBHOST="172.17.0.2" produtoapi/testegslab-luicil

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 5000
LABEL version="1.0"

ENV ASPNETCORE_URLS=http://*:5000
# ENV DBHOST=172.17.0.2

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ProdutoAPI.dll"]

# Publish o projeto na opção Publish to Folder
# docker build -t produtofe/testegslab-luicil -f Dockerfile .

# docker container create -p 41779:41779 --name produtofe -e APIUrl="http://172.17.0.3:5000" produtofe/testegslab-luicil

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 41779
LABEL version="1.0"

ENV ASPNETCORE_URLS=http://*:41779
# ENV APIUrl="http://172.17.0.3:5000"
ENV ASPNETCORE_ENVIRONMENT=Development

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ProdutoFE.dll"]


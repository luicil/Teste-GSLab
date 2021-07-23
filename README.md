# Teste-GSLab
Teste C# Fullstack Developer para a GSLab

Olá, fiz este desafio baseado no teste C# Fullstack developer para a GSLab.

O teste é composto por dois aplicativos:
  ProdutoAPI:
    é uma API que permite a manutenção de uma tabela de produtos hipotética, de acordo com a descrição do desafio, onde é possível
    de requisições fazer a manutenção dos dados (incluir/excluir/alterar/listar). A API é quem faz toda a comunicação com o banco de dados.
    Utilizei como banco de dados o MySQL e a API cria um banco e tabela com o nome Produtos caso não existam. a API precisa saber o endereço IP
    e porta do servidor MySQL (padrão localhost:3306).
    Porta:
      A API usa a porta 5000 para a comunicação.
    Conteinerização com Docker:
      Imagem:
        É possível criar uma imagem DOCKER da API, para isso basta compilar o projeto e publicar utilizando a opção
        Publish to Folder do próprio VisualStudio (certifique-se que a publicação está na pasta: bin/Release/net5.0/publish,
        dentro da pasta do projeto.
        Após a publicação do projeto basta abrir o terminal, ir para a pasta onde está o projeto e executar o comando do docker:
        docker build -t <nome-da-imagem-docker> -f Dockerfile . (<== o ponto é necessário no comando), substitua <nome-da-imagem-docker>
        pelo nome da imagem para o docker.
        
      Variáveis de Ambiente:
        A API expõe algumas variáveis de ambiente para informar o endereço IP, porta, usuário e senha do servidor MySQL.
        ** Estas variáveis são utilizadas para a crição de conteiners e uso com o docker.
        Estas variáveis são:
          DBHOST = Endereço IP do servidor MySQL
          DBPORT = Porta do servidor MySQL
          DBUSER = usuário para acesso ao servidor MySQL
          DBPASSWORD = Senha para acesso ao servidor MySQL
                  
      Conteiner:
        É possível criar containers para serem executados no Docker permitindo escalar a aplicação através do comando: docker container create,
        veja um exemplo:
          docker container create -p 5000:5000 --name produtoapi -e DBHOST="172.17.0.2" produtoapi/testegslab-luicil
      
  
  
  ProdutoFE: é um aplicativo web que expõe um frontend para a edição dos dados da tabela hipotética de produtos do desafio através do consumo da API

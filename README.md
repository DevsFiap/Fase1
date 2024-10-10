# Tech Challenge - Fase 1
Tech Challenge é o projeto da fase que engloba os conhecimentos obtidos em todas as disciplinas dela.<br>
Esta é uma atividade que, a princípio, deve ser desenvolvida em grupo. É importante atentar-se ao prazo de entrega,<br>
uma vez que essa atividade é obrigatória e vale 60% da nota de todas as disciplinas da fase.<br>
<br>O problema<br>
O Tech Challenge desta fase será desenvolver um aplicativo utilizando a plataforma .NET 8 para cadastro de contatos regionais, considerando a persistência de dados e a qualidade do software.<br>

<br>Requisitos Funcionais<br>
● Cadastro de contatos: permitir o cadastro de novos contatos, incluindo nome, telefone e e-mail. Associe cada contato a um DDD correspondente à região.<br>
● Consulta de contatos: implementar uma funcionalidade para consultar e visualizar os contatos cadastrados, os quais podem ser filtrados pelo DDD da região.<br>
● Atualização e exclusão: possibilitar a atualização e exclusão de contatos previamente cadastrados.<br>
<br>
Requisitos Técnicos: <br>
● Persistência de Dados: utilizar um banco de dados para armazenar as informações dos contatos. Escolha entre Entity Framework Core ou Dapper para a camada de acesso a dados. <br>
● Validações: implementar validações para garantir dados consistentes (por exemplo: validação de formato de e-mail, telefone, campos obrigatórios).<br>
● Testes Unitários: desenvolver testes unitários utilizando xUnit ou NUnit. <br>

<br>Entrega<br>
Para que possamos avaliar, esperamos um vídeo demonstrando os passos utilizados para o desenvolvimento do projeto, a arquitetura escolhida, o banco de dados e principalmente o projeto funcionando com os requisitos básicos.
Observações <br>
O foco principal é a qualidade do código, as boas práticas de desenvolvimento e o uso eficiente da plataforma .NET 8. Este desafio é uma oportunidade para demonstrar habilidades em persistência de dados, arquitetura de software e testes, além de boas práticas de desenvolvimento.<br>
Ficou com alguma dúvida? Não deixe de nos chamar no Discord para que alguém da equipe te ajude!

<br>Como rodar migration localmente<br>

Rodar no package manager console, selecionando o projeto: TechChallangeFase01.Infra.Data

add-migration adicionando-validacoes -StartupProject TechChallangeFase01.Infra.Data

update-database -StartupProject TechChallangeFase01.Infra.Data
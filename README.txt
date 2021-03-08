- Projeto criado seguindo padrão MVC, com backend em .NetCore e banco de dados SQLite

- A inserção de produtos no carrinho é feita após cadastro e login do usuário.

- Disponibilizado dois botões para visualização de uso de APIs, porém os outros métodos disponíveis podem ser acessados
normalmente em plataformas como Postman.

- Rotas de API disponíveis:

	- Produto: 
	api/produtos, api/produtos/{id}, api/produtos/desativar/{id}, api/produtos/adicionarproduto(Post, recebe objeto da classe produto),
        api/produtos/atualizarproduto(Post, recebe objeto da classe produto)

	- Venda:
	api/vendas, api/vendas/{id}, api/vendas/desativar/{id}, api/vendas/adicionarvenda(Post, recebe objeto da classe Venda),
        api/vendas/atualizarvenda(Post, recebe objeto da classe Venda)

	- Usuario:
	api/usuarios, api/usuarios/{id}, api/usuarios/desativar/{id}, api/usuarios/adicionarusuario(Post, recebe objeto da classe Usuario),
        api/produtos/atualizarusuario(Post, recebe objeto da classe Usuario), api/produtos/validarusuario(Post, recebe objeto da classe produto)

- Possíveis melhorias para evolução do projeto:

- Validação de CPF
- Melhorar front-end
- Disponibilização de mais dados públicos
- Inserção de autenticação para APIs
- Busca de Vendas não concluídas
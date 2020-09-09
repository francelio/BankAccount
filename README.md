# README #
### Teste prático: ###

## regra de negócio: ##
	
* criar um microservices que, através de um http post efetue uma operação de débito (origem) e crédito (destino) nas contas correntes.

* entidades: contacorrente, lançamentos (você pode incrementar com  outras entidades se achar necessário)

* Parâmetros de entrada:
	conta origem
	conta destino
	valor

* Parâmetros de saída:
	http status code	
	

### informações adicionais: ###
* o método “post” deverá receber os parâmetros no body da requisição em formato json

* UTILIZE Domain Driven Design

* serão avaliados critérios de arquitetura como separação de responsabilidade, clean code, segurança e testes

* tecnologias que você pode utilizar .net core 2.X, c#, xunits (testes)

* no término do projeto, publique o código em um repositório no git-hub

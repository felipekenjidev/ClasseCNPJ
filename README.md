# Classe C# para Validação de CNPJ
Uma Classe C# com métodos e propriedades para realizar a verificação do CNPJ (Cadastro Nacional de Pessoa Jurídica), formatando seus dígitos e indicando se o documento digitado é Verdadeiro ou Falso.

# Preparação
Antes de poder utilizar a Classe CNPJ, é necessário importar para dentro do projeto, colocando o próprio arquivo `clsCNPJ.cs` dentro do projeto ou adicionando uma referência para a DLL `clsCNPJ.dll`.

# Como Funciona?
Para utilizar basta instanciar a Classe CNPJ, passando no parâmetro o CNPJ a ser verificado. Pode passar o CNPJ tanto com as pontuações como `76.056.852/0001-62` ou sem como `76056852000162`.

`CNPJ variavel = new CNPJ("76056852000162");`

Após instanciar a Classe, apenas é preciso acessar o método `Validar()` que o resultado da verificação será gerado.

`bool resposta = variavel.Validar()`

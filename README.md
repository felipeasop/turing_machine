# Simulador de Máquina de Turing

Este projeto implementa um simulador de Máquina de Turing em C#. A definição da máquina é lida a partir de um arquivo JSON e as entradas a partir de um arquivo de texto (ex: .in). O simulador gera um arquivo de saída .txt com o conteúdo final da fita para cada entrada e imprime no console 1 (aceita) ou 0 (rejeita).

## Estrutura do projeto

-   **Specifications.cs**: Descreve a estrutura do arquivo de configuração da máquina (JSON).
-   **Parser.cs**: Lê o arquivo JSON e cria a instância da máquina.
-   **TuringMachine.cs**: Contém a lógica principal do simulador e o ciclo de execução.
-   **State.cs**: Representa os estados e suas transições.
-   **Transition.cs**: Representa uma transição individual da máquina.
-   **Tape.cs**: Simula a fita infinita da máquina de turing.
-   **Program.cs**: Executa tudo, responsável por ler os argumentos, arquivos e imprimir a saída.

## Formato do JSON

O arquivo de definição da máquina deve seguir este formato:

``` json
{
  "initial": 0,
  "final": [2],
  "white": "_",
  "transitions": [
    { "from": 0, "to": 1, "read": "a", "write": "_", "dir": "R" },
    { "from": 1, "to": 2, "read": "_", "write": "_", "dir": "R" }
  ]
}
```

-   **initial**: Estado inicial (inteiro).
-   **final**: Lista de estados finais de aceitação (lista de inteiros).
-   **white**: Caractere que representa um espaço em branco na fita.
-   **transitions**: Lista contendo todas as transições da máquina.

Cada transição contém: - **from**: Estado de origem. - **to**: Estado de destino. - **read**: Símbolo a ser lido da fita. - **write**: Símbolo a ser escrito na fita. - *dir**: Direção do movimento do cabeçote (L para esquerda ou R para direita).

## Formato do Arquivo de Entrada

Um arquivo de texto (ex: .in) contendo uma cadeia de símbolos.

**Exemplo (entradas.in):**

  aaabbb

## Como Executar

### Requisitos

- .NET SDK

Para checar se está instalado basta abrir a linha de comandos e inserir o comando:

```bash
dotnet --version
```

Caso já esteja na máquina

### Rodando o projeto

Para compilar e executar o projeto, use o seguinte comando no terminal, dentro da pasta do projeto:

``` bash
dotnet run -- <arquivo_definicao.json> <arquivo_entrada.in>
```

-   `<arquivo_definicao.json>`: Caminho para o arquivo de definição da máquina.
-   `<arquivo_entrada.in>`: Caminho para o arquivo com as cadeias de entrada.

O programa irá gerar automaticamente o arquivo de saída na mesma pasta.

## Saída

-   **Console**: Imprime 1 se a entrada for aceita ou 0 se for rejeitada (uma linha para cada entrada).
-   **Arquivo de Saída**: É criado um arquivo `<nome_do_arquivo_de_entrada>.txt` com o conteúdo final da fita.

**Exemplo de execução:**

``` bash
dotnet run -- definicao.json entrada.in
```

**Saída no Console:**

    1
    60 ms (tempo de execução)

**Conteúdo do arquivo entradas.txt:**

    aaaabbcccc

## Regras e Validações Implementadas

-   **Direções Válidas**: Apenas as direções L (esquerda) e R (direita) são permitidas.
-   **Transições em Estados Finais**: A definição da máquina é considerada inválida se um estado final possuir transições de saída.
-   **Transições Duplicadas**: A definição é inválida se um mesmo estado possuir mais de uma transição para o mesmo símbolo de leitura.
-   **Limite de Passos**: Para evitar loops infinitos, a execução de cada entrada é interrompida se exceder o limite de passos (pode ser alterado no código).

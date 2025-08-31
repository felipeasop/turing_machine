# Simulador de Máquina de Turing em C#

Este é um programa de linha de comando que simula o funcionamento de uma Máquina de Turing, conforme as especificações de um ficheiro `.json`.

## Pré-requisitos

Para executar este programa, precisa de ter o **.NET SDK** (versão 6.0 ou superior) instalado no seu sistema.

- **Download:** [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
- Para verificar se já o tem instalado, abra um terminal e execute:
  ```bash
  dotnet --version
  ```

## Estrutura dos Ficheiros

Para que o programa funcione, organize os seus ficheiros numa única pasta da seguinte forma:

```
/SeuProjeto/
|-- Program.cs
|-- TuringMachine.cs
|-- Tape.cs
|-- State.cs
|-- Transition.cs
|-- JsonReader.cs
|
|-- maquina.json      <-- O seu ficheiro de definição da máquina
|-- entrada.in        <-- O seu ficheiro com as palavras a testar
```

## Instruções de Execução

Siga estes passos simples para rodar o programa:

### Passo 1: Abrir o Terminal

Abra a sua ferramenta de linha de comando preferida (Terminal, PowerShell, Prompt de Comando, etc.).

### Passo 2: Navegar até à Pasta do Projeto

Use o comando `cd` para entrar na pasta onde guardou todos os ficheiros.

```bash
cd caminho/para/SeuProjeto
```

### Passo 3: Inicializar o Projeto (Apenas na primeira vez)

Execute o comando abaixo para criar o ficheiro de projeto (`.csproj`) necessário para a compilação.

```bash
dotnet new console
```
*Este comando irá criar um novo `Program.cs`. Pode apagá-lo ou substituí-lo pelo ficheiro que já tem.*

### Passo 4: Executar a Simulação

Agora, execute o programa com o seguinte comando, passando o nome do ficheiro da máquina e o nome do ficheiro de entrada como argumentos.

```bash
dotnet run -- maquina.json entrada.in
```

**Importante:** Os dois traços (`--`) servem para separar os argumentos do comando `dotnet` dos argumentos do **seu programa**.

## O que Esperar

Após executar o comando:

1.  **No Terminal:** Irá ver uma sequência de `1` (aceita) ou `0` (rejeita) para cada palavra no seu ficheiro `entrada.in`.
2.  **Na Pasta do Projeto:** Um ficheiro de saída será criado (ex: `saidaentrada.txt`) com o conteúdo final da fita para cada palavra processada.

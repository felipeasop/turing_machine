# Simulador de Máquina de Turing

Simulador em C# para Máquinas de Turing. A definição da máquina é lida em formato **JSON** e os testes de palavras são lidos de arquivos `.txt`. A saída informa no console se a palavra foi aceita (`1`) ou rejeitada (`0`) e grava a fita final num arquivo `.txt`.

---

## Funcionalidade das Classes

- **`Transition`**
  Representa uma única regra de transição. Contém informações sobre o estado de origem, o símbolo lido, o símbolo a ser escrito, a direção do movimento e o estado de destino.

- **`State`**
  Representa um estado da máquina. Armazena suas transições de forma otimizada num dicionário para acesso rápido.

- **`Tape`**
  Simula a fita infinita da máquina de forma eficiente, usando um dicionário que armazena apenas as células não-brancas.

- **`TuringMachine`**
  Orquestra toda a simulação. Carrega a configuração da máquina, gerencia o estado atual e a fita, e executa o ciclo de computação passo a passo.

- **`JsonReader`**
  Classe auxiliar que lê e interpreta o arquivo de entrada com os dados da máquina no formato JSON, utilizando a biblioteca `System.Text.Json`.

- **`Program`**
  Contém a classe principal (`Main`). Recebe os argumentos da linha de comando, chama as outras classes para executar os testes e gera a saída.

---

## Rodando o Simulador

### Requisitos

- **.NET SDK** (versão 6.0 ou superior)

---

### Instalação

Para preparar o ambiente, coloque todos os ficheiros `.cs` fornecidos numa única pasta.

---

### Execução

A execução é feita através da interface de linha de comando do .NET. Para rodar o simulador, siga as etapas abaixo:

1. **Prepare os arquivos de entrada:**
   Na mesma pasta onde colocou os ficheiros `.cs`, adicione os seus arquivos de entrada:

   - Um arquivo `.json` com a definição da máquina (ex: `maquina.json`).
   - Um arquivo `.txt` com as palavras de teste, uma por linha (ex: `problema.txt`).

2. **Navegue até o diretório do projeto no seu terminal:**

   ```bash
   cd caminho/para/o/projeto
   ```

3. **Inicialize o projeto (apenas na primeira vez):**

   ```bash
   dotnet new console
   ```

4. **Execute o simulador:**

   ```bash
   dotnet run -- maquina.json problema.txt
   ```

   A saída será exibida no console (`1` ou `0`) e gravada num arquivo `saida_problema.txt`.

---

## Formato dos Arquivos

### Arquivo de Especificações (`.json`)

```json
{
    "initial" : 0,
    "final" : [4],
    "white" : "_",
    "transitions" : [
        {"from": 0, "to": 1, "read": "a", "write": "A", "dir":"R"},
        {"from": 1, "to": 1, "read": "a", "write": "a", "dir":"R"},
        {"from": 1, "to": 1, "read": "B", "write": "B", "dir":"R"},
        {"from": 1, "to": 2, "read": "b", "write": "B", "dir":"L"},
        {"from": 2, "to": 2, "read": "B", "write": "B", "dir":"L"},
        {"from": 2, "to": 2, "read": "a", "write": "a", "dir":"L"},
        {"from": 2, "to": 0, "read": "A", "write": "A", "dir":"R"},
        {"from": 0, "to": 3, "read": "B", "write": "B", "dir":"R"},
        {"from": 3, "to": 3, "read": "B", "write": "B", "dir":"R"},
        {"from": 3, "to": 4, "read": "_", "write": "_", "dir":"L"}
    ]
}
```

### Arquivo de Problema (`.txt`)

```text
aaabbb
aabb
ab
```

### Saída no Console

Uma linha por teste, indicando se foi aceite (`1`) ou não (`0`).

```text
1
```
```text
0
```

### Saída no arquivo `saida_*.txt`

Gerado automaticamente com o resultado da fita para cada teste.

```text
Entrada: aaabbb
Fita final: AABBB_

Entrada: aabb
Fita final: AABB

Entrada: ab
Fita final: AB_
```
.
.---

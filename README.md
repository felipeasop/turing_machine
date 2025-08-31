# Simulador de Máquina de Turing

Este projeto implementa um simulador de Máquina de Turing em C#.
A definição da máquina é lida a partir de um arquivo JSON e as entradas a partir de um arquivo `.in`.
O simulador gera um arquivo de saída `.out.txt` com o conteúdo final da fita para cada entrada e imprime no console `1` (aceita) ou `0` (rejeita).
---

## Estrutura do projeto

- `Definition.cs` → descreve a configuração da máquina (JSON).
- `Parser.cs` → lê o JSON e cria a máquina.
- `TuringMachine.cs` → lógica principal do simulador.
- `State.cs` → representa estados e suas transições.
- `Transition.cs` → representa uma transição individual.
- `Tape.cs` → simula a fita infinita.
- `Program.cs` → ponto de entrada, cuida da I/O (arquivos e console).

---

## Formato do JSON

Exemplo (`duplo_bal.json`):

```json
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
- `initial`: estado inicial
- `final`: lista de estados finais (aceitação)
- `white`: símbolo branco
- `transitions`: lista de transições

Cada transição contém:
- `from`: estado de origem
- `to`: estado de destino
- `read`: símbolo a ser lido
- `write`: símbolo a ser escrito
- `dir`: direção (`L` ou `R`)

---
## Formato do arquivo de entrada

Um arquivo `.in` contendo uma entrada por linha.  
Exemplo (`duplobal3.in`):

```
aabb
abb
aaabbb
```

---

## Como executar

Compile e rode o projeto com `dotnet`:

```sh
dotnet run -- <def.json> <input.in>
```

- `<def.json>` → arquivo de definição da máquina (em JSON).
- `<input.in>` → arquivo com entradas, uma por linha.

O programa gera automaticamente o arquivo de saída `<input>.out.txt`.

---

## Saída

- **Console**: imprime `1` se a entrada for aceita ou `0` se for rejeitada (uma linha por entrada).
- **Arquivo `.out.txt`**: cada linha contém o conteúdo final da fita correspondente à entrada.

.Exemplo:

```sh
dotnet run -- duplo_bal.json duplobal3.in
```

Console:
```
1
0
1
```

Arquivo `duplobal3.out.txt`:
```
__bb
abb
___
```

---

## Regras e Validações

- Apenas direções `L` e `R` são permitidas.
- Estados finais não podem possuir transições de saída (será erro de definição).
- Transições duplicadas para o mesmo símbolo em um estado também são erro.
- Um limite de passos (1.000.000 por padrão) evita loops infinitos.

.---

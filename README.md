# Prática de Grafos 1

Este projeto foi desenvolvido como atividade prática de algoritmos em grafos e implementa um grafo em memória usando matriz de adjacência. A aplicação permite inserir arestas, verificar a existência de ligações, preencher o grafo com valores aleatórios e executar uma busca em profundidade (DFS).

## Objetivo

O objetivo da atividade foi exercitar conceitos fundamentais de grafos, como:

- representação de grafos em matriz de adjacência;
- inserção de arestas com peso;
- verificação de existência de aresta;
- reset do grafo;
- geração automática de valores aleatórios;
- travessia em profundidade (Depth-First Search).

## Estrutura do projeto

O projeto contém os seguintes arquivos:

- `Program.cs`: menu interativo com as opções do programa.
- `Grafo.cs`: implementação da estrutura do grafo e dos métodos principais.
- `Pratica-Grafos-1.csproj`: configuração do projeto .NET.

## Representação do grafo

A classe `Grafo` utiliza uma matriz bidimensional:

- `matrizGrafo[8, 8]`: guarda os pesos das arestas entre os 8 vértices possíveis;
- cada posição representa a ligação entre dois vértices;
- a matriz é tratada como não direcionada, ou seja, quando uma aresta é inserida entre `v1` e `v2`, ela também é registrada na posição espelhada.

Exemplo:

- `matrizGrafo[i, j] = peso`
- `matrizGrafo[j, i] = peso`

Isso faz com que a relação seja simétrica.

## Funcionalidades implementadas

### 1) Imprimir grafo

Exibe a matriz de adjacência com os pesos das arestas e os vértices representados de `V1` a `V8`.

### 2) Inserir aresta

O usuário informa dois vértices e o peso da aresta. O sistema verifica se a ligação já existe e, caso contrário, adiciona os valores na matriz de forma espelhada.

### 3) Verificar aresta

Recebe dois vértices e verifica se existe uma ligação entre eles. Caso exista, mostra o peso da aresta.

### 4) Zerar grafo

Limpa toda a matriz, removendo todas as arestas do grafo.

### 5) Preencher com valores aleatórios

O usuário informa quantas arestas deseja gerar. O sistema preenche posições aleatórias sem repetir arestas e sem criar laços (`i != j`).

### 6) Busca em profundidade

A classe implementa uma busca em profundidade, com as estruturas:

- `cor[]`: identifica o estado do vértice (branco, azul, vermelho);
- `pred[]`: guarda o predecessor do vértice;
- `d[]`: registra o tempo de descoberta;
- `t[]`: registra o tempo de finalização.

A lógica percorre os vértices e visita os vizinhos ainda não explorados, exibindo a ordem de passagem entre os vértices.

## Menu do programa

Ao executar o programa, o usuário acessa um menu com as seguintes opções:

1. Imprimir grafo
2. Inserir aresta
3. Verificar aresta
4. Zerar grafo
5. Preencher com valores aleatórios
6. Busca de profundidade
0. Encerrar o programa

## Como rodar o programa

### Pré-requisitos

- .NET SDK instalado na máquina.
- Terminal/PowerShell ou prompt de comando.

### Passos

1. Abra o terminal na pasta do projeto:

   ```bash
   cd "C:\Users\mathe\OneDrive\Documents\4º Semestre\Algoritmos em Grafos\Atividade Prática 1\Pratica-Grafos-1"
   ```

2. Compile e execute o programa:

   ```bash
   dotnet run
   ```

3. Use o menu exibido no console para interagir com o grafo.

## Exemplo de execução

Ao iniciar, a aplicação mostra as opções disponíveis e o usuário pode, por exemplo:

- inserir arestas entre vértices;
- verificar se uma aresta existe;
- gerar um grafo aleatório;
- visualizar a ordem de visita em profundidade.

## Observações

- O grafo foi implementado com até 8 vértices.
- As arestas são tratadas como não direcionadas.
- O programa utiliza valores inteiros como pesos das arestas.
- A busca em profundidade é uma implementação básica, adequada para fins didáticos da atividade.

## Conclusão

Este projeto aplica os conceitos fundamentais de grafos em uma interface simples e interativa em C#. Ele funciona como uma ferramenta didática para visualizar estruturas de grafos e praticar algoritmos de travessia e manipulação.
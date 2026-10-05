#pragma warning disable

class Grafo
{
    public int[,] matrizGrafo;
    public int numVertice { get; private set; }
    public int numArestas { get; private set; }

    // Variáveis utilizadas pela Busca em Profundidade
    string[] cor;
    public int[] pred, d, t;

    // CONSTRUTOR
    public Grafo()
    {
        numVertice = 8;

        matrizGrafo = new int[numVertice, numVertice];

        cor = new string[numVertice];
        pred = new int[numVertice];
        d = new int[numVertice];
        t = new int[numVertice];

        ZeraGrafo();
    }

    // ZERAR GRAFO
    public void ZeraGrafo()
    {
        for (int i = 0; i < numVertice; i++)
        {
            for (int j = 0; j < numVertice; j++)
            {
                matrizGrafo[i, j] = 0;
            }
        }

        numArestas = 0;
    }

    // INSERIR ARESTA
    public void InsereAresta(int v1, int v2, int peso)
    {
        // Verifica se os vértices estão dentro do intervalo
        if (v1 < 1 || v1 > numVertice ||
            v2 < 1 || v2 > numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 1 e 8!");
            Console.ResetColor();
            return;
        }

        // Não permite uma aresta ligando o vértice a ele mesmo
        if (v1 == v2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNão é possível criar uma aresta para o próprio vértice!");
            Console.ResetColor();
            return;
        }

        // O Dijkstra precisa trabalhar com pesos positivos
        if (peso <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nO peso da aresta deve ser maior que zero!");
            Console.ResetColor();
            return;
        }

        // Converte V1...V8 para índices 0...7
        int indice1 = v1 - 1;
        int indice2 = v2 - 1;

        // Verifica se a aresta já existe
        if (matrizGrafo[indice1, indice2] != 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOs vértices já possuem uma aresta!");
            Console.ResetColor();
            return;
        }

        // Grafo não direcionado: a ligação é inserida nos dois sentidos
        matrizGrafo[indice1, indice2] = peso;
        matrizGrafo[indice2, indice1] = peso;

        numArestas++;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAresta inserida com sucesso!");
        Console.ResetColor();
    }

    // IMPRIMIR GRAFO
    public void ImprimeGrafo()
    {
        Console.WriteLine("\n    V1--V2--V3--V4--V5--V6--V7--V8-");

        for (int i = 0; i < numVertice; i++)
        {
            Console.Write($"V{i + 1}: ");

            for (int j = 0; j < numVertice; j++)
            {
                Console.Write(matrizGrafo[i, j] + " | ");
            }

            Console.WriteLine("\n-----------------------------------");
        }

        Console.WriteLine($"\nQuantidade de arestas: {numArestas}");
    }

    // VERIFICAR ARESTA
    public bool ExisteAresta(int v1, int v2)
    {
        if (v1 < 1 || v1 > numVertice ||
            v2 < 1 || v2 > numVertice)
        {
            return false;
        }

        return matrizGrafo[v1 - 1, v2 - 1] > 0;
    }


    // PREENCHER MATRIZ ALEATORIAMENTE
    // A primeira parte garante que o grafo seja CONEXO. Depois são adicionadas arestas aleatórias.
    public void PreencherMatriz(int arestas)
    {
        Random aleatorio = new Random();

        // Com 8 vértices, são necessários pelo menos 7 para que o grafo seja conexo.
        if (arestas < numVertice - 1 || arestas > 28)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nPara 8 vértices, informe entre 7 e 28 arestas.");

            Console.ResetColor();
            return;
        }

        // Limpa o grafo antes de gerar outro
        ZeraGrafo();

        // PRIMEIRA ETAPA: Cria uma estrutura em cadeia (V1 -- V2 -- V3 -- V4 -- V5 -- V6 -- V7 -- V8)
        // Dessa maneira, temos certeza de que todos os vértices estarão conectados.
        for (int i = 0; i < numVertice - 1; i++)
        {
            int peso = aleatorio.Next(1, 11);

            matrizGrafo[i, i + 1] = peso;
            matrizGrafo[i + 1, i] = peso;

            numArestas++;
        }

        // SEGUNDA ETAPA: Adiciona as arestas restantes aleatoriamente.
        while (numArestas < arestas)
        {
            int i = aleatorio.Next(0, numVertice);
            int j = aleatorio.Next(0, numVertice);

            // Evita loop e aresta repetida
            if (i != j && matrizGrafo[i, j] == 0)
            {
                int peso = aleatorio.Next(1, 11);

                matrizGrafo[i, j] = peso;
                matrizGrafo[j, i] = peso;

                numArestas++;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nMatriz preenchida com sucesso!");
        Console.WriteLine("O grafo gerado é conexo e ponderado.");
        Console.ResetColor();
    }

    // BUSCA EM PROFUNDIDADE - DFS
    public void BuscaProfundidade(int verticeInicial)
    {
        if (verticeInicial < 1 || verticeInicial > numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 1 e 8.");
            Console.ResetColor();
            return;
        }

        int origem = verticeInicial - 1;

        // Inicialização dos vetores
        for (int i = 0; i < numVertice; i++)
        {
            cor[i] = "branco";
            pred[i] = -1;
            d[i] = 0;
            t[i] = 0;
        }

        int tempo = 0;

        Console.WriteLine("\nBUSCA EM PROFUNDIDADE (DFS)");
        Console.WriteLine($"Vértice inicial: V{verticeInicial}\n");

        Visita(origem, ref tempo);

        // Caso o grafo não seja conexo, visita os demais componentes.
        for (int i = 0; i < numVertice; i++)
        {
            if (cor[i] == "branco")
            {
                Visita(i, ref tempo);
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBusca concluída!");
        Console.ResetColor();
    }

    // VISITA DA DFS
    public void Visita(int atual, ref int tempo)
    {
        cor[atual] = "azul";

        tempo++;
        d[atual] = tempo;

        for (int i = 0; i < numVertice; i++)
        {
            if (cor[i] == "branco" && matrizGrafo[atual, i] != 0)
            {
                pred[i] = atual;

                Console.WriteLine($"V{atual + 1} -> V{i + 1}");

                Visita(i, ref tempo);

                Console.WriteLine($"V{i + 1} -> V{atual + 1}");
            }
        }

        cor[atual] = "vermelho";

        tempo++;
        t[atual] = tempo;
    }

    // DIJKSTRA
    // Calcula os menores custos a partir de um vértice de origem até todos os demais vértices.
    public void Dijkstra(int verticeInicial)
    {
        // Validação do vértice inicial
        if (verticeInicial < 1 || verticeInicial > numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 1 e 8!");
            Console.ResetColor();
            return;
        }

        int origem = verticeInicial - 1;

        // Representa uma distância infinita
        const int INFINITO = int.MaxValue;

        // Guarda a menor distância encontrada
        int[] distancia = new int[numVertice];

        // Guarda o vértice anterior no caminho
        int[] anterior = new int[numVertice];

        // Indica se o vértice já foi processado
        bool[] visitado = new bool[numVertice];

        // INICIALIZAÇÃO
        for (int i = 0; i < numVertice; i++)
        {
            distancia[i] = INFINITO;
            anterior[i] = -1;
            visitado[i] = false;
        }

        // A distância da origem para ela mesma é zero
        distancia[origem] = 0;

        // PROCESSAMENTO DO DIJKSTRA
        for (int contador = 0; contador < numVertice; contador++)
        {
            int atual = -1;
            int menorDistancia = INFINITO;

            // Procura o vértice não visitado que possui a menor distância conhecida.
            for (int i = 0; i < numVertice; i++)
            {
                if (!visitado[i] &&
                    distancia[i] < menorDistancia)
                {
                    menorDistancia = distancia[i];
                    atual = i;
                }
            }

            // Se atual continuar -1, significa que não há mais vértices alcançáveis.
            if (atual == -1)
            {
                break;
            }

            // Marca o vértice como processado
            visitado[atual] = true;

            // Analisa todos os vizinhos do vértice atual.
            for (int vizinho = 0; vizinho < numVertice; vizinho++)
            {
                int peso = matrizGrafo[atual, vizinho];

                // Existe uma aresta quando o peso é maior que zero.
                if (peso > 0 && !visitado[vizinho])
                {
                    // Calcula o novo custo passando pelo vértice atual.
                    int novaDistancia =
                        distancia[atual] + peso;

                    // Se encontramos um caminho melhor, atualizamos a distância e o predecessor.
                    if (novaDistancia < distancia[vizinho])
                    {
                        distancia[vizinho] = novaDistancia;
                        anterior[vizinho] = atual;
                    }
                }
            }
        }

        // EXIBIÇÃO DOS RESULTADOS
        Console.WriteLine("\n         ALGORITMO DE DIJKSTRA");

        Console.WriteLine($"\nVértice de origem: V{verticeInicial}\n");

        Console.WriteLine("Destino\tMenor custo\tCaminho");

        Console.WriteLine("----------------------------------------------");

        for (int i = 0; i < numVertice; i++)
        {
            Console.Write($"V{i + 1}\t");

            // Caso o vértice seja inalcançável
            if (distancia[i] == INFINITO)
            {
                Console.WriteLine("Infinito\tNão existe caminho");
            }

            else
            {
                Console.Write($"{distancia[i]}\t\t");

                MostrarCaminho(anterior, i);

                Console.WriteLine();
            }
        }

        Console.WriteLine("\nDijkstra concluído com sucesso!");
    }

    // MOSTRAR CAMINHO ENCONTRADO PELO DIJKSTRA
    private void MostrarCaminho(int[] anterior, int vertice)
    {
        // Se o vértice não possui predecessor, significa que chegamos à origem.
        if (anterior[vertice] == -1)
        {
            Console.Write($"V{vertice + 1}");
            return;
        }

        // Primeiro mostra o predecessor. Depois mostra o vértice atual. Exemplo: V1 -> V3 -> V5
        MostrarCaminho(anterior, anterior[vertice]);

        Console.Write($" -> V{vertice + 1}");
    }
}
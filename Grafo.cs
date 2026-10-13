#pragma warning disable
class Grafo
{
    public int[,] matrizGrafo;
    public int numVertice { get; private set; }
    public int numArestas { get; private set; }
    private readonly string[] pontos = { "Centro de Visitantes", "Mirante", "Cachoeira", "Área de Descanso", "Restaurante", "Jardim", "Lago", "Observatório" };
    public void MostrarPontos()
    {
        Console.WriteLine("Pontos do parque:");
        for (int i = 0; i < pontos.Length; i++) Console.WriteLine($"V{i} - {pontos[i]}");
        Console.WriteLine();
    }
    string[] cor;
    public int[] pred, d, t;

    // =============================================================
    // CONSTRUTOR
    // =============================================================
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

    // =============================================================
    // ZERAR GRAFO
    // =============================================================
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

    // =============================================================
    // INSERIR ARESTA
    // =============================================================
    public void InsereAresta(int v1, int v2, int peso)
    {
        if (v1 < 0 || v1 >= numVertice || v2 < 0 || v2 >= numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 0 e 7!");
            Console.ResetColor();
            return;
        }
        if (v1 == v2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNão é possível criar uma trilha para o mesmo ponto!");
            Console.ResetColor();
            return;
        }
        if (peso <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nA distância da trilha deve ser maior que zero!");
            Console.ResetColor();
            return;
        }
        int indice1 = v1;
        int indice2 = v2;
        if (matrizGrafo[indice1, indice2] != 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOs pontos já possuem uma trilha!");
            Console.ResetColor();
            return;
        }
        matrizGrafo[indice1, indice2] = peso;
        matrizGrafo[indice2, indice1] = peso;
        numArestas++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTrilha cadastrada com sucesso!");
        Console.ResetColor();
    }

    // =============================================================
    // IMPRIMIR GRAFO
    // =============================================================
    public void ImprimeGrafo()
    {
        Console.WriteLine("\nMAPA DAS TRILHAS - MATRIZ DE DISTÂNCIAS");
        MostrarPontos();
        Console.WriteLine("    V0--V1--V2--V3--V4--V5--V6--V7-");
        for (int i = 0; i < numVertice; i++)
        {
            Console.Write($"V{i}: ");
            for (int j = 0; j < numVertice; j++)
            {
                Console.Write(matrizGrafo[i, j] + " | ");
            }
            Console.WriteLine("\n-----------------------------------");
        }
        Console.WriteLine($"\nQuantidade de trilhas: {numArestas}");
    }

    // =============================================================
    // VERIFICAR ARESTA
    // =============================================================
    public bool ExisteAresta(int v1, int v2)
    {
        if (v1 < 0 || v1 >= numVertice || v2 < 0 || v2 >= numVertice)
        {
            return false;
        }
        return matrizGrafo[v1, v2] > 0;
    }

    // =============================================================
    // PREENCHER MATRIZ ALEATORIAMENTE
    // =============================================================
    public void PreencherMatriz(int arestas)
    {
        Random aleatorio = new Random();
        if (arestas < numVertice - 1 || arestas > 28)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPara 8 pontos, informe entre 7 e 28 trilhas.");
            Console.ResetColor();
            return;
        }
        ZeraGrafo();

        // =========================================================
        // V0 -- V1 -- V2 -- V3 -- V4 -- V5 -- V6 -- V7
        // =========================================================
        for (int i = 0; i < numVertice - 1; i++)
        {
            int peso = aleatorio.Next(1, 11);
            matrizGrafo[i, i + 1] = peso;
            matrizGrafo[i + 1, i] = peso;
            numArestas++;
        }

        // =========================================================
        // SEGUNDA ETAPA
        // =========================================================
        while (numArestas < arestas)
        {
            int i = aleatorio.Next(0, numVertice);
            int j = aleatorio.Next(0, numVertice);
            if (i != j && matrizGrafo[i, j] == 0)
            {
                int peso = aleatorio.Next(1, 11);
                matrizGrafo[i, j] = peso;
                matrizGrafo[j, i] = peso;
                numArestas++;
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTrilhas geradas com sucesso!");
        Console.WriteLine("Todos os pontos estão conectados por trilhas com distâncias.");
        Console.ResetColor();
    }

    // =============================================================
    // BUSCA EM PROFUNDIDADE - DFS
    // =============================================================
    public void BuscaProfundidade(int verticeInicial)
    {
        if (verticeInicial < 0 || verticeInicial >= numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 0 e 7.");
            Console.ResetColor();
            return;
        }
        int origem = verticeInicial;
        for (int i = 0; i < numVertice; i++)
        {
            cor[i] = "branco";
            pred[i] = -1;
            d[i] = 0;
            t[i] = 0;
        }
        int tempo = 0;
        Console.WriteLine("\nBUSCA EM PROFUNDIDADE (DFS)");
        Console.WriteLine($"Ponto inicial: V{verticeInicial}\n");
        Visita(origem, ref tempo);
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

    // =============================================================
    // VISITA DA DFS
    // =============================================================
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
                Console.WriteLine($"V{atual} -> V{i}");
                Visita(i, ref tempo);
                Console.WriteLine($"V{i} -> V{atual}");
            }
        }
        cor[atual] = "vermelho";
        tempo++;
        t[atual] = tempo;
    }

    // =============================================================
    // DIJKSTRA
    // =============================================================
    public void Dijkstra(int verticeInicial)
    {
        if (verticeInicial < 0 || verticeInicial >= numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 0 e 7!");
            Console.ResetColor();
            return;
        }
        int origem = verticeInicial;
        const int INFINITO = int.MaxValue;
        int[] distancia = new int[numVertice];
        int[] anterior = new int[numVertice];
        bool[] visitado = new bool[numVertice];

        // =========================================================
        // INICIALIZAÇÃO
        // =========================================================
        for (int i = 0; i < numVertice; i++)
        {
            distancia[i] = INFINITO;
            anterior[i] = -1;
            visitado[i] = false;
        }
        distancia[origem] = 0;

        // =========================================================
        // PROCESSAMENTO DO DIJKSTRA
        // =========================================================
        for (int contador = 0; contador < numVertice; contador++)
        {
            int atual = -1;
            int menorDistancia = INFINITO;
            for (int i = 0; i < numVertice; i++)
            {
                if (!visitado[i] && distancia[i] < menorDistancia)
                {
                    menorDistancia = distancia[i];
                    atual = i;
                }
            }
            if (atual == -1)
            {
                break;
            }
            visitado[atual] = true;
            for (int vizinho = 0; vizinho < numVertice; vizinho++)
            {
                int peso = matrizGrafo[atual, vizinho];
                if (peso > 0 && !visitado[vizinho])
                {
                    int novaDistancia = distancia[atual] + peso;
                    if (novaDistancia < distancia[vizinho])
                    {
                        distancia[vizinho] = novaDistancia;
                        anterior[vizinho] = atual;
                    }
                }
            }
        }

        // =========================================================
        // EXIBIÇÃO DOS RESULTADOS
        // =========================================================
        Console.WriteLine("\n         ALGORITMO DE DIJKSTRA");
        Console.WriteLine($"\nPonto de origem: V{verticeInicial}\n");
        Console.WriteLine("Destino\tMenor distância\tCaminho");
        Console.WriteLine("----------------------------------------------");
        for (int i = 0; i < numVertice; i++)
        {
            Console.Write($"V{i}\t");
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

    // =============================================================
    // MOSTRAR CAMINHO DO DIJKSTRA
    // =============================================================
    private void MostrarCaminho(int[] anterior, int vertice)
    {
        if (anterior[vertice] == -1)
        {
            Console.Write($"V{vertice}");
            return;
        }
        MostrarCaminho(anterior, anterior[vertice]);
        Console.Write($" -> V{vertice}");
    }

    // =============================================================
    // ÁRVORE GERADORA MÍNIMA - PRIM
    // =============================================================
    public void Prim(int verticeInicial)
    {

        // =========================================================
        // VALIDAÇÃO DO VÉRTICE
        // =========================================================
        if (verticeInicial < 0 || verticeInicial >= numVertice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira somente valores entre 0 e 7!");
            Console.ResetColor();
            return;
        }

        // =========================================================
        // VERIFICA SE EXISTEM ARESTAS
        // =========================================================
        if (numArestas == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nO grafo não possui arestas.");
            Console.WriteLine("Não é possível construir uma Árvore Geradora Mínima.");
            Console.ResetColor();
            return;
        }
        int origem = verticeInicial;
        const int INFINITO = int.MaxValue;

        // =========================================================
        // ESTRUTURAS UTILIZADAS PELO PRIM
        // =========================================================
        int[] chave = new int[numVertice];
        int[] pai = new int[numVertice];
        bool[] incluido = new bool[numVertice];

        // =========================================================
        // INICIALIZAÇÃO
        // =========================================================
        for (int i = 0; i < numVertice; i++)
        {
            chave[i] = INFINITO;
            pai[i] = -1;
            incluido[i] = false;
        }
        chave[origem] = 0;

        // =========================================================
        // PROCESSAMENTO DO PRIM
        // =========================================================
        for (int contador = 0; contador < numVertice; contador++)
        {
            int atual = -1;
            int menorChave = INFINITO;
            for (int i = 0; i < numVertice; i++)
            {
                if (!incluido[i] && chave[i] < menorChave)
                {
                    menorChave = chave[i];
                    atual = i;
                }
            }
            if (atual == -1)
            {
                break;
            }
            incluido[atual] = true;
            for (int vizinho = 0; vizinho < numVertice; vizinho++)
            {
                int peso = matrizGrafo[atual, vizinho];
                if (peso > 0 && !incluido[vizinho] && peso < chave[vizinho])
                {
                    chave[vizinho] = peso;
                    pai[vizinho] = atual;
                }
            }
        }

        // =========================================================
        // VERIFICAÇÃO DE CONECTIVIDADE
        // =========================================================
        for (int i = 0; i < numVertice; i++)
        {
            if (!incluido[i])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão foi possível construir a Árvore Geradora Mínima.");
                Console.WriteLine("O grafo informado não é conexo.");
                Console.ResetColor();
                return;
            }
        }

        // =========================================================
        // EXIBIÇÃO DA ÁRVORE GERADORA MÍNIMA
        // =========================================================
        Console.WriteLine("\n==============================================");
        Console.WriteLine("       ÁRVORE GERADORA MÍNIMA - PRIM");
        Console.WriteLine("==============================================");
        Console.WriteLine($"\nPonto inicial: V{verticeInicial}");
        Console.WriteLine("\nTrilhas que compõem a rede mínima do parque:");
        Console.WriteLine("----------------------------------------------");
        long somaTotal = 0;
        int quantidadeArestas = 0;
        for (int i = 0; i < numVertice; i++)
        {
            if (pai[i] != -1)
            {
                int origemAresta = pai[i];
                int destinoAresta = i;
                int peso = matrizGrafo[origemAresta, destinoAresta];
                Console.WriteLine($"V{origemAresta} -> " + $"V{destinoAresta} | " + $"Distância: {peso}");
                somaTotal += peso;
                quantidadeArestas++;
            }
        }
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Total de trilhas: {quantidadeArestas}");
        Console.WriteLine($"Distância total das trilhas: {somaTotal}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nÁrvore Geradora Mínima encontrada com sucesso!");
        Console.ResetColor();
    }
}

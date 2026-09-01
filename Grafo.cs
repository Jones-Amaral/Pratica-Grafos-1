#pragma warning disable


using System.Reflection.PortableExecutable;

class Grafo
{
    public int[,] matrizGrafo;
    public int numVertice { get; set; }
    public int numArestas { get; set; }
    string[] cor;
    public int[] pred, d, t;

    /* Construtor do grafo, inicia a matriz e a zera | Colocamos no máximo 8 vértices*/
    public Grafo()
    {
        matrizGrafo = new int[8, 8];
        cor = new string[matrizGrafo.GetLength(0)];
        pred = new int[matrizGrafo.GetLength(0)];
        d = new int[this.matrizGrafo.GetLength(0)];
        t = new int[this.matrizGrafo.GetLength(0)];
        ZeraGrafo();
    }

    /* Procedimento que coloca 0 em todas posições, ou seja, nenhum vertice tem nenhuma conexão */
    public void ZeraGrafo()
    {
        for (int i = 0; i < this.matrizGrafo.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrizGrafo.GetLength(1); j++)
            {
                this.matrizGrafo[i, j] = 0;
            }
        }
    }

    /* Procedimento que insere uma aresta entre dois vétices, no grafo dos dois lados */
    public void InsereAresta(int v1, int v2, int peso)
    {
        if (this.matrizGrafo[v1, v2] == 0)
        {
            v1--;
            v2--;

            try
            {
                this.matrizGrafo[v1, v2] = peso;
                this.matrizGrafo[v2, v1] = peso;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Insira somente valores entre de 1 a 8!");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Os vértices já possuem uma aresta");
            Console.ResetColor();
        }
    }

    /* Procedimento que imprime o grafo */
    public void ImprimeGrafo()
    {
        System.Console.WriteLine("\n    V1--V2--V3--V4--V5--V6--V7--V8-");
        for (int i = 0; i < this.matrizGrafo.GetLength(0); i++)
        {
            System.Console.Write($"V{i + 1}: ");
            for (int j = 0; j < this.matrizGrafo.GetLength(1); j++)
            {
                System.Console.Write(this.matrizGrafo[i, j] + " | ");
            }
            System.Console.WriteLine("\n-----------------------------------");
        }
    }

    /* Função que retorna verdadeiro se a aresta existir. */
    public bool ExisteAresta(int v1, int v2)
    {
        v1--;
        v2--;

        if (this.matrizGrafo[v1, v2] > 0)
            return true;
        return false;
    }

    /* Função que preenche a matriz com números aleatórios, em índices aleatórios, de forma espelhada, ignorando os loops */
    public void PreencherMatriz(int arestas)
    {
        Random aleatorio = new Random();

        if (arestas < 1 || arestas > 28)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\nInsira um número válido de arestas (1 a 28)");
            Console.ResetColor();
            return;
        }

        while (arestas > 0)
        {
            int i = aleatorio.Next(0, 8);
            int j = aleatorio.Next(0, 8);

            if (i != j && this.matrizGrafo[i, j] == 0)
            {
                int peso = aleatorio.Next(1, 11);
                this.matrizGrafo[i, j] = peso;
                this.matrizGrafo[j, i] = peso;
                arestas--;
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("\nMatriz preenchida com sucesso!");
        Console.ResetColor();
    }

    public void BuscaProfundidade(int verticeInicial)
    {
        if (verticeInicial < 1 || verticeInicial > this.matrizGrafo.GetLength(0))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Insira somente valores entre 1 e 8");
            Console.ResetColor();
            return;
        }

        int origem = verticeInicial - 1;

        for (int i = 0; i < this.matrizGrafo.GetLength(0); i++)
        {
            cor[i] = "branco";
            pred[i] = -1;
            d[i] = 0;
            t[i] = 0;
        }

        int tempo = 0;
        Visita(origem, ref tempo);

        for (int i = 0; i < this.matrizGrafo.GetLength(0); i++)
        {
            if (cor[i] == "branco")
                Visita(i, ref tempo);
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBusca concluída!");
        Console.ResetColor();
    }

    public void Visita(int atual, ref int tempo)
    {
        cor[atual] = "azul";
        tempo++;
        d[atual] = tempo;

        for (int i = 0; i < this.matrizGrafo.GetLength(1); i++)
        {
            if (cor[i] == "branco" && matrizGrafo[atual, i] != 0)
            {
                pred[i] = atual;
                System.Console.WriteLine($"V{atual + 1} -> V{i + 1}");
                Visita(i, ref tempo);
                System.Console.WriteLine($"V{i + 1} -> V{atual + 1}");
            }
        }

        cor[atual] = "vermelho";
        tempo = tempo + 1;
        t[atual] = tempo;
    }
}
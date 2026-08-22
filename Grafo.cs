#pragma warning disable
class Grafo
{
    public int[,] matrizGrafo;
    public int numVertice { get; set; }
    public int numArestas { get; set; }

    /* Procedimento que coloca 0 em todas posições, ou seja, nenhum vertice tem nenhuma conexão */
    public void ZeraGrafo()
    {
        for (int i = 0; i < this.matrizGrafo.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrizGrafo.GetLength(1); j++)
            {
                matrizGrafo[i, j] = 0;
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
                System.Console.WriteLine($"Insira somente valores entre de 1 a 8!");
            }
        }
        else
            System.Console.WriteLine("Os vértices já possuem uma aresta");
    }

    /* Construtor do grafo, inicia a matriz e a zera*/
    public Grafo()
    {
        matrizGrafo = new int[8, 8];
        ZeraGrafo();
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

    /* Função que preenche a matriz com números aleatórios, de forma espelhada */
    public void PreencherMatriz()
    {
        Random aleatorio = new Random();
        int n;

        for (int i = 0; i < 8; i++)
        {
            for (int j = i; j < 8; j++)
            {
                n = aleatorio.Next(0, 11);
                this.matrizGrafo[i, j] = n;

                if (i != j)
                    this.matrizGrafo[j, i] = n;

                else if (i == j)
                    this.matrizGrafo[i, j] = 0;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Matriz preenchida com sucesso!");
        Console.ResetColor();
    }
}
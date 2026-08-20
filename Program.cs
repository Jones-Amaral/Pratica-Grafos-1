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
        v1--;
        v2--;
        try
        {
            this.matrizGrafo[v1, v2] = peso;
            this.matrizGrafo[v2, v1] = peso;
        }
        catch (IndexOutOfRangeException ex)
        {
            System.Console.WriteLine($"Valor < 0 ou > 8 para v1 ou v2, insira valores válidos!");
        }
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
    public void PreencherMatriz()
    {
        Random aleatorio = new Random();
        int n;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                n = aleatorio.Next(0, 11);
                this.matrizGrafo[i, j] = n;
                this.matrizGrafo[j, i] = n;
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Grafo g = new Grafo();
        int op = 1000, v1, v2, peso;
        Console.Clear();

        do
        {
            try
            {
                System.Console.WriteLine("\nSelecione uma opção:");
                System.Console.WriteLine("0) Encerrar o programa\n1) Imprime Grafo\n2) Insere Aresta\n3) Verificar aresta\n4) Preencher com valores aleatórios(0-10)");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 0:
                        System.Console.WriteLine("Encerrando o programa...");
                        break;
                    case 1:
                        g.ImprimeGrafo();
                        break;
                    case 2:
                        System.Console.WriteLine("Insira o vértice 1");
                        v1 = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Insira o vértice 2");
                        v2 = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Qual o peso da aresta?");
                        peso = int.Parse(Console.ReadLine());
                        g.InsereAresta(v1, v2, peso);
                        break;

                    case 3:
                        System.Console.WriteLine("Insira o vértice 1");
                        v1 = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Insira o vértice 2");
                        v2 = int.Parse(Console.ReadLine());
                        if (g.ExisteAresta(v1, v2))
                            System.Console.WriteLine($"A aresta existe entre os vértices {v1} e {v2}, com peso: {g.matrizGrafo[--v1, --v2]}");
                        else
                            System.Console.WriteLine("A aresta não existe!");
                        break;
                    case 4:
                        g.PreencherMatriz();
                        break;
                    default:
                        System.Console.WriteLine("Insira uma opção válida!");
                        break;
                }
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine($"Opção inválida, insira um número!");
            }
        } while (op != 0);


    }
}
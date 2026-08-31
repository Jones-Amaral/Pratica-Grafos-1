#pragma warning disable
class Program
{
    static void Main()
    {
        Grafo grafo = new Grafo();
        int opção = 1000, v1, v2, peso, arestas;
        Console.Clear();

        do
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("\n0) Encerrar o programa\n1) Imprimir Grafo\n2) Inserir Aresta\n3) Verificar aresta\n4) Zerar Grafo\n5) Preencher com valores aleatórios (0-10)\n6) Busca de Profundida\n");
                opção = int.Parse(Console.ReadLine());
                switch (opção)
                {
                    case 0:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Encerrando o programa...");
                        Console.ResetColor();

                        Thread.Sleep(2000);
                        return;

                    case 1:
                        Console.Clear();
                        grafo.ImprimeGrafo();
                        break;

                    case 2:
                        try
                        {
                            Console.Clear();

                            Console.Write("Insira o vértice 1: ");
                            v1 = int.Parse(Console.ReadLine());
                            Console.Write("Insira o vértice 2: ");
                            v2 = int.Parse(Console.ReadLine());
                            Console.Write("\nQual o peso da aresta? ");
                            peso = int.Parse(Console.ReadLine());

                            grafo.InsereAresta(v1, v2, peso);
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Insira somente números!");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.Clear();

                            Console.Write("Insira o vértice 1: ");
                            v1 = int.Parse(Console.ReadLine());
                            Console.Write("Insira o vértice 2: ");
                            v2 = int.Parse(Console.ReadLine());

                            if (grafo.ExisteAresta(v1, v2))
                                Console.WriteLine($"\nA aresta existe entre os vértices {v1} e {v2}, com peso: {grafo.matrizGrafo[--v1, --v2]}");
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A aresta não existe!");
                                Console.ResetColor();
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Insira somente números!");
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine("Insira somente números entre 1 e 8");
                        }
                        break;

                    case 4:
                        Console.Clear();

                        grafo.ZeraGrafo();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Grafo zerado!");
                        Console.ResetColor();
                        break;

                    case 5:
                        Console.Clear();
                        System.Console.WriteLine("Quantas arestas na matriz?");
                        arestas = int.Parse(Console.ReadLine());
                        grafo.PreencherMatriz(arestas);
                        break;
                    case 6:
                        Console.Clear();
                        grafo.BuscaProfundidade();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Busca concluída!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Insira uma opção válida!");
                        break;
                }

                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Opção inválida, insira um número!");
                Console.ResetColor();
            }

        } while (opção != 0);
    }
}
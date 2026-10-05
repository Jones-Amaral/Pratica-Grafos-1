#pragma warning disable
class Program
{
    static void Main()
    {
        Grafo grafo = new Grafo();

        int opção = 1000;
        int v1, v2, peso, arestas, verticeInicial;

        Console.Clear();

        do
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine(
                    "\n0) Encerrar o programa" +
                    "\n1) Imprimir Grafo" +
                    "\n2) Inserir Aresta" +
                    "\n3) Verificar aresta" +
                    "\n4) Zerar Grafo" +
                    "\n5) Preencher com valores aleatórios (0-10)" +
                    "\n6) Busca de Profundidade" +
                    "\n7) Algoritmo de Dijkstra\n"
                );

                Console.Write("Opção: ");

                opção = int.Parse(Console.ReadLine());

                switch (opção)
                {
                    // ENCERRAR
                    case 0:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Encerrando o programa...");
                        Console.ResetColor();

                        Thread.Sleep(2000);
                        return;

                    // IMPRIMIR GRAFO
                    case 1:
                        Console.Clear();

                        grafo.ImprimeGrafo();
                        break;

                    // INSERIR ARESTA
                    case 2:
                        Console.Clear();

                        try
                        {
                            Console.Write("Insira o vértice 1: ");
                            v1 = int.Parse(Console.ReadLine());

                            Console.Write("Insira o vértice 2: ");
                            v2 = int.Parse(Console.ReadLine());

                            Console.Write("\nQual o peso da aresta? ");
                            peso = int.Parse(Console.ReadLine());

                            grafo.InsereAresta(v1, v2, peso);
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }
                        break;

                    // VERIFICAR ARESTA
                    case 3:
                        Console.Clear();

                        try
                        {
                            Console.Write("Insira o vértice 1: ");
                            v1 = int.Parse(Console.ReadLine());

                            Console.Write("Insira o vértice 2: ");
                            v2 = int.Parse(Console.ReadLine());

                            if (v1 < 1 || v1 > 8 || v2 < 1 || v2 > 8)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInsira somente números entre 1 e 8!");
                                Console.ResetColor();

                                break;
                            }

                            if (grafo.ExisteAresta(v1, v2))
                            {
                                Console.WriteLine($"\nA aresta existe entre os vértices V{v1} e V{v2}, com peso: {grafo.matrizGrafo[v1 - 1, v2 - 1]}");
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nA aresta não existe!");
                                Console.ResetColor();
                            }
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }

                        break;

                    // ZERAR GRAFO
                    case 4:
                        Console.Clear();

                        grafo.ZeraGrafo();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGrafo zerado!");
                        Console.ResetColor();

                        break;

                    // PREENCHER MATRIZ
                    case 5:
                        Console.Clear();

                        try
                        {
                            Console.Write("Quantas arestas na matriz? ");
                            arestas = int.Parse(Console.ReadLine());

                            grafo.PreencherMatriz(arestas);
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }

                        break;

                    // BUSCA EM PROFUNDIDADE
                    case 6:
                        Console.Clear();

                        try
                        {
                            Console.Write("Qual o vértice inicial? ");
                            verticeInicial = int.Parse(Console.ReadLine());

                            grafo.BuscaProfundidade(verticeInicial);
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }

                        break;

                    // DIJKSTRA
                    case 7:
                        Console.Clear();

                        try
                        {
                            Console.Write("Qual o vértice inicial? ");
                            verticeInicial = int.Parse(Console.ReadLine());

                            grafo.Dijkstra(verticeInicial);
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }

                        break;

                    // OPÇÃO INVÁLIDA
                    default:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insira uma opção válida!");
                        Console.ResetColor();

                        break;
                }

                // Pausa o programa depois de executar qualquer opção.
                Console.WriteLine("\nPressione qualquer tecla para continuar...");

                Console.ReadKey();
            }


            // ERRO DE ENTRADA NO MENU
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida, insira um número!");
                Console.ResetColor();

                Console.ReadKey();
            }

        } while (opção != 0);
    }
}
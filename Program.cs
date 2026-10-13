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
                Console.WriteLine("PARQUE TURÍSTICO - PLANEJAMENTO DE TRILHAS");
                grafo.MostrarPontos();
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("\n0) Encerrar o programa" + "\n1) Exibir mapa de trilhas (matriz)" + "\n2) Cadastrar trilha" + "\n3) Consultar trilha" + "\n4) Limpar trilhas" + "\n5) Gerar trilhas aleatórias (distâncias de 1 a 10)" + "\n6) Explorar pontos do parque (DFS)" + "\n7) Menores distâncias (Dijkstra)" + "\n8) Rede mínima de trilhas (Prim)\n");
                Console.Write("Opção: ");
                opção = int.Parse(Console.ReadLine());
                switch (opção)
                {

                    // =================================================
                    // ENCERRAR
                    // =================================================
                    case 0:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Encerrando o programa...");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        return;

                    // =================================================
                    // IMPRIMIR GRAFO
                    // =================================================
                    case 1:
                        Console.Clear();
                        grafo.ImprimeGrafo();
                        break;

                    // =================================================
                    // INSERIR ARESTA
                    // =================================================
                    case 2:
                        Console.Clear();
                        try
                        {
                            Console.Write("Informe o ponto de origem (V0 a V7): ");
                            v1 = int.Parse(Console.ReadLine());
                            Console.Write("Informe o ponto de destino (V0 a V7): ");
                            v2 = int.Parse(Console.ReadLine());
                            Console.Write("\nQual a distância da trilha? ");
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

                    // =================================================
                    // VERIFICAR ARESTA
                    // =================================================
                    case 3:
                        Console.Clear();
                        try
                        {
                            Console.Write("Informe o ponto de origem (V0 a V7): ");
                            v1 = int.Parse(Console.ReadLine());
                            Console.Write("Informe o ponto de destino (V0 a V7): ");
                            v2 = int.Parse(Console.ReadLine());
                            if (v1 < 0 || v1 > 7 || v2 < 0 || v2 > 7)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInforme pontos entre 0 e 7!");
                                Console.ResetColor();
                                break;
                            }
                            if (grafo.ExisteAresta(v1, v2))
                            {
                                Console.WriteLine($"\nA trilha existe entre os pontos " + $"V{v1} e V{v2}, " + $"com distância: " + $"{grafo.matrizGrafo[v1, v2]}");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nA trilha não existe!");
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

                    // =================================================
                    // ZERAR GRAFO
                    // =================================================
                    case 4:
                        Console.Clear();
                        grafo.ZeraGrafo();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nTrilhas removidas!");
                        Console.ResetColor();
                        break;

                    // =================================================
                    // PREENCHER MATRIZ
                    // =================================================
                    case 5:
                        Console.Clear();
                        try
                        {
                            Console.Write("Quantas trilhas deseja gerar? ");
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

                    // =================================================
                    // BUSCA EM PROFUNDIDADE
                    // =================================================
                    case 6:
                        Console.Clear();
                        try
                        {
                            Console.Write("Qual o ponto inicial (0 a 7)? ");
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

                    // =================================================
                    // DIJKSTRA
                    // =================================================
                    case 7:
                        Console.Clear();
                        try
                        {
                            Console.Write("Qual o ponto inicial (0 a 7)? ");
                            verticeInicial = int.Parse(Console.ReadLine());
                            grafo.ImprimeGrafo();
                            grafo.Dijkstra(verticeInicial);
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }
                        break;

                    // =================================================
                    // ÁRVORE GERADORA MÍNIMA - PRIM
                    // =================================================
                    case 8:
                        Console.Clear();
                        try
                        {
                            Console.Write("Qual o ponto inicial para o Prim (0 a 7)? ");
                            verticeInicial = int.Parse(Console.ReadLine());
                            grafo.ImprimeGrafo();
                            grafo.Prim(verticeInicial);
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsira somente números!");
                            Console.ResetColor();
                        }
                        break;

                    // =================================================
                    // OPÇÃO INVÁLIDA
                    // =================================================
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insira uma opção válida!");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            // =========================================================
            // ERRO DE ENTRADA NO MENU
            // =========================================================
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

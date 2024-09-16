using Newtonsoft.Json;
using SistemaDeVendas;
using System;
using System.Collections.Generic;
using System.IO;

namespace GerenciamentoVendasComputadores
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>(); // Lista de clientes
        static Estoque estoque = new Estoque();
        static string caminhoArquivoClientes = "clientes.json";
        static string caminhoArquivoComputadores = "computadores.json";

        static void Main(string[] args)
        {
            // Carregar dados de arquivos JSON
            CarregarDados();

            int opcao = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   SISTEMA DE GERENCIAMENTO   ======");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Gerenciar Computadores (Estoque)");
                Console.WriteLine("2. Gerenciar Clientes");
                Console.WriteLine("3. Realizar Venda");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuEstoque();
                        break;
                    case 2:
                        MenuClientes();
                        break;
                    case 3:
                        RealizarVenda();
                        break;
                    case 0:
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);

            // Salvar dados em arquivos JSON
            SalvarDados();
        }

        static void MenuEstoque()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("========   GERENCIAMENTO DE COMPUTADORES   ===");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Computador");
                Console.WriteLine("2. Listar Computadores");
                Console.WriteLine("3. Remover Computador");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarComputador();
                        break;
                    case 2:
                        estoque.ListarComputadores();
                        break;
                    case 3:
                        RemoverComputador();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void MenuClientes()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   GERENCIAR CLIENTES   ============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Remover Cliente");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        RemoverCliente();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========   ADICIONAR NOVO CLIENTE   =========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();

            Cliente cliente = new Cliente(nome, cpf);
            clientes.Add(cliente);
            Console.WriteLine("\nCliente adicionado com sucesso!");
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   LISTA DE CLIENTES   ============");
            Console.WriteLine("==============================================");

            if (clientes.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente cadastrado.");
            }
            else
            {
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientes[i].Nome} - CPF: {clientes[i].Cpf}");
                }
            }
        }

        static Cliente SelecionarCliente()
        {
            ListarClientes();
            if (clientes.Count == 0)
            {
                return null;
            }

            Console.Write("\nSelecione o número do cliente: ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha > 0 && escolha <= clientes.Count)
            {
                return clientes[escolha - 1];
            }
            else
            {
                Console.WriteLine("\nCliente inválido.");
                return null;
            }
        }

        static void RemoverCliente()
        {
            ListarClientes();
            if (clientes.Count == 0)
            {
                return;
            }

            Console.Write("\nSelecione o número do cliente a ser removido: ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha > 0 && escolha <= clientes.Count)
            {
                Cliente cliente = clientes[escolha - 1];
                clientes.RemoveAt(escolha - 1);
                Console.WriteLine("\nCliente removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nCliente inválido.");
            }
        }

        static void AdicionarComputador()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========   ADICIONAR NOVO COMPUTADOR   =======");
            Console.WriteLine("==============================================");
            Console.Write("Digite o modelo do computador: ");
            string modelo = Console.ReadLine();
            Console.Write("Digite a marca do computador: ");
            string marca = Console.ReadLine();
            Console.Write("Digite o preço do computador: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Computador computador = new Computador(modelo, marca, preco, quantidade);
            estoque.AdicionarComputador(computador);
            Console.WriteLine("\nComputador adicionado com sucesso!");
        }

        static void RemoverComputador()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========   REMOVER COMPUTADOR   =============");
            Console.WriteLine("==============================================");
            Console.Write("Digite o modelo do computador a ser removido: ");
            string modelo = Console.ReadLine();
            Computador computador = estoque.BuscarComputadorPorModelo(modelo);
            if (computador != null)
            {
                estoque.RemoverComputador(computador);
                Console.WriteLine("\nComputador removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nComputador não encontrado.");
            }
        }

        static void RealizarVenda()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   REALIZAR VENDA   ================");
            Console.WriteLine("==============================================");
            Console.Write("Digite o modelo do computador a ser vendido: ");
            string modelo = Console.ReadLine();
            Computador computador = estoque.BuscarComputadorPorModelo(modelo);
            if (computador != null && computador.QuantidadeEmEstoque > 0)
            {
                Cliente cliente = SelecionarCliente();
                if (cliente != null)
                {
                    computador.QuantidadeEmEstoque--;
                    Venda venda = new Venda(cliente, computador, DateTime.Now, computador.Preco);
                    venda.ExibirDetalhesVenda();
                    Console.WriteLine("\nVenda realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nOperação cancelada: Cliente inválido.");
                }
            }
            else
            {
                Console.WriteLine("\nComputador não disponível em estoque.");
            }
        }

        static void CarregarDados()
        {
            string caminhoArquivoDados = "dados.json";

            if (File.Exists(caminhoArquivoDados))
            {
                string json = File.ReadAllText(caminhoArquivoDados);

                // Desserializa os dados como um objeto anônimo
                var dados = JsonConvert.DeserializeObject<dynamic>(json);

                // Converte e atribui os dados
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(dados.Clientes.ToString()) ?? new List<Cliente>();
                List<Computador> computadores = JsonConvert.DeserializeObject<List<Computador>>(dados.Computadores.ToString()) ?? new List<Computador>();

                // Adiciona os computadores ao estoque
                foreach (var computador in computadores)
                {
                    estoque.AdicionarComputador(computador);
                }
            }
        }

        static void SalvarDados()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented // Usa Newtonsoft.Json.Formatting
            };

            // Cria um objeto para armazenar todos os dados a serem salvos
            var dados = new
            {
                Clientes = clientes,

            };

            // Serializa os dados em JSON
            string jsonDados = JsonConvert.SerializeObject(dados, settings);

            // Define o caminho para o arquivo "dados.json"
            string caminhoArquivoDados = "dados.json";

            // Salva os dados no arquivo JSON
            File.WriteAllText(caminhoArquivoDados, jsonDados);
        }
    }
}
//C: \Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\dados.json
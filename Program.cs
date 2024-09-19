using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SistemaGerenciamento
{
    class Program
    {
        // Listas e IDs
        static List<Computador> computadores = new List<Computador>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Venda> vendas = new List<Venda>();
        static int proximoIdComputador = 1;
        static int proximoIdCliente = 1;
        static int proximoIdVenda = 1;

        // Caminhos dos arquivos
        static string caminhoComputadores = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\computadores.json";
        static string caminhoClientes = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\clientes.json";
        static string caminhoVendas = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\vendas.json";
        static string caminhoConfig = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\config.json";

        static void Main(string[] args)
        {
            // Carregar as configurações
            Config config = CarregarConfig(caminhoConfig);

            // Carregar os dados necessários
            CarregarDados(caminhoComputadores, caminhoClientes, caminhoVendas);

            int opcao;
            do
            {
                Console.Clear();

                // Define a cor do texto como ciano para o cabeçalho
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                   ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Define a cor do texto como branco para o menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║1. Gerenciar Estoque de Computadores                                                           ║");
                Console.WriteLine("║2. Gerenciar Cadastro de Clientes                                                              ║");
                Console.WriteLine("║3. Gerenciar Relatório de Vendas                                                               ║");
                Console.WriteLine("║0. Sair                                                                                        ║");

                // Exibe o autor, versão, data da última atualização e a data/hora atual
                Console.WriteLine($"║Autor: Renato Resende Monteiro                                                                 ║");
                Console.WriteLine($"║Data da Última Atualização: {config.DataUltimaAtualizacao,-30}                                     ║");
                Console.WriteLine($"║Versão do Sistema: {config.Versao,-42}                                  ║");
                Console.WriteLine($"║Data e Hora de Acesso: {DateTime.Now:dd/MM/yyyy HH:mm}                                                        ║");

                // Define a cor do texto como ciano para o rodapé
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Restaura a cor do texto para branco
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Escolha uma opção: ");

                // Lê a opção escolhida pelo usuário
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida, tente novamente.");
                    Thread.Sleep(1000); // Aguarda 1 segundo antes de retornar ao menu
                    continue;
                }

                // Executa a ação correspondente com base na opção
                switch (opcao)
                {
                    case 1:
                        MenuComputadores();  // Chama o método para gerenciar estoque de computadores
                        break;
                    case 2:
                        MenuClientes();  // Chama o método para gerenciar cadastro de clientes
                        break;
                    case 3:
                        MenuVendas();  // Chama o método para gerenciar relatório de vendas
                        break;
                    case 0:
                        SalvarDados(caminhoComputadores, caminhoClientes, caminhoVendas);  // Salva os dados antes de sair
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        Thread.Sleep(1000);  // Aguarda 1 segundo antes de retornar ao menu
                        break;
                }
            } while (opcao != 0);
        }

        static Config CarregarConfig(string caminho)
        {
            // Lê o arquivo JSON e desserializa em um objeto Config
            string json = File.ReadAllText(caminho);
            return JsonConvert.DeserializeObject<Config>(json);
        }

        // Método para carregar os dados
        static void CarregarDados(string caminhoComputadores, string caminhoClientes, string caminhoVendas)
        {
            // Implementação para carregar dados dos arquivos JSON
        }

        // Método para salvar dados
        static void SalvarDados(string caminhoComputadores, string caminhoClientes, string caminhoVendas)
        {
            // Implementação para salvar dados nos arquivos JSON
        }

        // Classe para armazenar as configurações
        class Config
        {
            public string Versao { get; set; }
            public string DataUltimaAtualizacao { get; set; }
        }

        // Menu de Computadores
        static void MenuComputadores()
        {
            int opcao;
            do
            {
                Console.Clear();

                // Define a cor do texto como ciano para o cabeçalho
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
                Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
                Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
                Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();

                // Cabeçalho para o menu de gerenciamento de estoque de computadores
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                        GERENCIAR ESTOQUE DE COMPUTADORES                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Exibe as opções do menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║1. Adicionar Computador                                                                       ║");
                Console.WriteLine("║2. Listar Computadores                                                                        ║");
                Console.WriteLine("║3. Atualizar Computador                                                                       ║");
                Console.WriteLine("║4. Excluir Computador                                                                         ║");
                Console.WriteLine("║0. Voltar                                                                                     ║");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Restaura a cor do texto para branco
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Escolha uma opção: ");

                // Lê a opção escolhida pelo usuário
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida, tente novamente.");
                    Thread.Sleep(1000); // Aguarda 1 segundo antes de retornar ao menu
                    continue;
                }

                // Executa a ação correspondente com base na opção
                switch (opcao)
                {
                    case 1:
                        AdicionarComputador();  // Chama o método para adicionar um novo computador
                        break;
                    case 2:
                        ListarComputadores();  // Chama o método para listar os computadores
                        break;
                    case 3:
                        AtualizarComputador();  // Chama o método para atualizar um computador
                        break;
                    case 4:
                        ExcluirComputador();  // Chama o método para excluir um computador
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

        // Menu de Clientes
        static void MenuClientes()
        {
            int opcao;
            do
            {
                Console.Clear();

                // Define a cor do texto como ciano para o cabeçalho
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Define a cor do texto como branco para o menu e exibe informações sobre o desenvolvedor, data e hora
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
                Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
                Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
                Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();

                // Cabeçalho para o menu de gerenciamento de clientes
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                        GERENCIAR CADASTRO DE CLIENTES                                          ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Exibe as opções do menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║1. Adicionar Cliente                                                                          ║");
                Console.WriteLine("║2. Listar Clientes                                                                           ║");
                Console.WriteLine("║3. Atualizar Cliente                                                                         ║");
                Console.WriteLine("║4. Excluir Cliente                                                                           ║");
                Console.WriteLine("║0. Voltar                                                                                     ║");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Restaura a cor do texto para branco
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Escolha uma opção: ");

                // Lê a opção escolhida pelo usuário
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida, tente novamente.");
                    Thread.Sleep(1000); // Aguarda 1 segundo antes de retornar ao menu
                    continue;
                }

                // Executa a ação correspondente com base na opção
                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();  // Chama o método para adicionar um novo cliente
                        break;
                    case 2:
                        ListarClientes();  // Chama o método para listar os clientes
                        break;
                    case 3:
                        AtualizarCliente();  // Chama o método para atualizar um cliente
                        break;
                    case 4:
                        ExcluirCliente();  // Chama o método para excluir um cliente
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

        // Menu de Vendas
        static void MenuVendas()
        {
            int opcao;
            do
            {
                Console.Clear();

                // Define a cor do texto como ciano para o cabeçalho
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Define a cor do texto como branco para o menu e exibe informações sobre o desenvolvedor, data e hora
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
                Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
                Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
                Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();

                // Cabeçalho para o menu de gerenciamento de vendas
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                          GERENCIAR RELATÓRIO DE VENDAS                                        ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Exibe as opções do menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║1. Adicionar Venda                                                                            ║");
                Console.WriteLine("║2. Listar Vendas                                                                              ║");
                Console.WriteLine("║3. Atualizar Venda                                                                            ║");
                Console.WriteLine("║4. Excluir Venda                                                                              ║");
                Console.WriteLine("║0. Voltar                                                                                     ║");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Restaura a cor do texto para branco
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Escolha uma opção: ");

                // Lê a opção escolhida pelo usuário
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida, tente novamente.");
                    Thread.Sleep(1000); // Aguarda 1 segundo antes de retornar ao menu
                    continue;
                }

                // Executa a ação correspondente com base na opção
                switch (opcao)
                {
                    case 1:
                        AdicionarVenda();  // Chama o método para adicionar uma nova venda
                        break;
                    case 2:
                        ListarVendas();  // Chama o método para listar as vendas
                        break;
                    case 3:
                        AtualizarVenda();  // Chama o método para atualizar uma venda
                        break;
                    case 4:
                        ExcluirVenda();  // Chama o método para excluir uma venda
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

        // Métodos de Computadores
        static void AdicionarComputador()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para adicionar novo computador
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        ADICIONAR NOVO COMPUTADOR                                              ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Solicita as informações do computador
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o modelo do computador: ");
            string modelo = Console.ReadLine();
            Console.Write("Digite a marca do computador: ");
            string marca = Console.ReadLine();
            Console.Write("Digite o preço do computador: ");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            // Adiciona o computador à lista
            var computador = new Computador
            {
                Id = proximoIdComputador++,
                Modelo = modelo,
                Marca = marca,
                Preco = preco,
                Quantidade = quantidade
            };

            computadores.Add(computador);

            // Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Computador adicionado com sucesso!                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ListarComputadores()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para a listagem de computadores
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                              LISTA DE COMPUTADORES                                             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Exibe os computadores cadastrados ou uma mensagem informando que não há nenhum computador
            Console.ForegroundColor = ConsoleColor.White;
            if (computadores.Count == 0)
            {
                Console.WriteLine("\nNenhum computador cadastrado.");
            }
            else
            {
                foreach (var computador in computadores)
                {
                    Console.WriteLine($"ID: {computador.Id} - Modelo: {computador.Modelo} - Marca: {computador.Marca} - Preço: {computador.Preco:C} - Quantidade: {computador.Quantidade}");
                }
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void AtualizarComputador()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para a atualização de dados
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           ATUALIZAR DADOS DO COMPUTADOR                                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a entrada de dados
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o ID do computador a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var computador = computadores.Find(c => c.Id == id);

            if (computador != null)
            {
                Console.Write("Digite o novo modelo (deixe em branco para manter o atual): ");
                string modelo = Console.ReadLine();
                if (!string.IsNullOrEmpty(modelo)) computador.Modelo = modelo;

                Console.Write("Digite a nova marca (deixe em branco para manter a atual): ");
                string marca = Console.ReadLine();
                if (!string.IsNullOrEmpty(marca)) computador.Marca = marca;

                Console.Write("Digite o novo preço (deixe em branco para manter o atual): ");
                string precoStr = Console.ReadLine();
                if (decimal.TryParse(precoStr, out decimal preco)) computador.Preco = preco;

                Console.Write("Digite a nova quantidade (deixe em branco para manter a atual): ");
                string quantidadeStr = Console.ReadLine();
                if (int.TryParse(quantidadeStr, out int quantidade)) computador.Quantidade = quantidade;

                Console.WriteLine("\nComputador atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nID de computador não encontrado.");
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ExcluirComputador()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para a exclusão de dados
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           EXCLUIR COMPUTADOR                                                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a entrada de dados
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o ID do computador a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            var computador = computadores.Find(c => c.Id == id);

            if (computador != null)
            {
                computadores.Remove(computador);
                Console.WriteLine("\nComputador excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("\nID de computador não encontrado.");
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        // Métodos de Clientes
        static void AdicionarCliente()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para adicionar novo cliente
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            ADICIONAR NOVO CLIENTE                                             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a entrada de dados
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o e-mail do cliente: ");
            string email = Console.ReadLine();
            Console.Write("Digite o telefone do cliente: ");
            string telefone = Console.ReadLine();

            var cliente = new Cliente
            {
                Id = proximoIdCliente++,
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            clientes.Add(cliente);
            Console.WriteLine("\nCliente adicionado com sucesso!");

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ListarClientes()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para listar clientes
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            LISTA DE CLIENTES                                                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a listagem
            Console.ForegroundColor = ConsoleColor.White;

            if (clientes.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente cadastrado.");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id} - Nome: {cliente.Nome} - E-mail: {cliente.Email} - Telefone: {cliente.Telefone}");
                }
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void AtualizarCliente()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para atualizar dados do cliente
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          ATUALIZAR DADOS DO CLIENTE                                             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a entrada de dados
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o ID do cliente a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                Console.Write("Digite o novo nome (deixe em branco para manter o atual): ");
                string nome = Console.ReadLine();
                if (!string.IsNullOrEmpty(nome)) cliente.Nome = nome;

                Console.Write("Digite o novo e-mail (deixe em branco para manter o atual): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) cliente.Email = email;

                Console.Write("Digite o novo telefone (deixe em branco para manter o atual): ");
                string telefone = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefone)) cliente.Telefone = telefone;

                Console.WriteLine("\nCliente atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nID de cliente não encontrado.");
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ExcluirCliente()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para excluir cliente
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               EXCLUIR CLIENTE                                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a entrada de dados
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o ID do cliente a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("\nCliente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("\nID de cliente não encontrado.");
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        // Métodos de Vendas
        static void AdicionarVenda()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para adicionar nova venda
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            ADICIONAR NOVA VENDA                                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a entrada de dados
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int clienteId))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }
            var cliente = clientes.Find(c => c.Id == clienteId);

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            Console.Write("Digite o ID do computador: ");
            if (!int.TryParse(Console.ReadLine(), out int computadorId))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }
            var computador = computadores.Find(c => c.Id == computadorId);

            if (computador == null)
            {
                Console.WriteLine("\nComputador não encontrado.");
                return;
            }

            Console.Write("Digite a quantidade vendida: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade))
            {
                Console.WriteLine("\nQuantidade inválida.");
                return;
            }

            if (quantidade > computador.Quantidade)
            {
                Console.WriteLine("\nQuantidade vendida não disponível em estoque.");
                return;
            }

            computador.Quantidade -= quantidade;

            var venda = new Venda
            {
                Id = proximoIdVenda++,
                ClienteId = cliente.Id,
                ComputadorId = computador.Id,
                Quantidade = quantidade,
                DataVenda = DateTime.Now
            };

            vendas.Add(venda);
            Console.WriteLine("\nVenda registrada com sucesso!");

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ListarVendas()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para listar as vendas
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                              LISTA DE VENDAS                                                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para a lista de vendas
            Console.ForegroundColor = ConsoleColor.White;
            if (vendas.Count == 0)
            {
                Console.WriteLine("\nNenhuma venda registrada.");
            }
            else
            {
                foreach (var venda in vendas)
                {
                    var cliente = clientes.Find(c => c.Id == venda.ClienteId);
                    var computador = computadores.Find(c => c.Id == venda.ComputadorId);

                    Console.WriteLine($"ID: {venda.Id} - Cliente: {cliente?.Nome ?? "Desconhecido"} - Computador: {computador?.Modelo ?? "Desconhecido"} - Quantidade: {venda.Quantidade} - Data: {venda.DataVenda}");
                }
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void AtualizarVenda()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para atualizar dados da venda
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        ATUALIZAR DADOS DA VENDA                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para o conteúdo
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Digite o ID da venda a ser atualizada: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            var venda = vendas.Find(v => v.Id == id);

            if (venda != null)
            {
                Console.Write("Digite o novo ID do cliente (deixe em branco para manter o atual): ");
                string clienteIdStr = Console.ReadLine();
                if (int.TryParse(clienteIdStr, out int clienteId))
                {
                    var cliente = clientes.Find(c => c.Id == clienteId);
                    if (cliente != null)
                    {
                        venda.ClienteId = cliente.Id;
                    }
                    else
                    {
                        Console.WriteLine("\nCliente não encontrado.");
                        return;
                    }
                }

                Console.Write("Digite o novo ID do computador (deixe em branco para manter o atual): ");
                string computadorIdStr = Console.ReadLine();
                if (int.TryParse(computadorIdStr, out int computadorId))
                {
                    var computador = computadores.Find(c => c.Id == computadorId);
                    if (computador != null)
                    {
                        var computadorAtual = computadores.Find(c => c.Id == venda.ComputadorId);
                        if (computadorAtual != null)
                        {
                            computadorAtual.Quantidade += venda.Quantidade; // Restaura o estoque do computador antigo
                        }

                        venda.ComputadorId = computador.Id;
                    }
                    else
                    {
                        Console.WriteLine("\nComputador não encontrado.");
                        return;
                    }
                }

                Console.Write("Digite a nova quantidade (deixe em branco para manter a atual): ");
                string quantidadeStr = Console.ReadLine();
                if (int.TryParse(quantidadeStr, out int quantidade))
                {
                    var computador = computadores.Find(c => c.Id == venda.ComputadorId);
                    if (computador != null && quantidade <= computador.Quantidade + venda.Quantidade)
                    {
                        computador.Quantidade += venda.Quantidade - quantidade; // Atualiza o estoque
                        venda.Quantidade = quantidade;
                    }
                    else
                    {
                        Console.WriteLine("\nQuantidade não disponível em estoque.");
                        return;
                    }
                }

                Console.WriteLine("\nVenda atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nID de venda não encontrado.");
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ExcluirVenda()
        {
            Console.Clear();

            // Define a cor do texto como ciano para o cabeçalho
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SISTEMA DE GERENCIAMENTO DE VENDAS DE COMPUTADORES E CLIENTES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco e exibe as informações sobre o desenvolvedor, data e hora
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ Desenvolvedor Responsável: Renato Resende Monteiro                                           ║");
            Console.WriteLine($"║ Data da Última Atualização: 18/09/2024                                                       ║");
            Console.WriteLine($"║ Versão do Sistema: 1.00                                                                      ║");
            Console.WriteLine($"║ Hora e Data de Acesso: {DateTime.Now:HH:mm} de {DateTime.Now:dd/MM/yyyy}                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Cabeçalho para excluir uma venda
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           EXCLUIR VENDA                                                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");

            // Define a cor do texto como branco para o conteúdo
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Digite o ID da venda a ser excluída: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            var venda = vendas.Find(v => v.Id == id);

            if (venda != null)
            {
                var computador = computadores.Find(c => c.Id == venda.ComputadorId);
                if (computador != null)
                {
                    computador.Quantidade += venda.Quantidade; // Restaura o estoque
                }

                vendas.Remove(venda);
                Console.WriteLine("\nVenda excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("\nID de venda não encontrado.");
            }

            // Restaura a cor do texto para branco
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }




    }

    public class Computador
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ComputadorId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVenda { get; set; }
    }
}

    

    
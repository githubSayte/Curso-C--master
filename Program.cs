﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaGerenciamento
{
    class Program
    {
        static List<Computador> computadores = new List<Computador>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Venda> vendas = new List<Venda>();
        static int proximoIdComputador = 1;
        static int proximoIdCliente = 1;
        static int proximoIdVenda = 1;

        static void Main(string[] args)
        {
            string caminhoComputadores = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\computadores.json";
            string caminhoClientes = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\clientes.json";
            string caminhoVendas = @"C:\Users\Aluno Noite\OneDrive\Área de Trabalho\Curso-C--master\vendas.json";


            CarregarDados(caminhoComputadores, caminhoClientes, caminhoVendas);

            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("========= SISTEMA DE GERENCIAMENTO ==========");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Gerenciar Computadores");
                Console.WriteLine("2. Gerenciar Clientes");
                Console.WriteLine("3. Gerenciar Vendas");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuComputadores();
                        break;
                    case 2:
                        MenuClientes();
                        break;
                    case 3:
                        MenuVendas();
                        break;
                    case 0:
                        SalvarDados(caminhoComputadores, caminhoClientes, caminhoVendas);
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        // Menu de Computadores
        static void MenuComputadores()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("========= GERENCIAR COMPUTADORES ==========");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Adicionar Computador");
                Console.WriteLine("2. Listar Computadores");
                Console.WriteLine("3. Atualizar Computador");
                Console.WriteLine("4. Excluir Computador");
                Console.WriteLine("0. Voltar");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarComputador();
                        break;
                    case 2:
                        ListarComputadores();
                        break;
                    case 3:
                        AtualizarComputador();
                        break;
                    case 4:
                        ExcluirComputador();
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
                Console.WriteLine("==============================================");
                Console.WriteLine("=========== GERENCIAR CLIENTES =============");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Atualizar Cliente");
                Console.WriteLine("4. Excluir Cliente");
                Console.WriteLine("0. Voltar");

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
                        AtualizarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
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
                Console.WriteLine("==============================================");
                Console.WriteLine("=========== GERENCIAR VENDAS ===============");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Adicionar Venda");
                Console.WriteLine("2. Listar Vendas");
                Console.WriteLine("3. Atualizar Venda");
                Console.WriteLine("4. Excluir Venda");
                Console.WriteLine("0. Voltar");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarVenda();
                        break;
                    case 2:
                        ListarVendas();
                        break;
                    case 3:
                        AtualizarVenda();
                        break;
                    case 4:
                        ExcluirVenda();
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
            Console.WriteLine("==============================================");
            Console.WriteLine("======== ADICIONAR NOVO COMPUTADOR ==========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o modelo do computador: ");
            string modelo = Console.ReadLine();
            Console.Write("Digite a marca do computador: ");
            string marca = Console.ReadLine();
            Console.Write("Digite o preço do computador: ");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            var computador = new Computador
            {
                Id = proximoIdComputador++,
                Modelo = modelo,
                Marca = marca,
                Preco = preco,
                Quantidade = quantidade
            };

            computadores.Add(computador);
            Console.WriteLine("\nComputador adicionado com sucesso!");
        }

        static void ListarComputadores()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("========== LISTA DE COMPUTADORES ============");
            Console.WriteLine("==============================================");

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
        }

        static void AtualizarComputador()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== ATUALIZAR DADOS DO COMPUTADOR =======");
            Console.WriteLine("==============================================");
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
        }

        static void ExcluirComputador()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== EXCLUIR COMPUTADOR ================");
            Console.WriteLine("==============================================");
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
        }

        // Métodos de Clientes
        static void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("========== ADICIONAR NOVO CLIENTE ==========");
            Console.WriteLine("==============================================");
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
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========== LISTA DE CLIENTES ==============");
            Console.WriteLine("==============================================");

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
        }

        static void AtualizarCliente()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== ATUALIZAR DADOS DO CLIENTE ========");
            Console.WriteLine("==============================================");
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
        }

        static void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== EXCLUIR CLIENTE ===================");
            Console.WriteLine("==============================================");
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
        }

        // Métodos de Vendas
        static void AdicionarVenda()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("========== ADICIONAR NOVA VENDA ============");
            Console.WriteLine("==============================================");
            Console.Write("Digite o ID do cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            var cliente = clientes.Find(c => c.Id == clienteId);

            if (cliente == null)
            {
                Console.WriteLine("\nCliente não encontrado.");
                return;
            }

            Console.Write("Digite o ID do computador: ");
            int computadorId = int.Parse(Console.ReadLine());
            var computador = computadores.Find(c => c.Id == computadorId);

            if (computador == null)
            {
                Console.WriteLine("\nComputador não encontrado.");
                return;
            }

            Console.Write("Digite a quantidade vendida: ");
            int quantidade = int.Parse(Console.ReadLine());

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
        }

        static void ListarVendas()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========== LISTA DE VENDAS ================");
            Console.WriteLine("==============================================");

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

                    Console.WriteLine($"ID: {venda.Id} - Cliente: {cliente?.Nome} - Computador: {computador?.Modelo} - Quantidade: {venda.Quantidade} - Data: {venda.DataVenda}");
                }
            }
        }

        static void AtualizarVenda()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== ATUALIZAR DADOS DA VENDA ===========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o ID da venda a ser atualizada: ");
            int id = int.Parse(Console.ReadLine());

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
                    if (computador != null && quantidade <= computador.Quantidade)
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
        }

        static void ExcluirVenda()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== EXCLUIR VENDA ======================");
            Console.WriteLine("==============================================");
            Console.Write("Digite o ID da venda a ser excluída: ");
            int id = int.Parse(Console.ReadLine());

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
        }

        // Métodos de Carregamento e Salvamento de Dados
        static void CarregarDados(string caminhoComputadores, string caminhoClientes, string caminhoVendas)
        {
            if (File.Exists(caminhoComputadores))
            {
                var json = File.ReadAllText(caminhoComputadores);
                computadores = JsonSerializer.Deserialize<List<Computador>>(json);
                proximoIdComputador = computadores.Count > 0 ? computadores[^1].Id + 1 : 1;
            }

            if (File.Exists(caminhoClientes))
            {
                var json = File.ReadAllText(caminhoClientes);
                clientes = JsonSerializer.Deserialize<List<Cliente>>(json);
                proximoIdCliente = clientes.Count > 0 ? clientes[^1].Id + 1 : 1;
            }

            if (File.Exists(caminhoVendas))
            {
                var json = File.ReadAllText(caminhoVendas);
                vendas = JsonSerializer.Deserialize<List<Venda>>(json);
                proximoIdVenda = vendas.Count > 0 ? vendas[^1].Id + 1 : 1;
            }
        }

        static void SalvarDados(string caminhoComputadores, string caminhoClientes, string caminhoVendas)
        {
            var jsonComputadores = JsonSerializer.Serialize(computadores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoComputadores, jsonComputadores);

            var jsonClientes = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoClientes, jsonClientes);

            var jsonVendas = JsonSerializer.Serialize(vendas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoVendas, jsonVendas);
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

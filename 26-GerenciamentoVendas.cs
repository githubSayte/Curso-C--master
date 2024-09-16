using System;
using System.Collections.Generic;

namespace SistemaDeVendas
{
    // Classe Computador
    public class Computador
    {
        // Atributos privados
        public string modelo;
        public string marca;
        public double preco;
        public int quantidadeEmEstoque;

        // Propriedades públicas com encapsulamento
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public int QuantidadeEmEstoque
        {
            get { return quantidadeEmEstoque; }
            set { quantidadeEmEstoque = value; }
        }

        // Construtor
        public Computador(string modelo, string marca, double preco, int quantidadeEmEstoque)
        {
            this.modelo = modelo;
            this.marca = marca;
            this.preco = preco;
            this.quantidadeEmEstoque = quantidadeEmEstoque;
        }

        // Método para exibir detalhes do computador
        public void ExibirDetalhes()
        {
            Console.WriteLine($"Modelo: {Modelo}, Marca: {Marca}, Preço: {Preco:C}, Estoque: {QuantidadeEmEstoque}");
        }
    }

    // Classe Estoque
    public class Estoque
    {
        // Lista privada de computadores
        private List<Computador> computadores = new List<Computador>();

        // Método para adicionar um computador
        public void AdicionarComputador(Computador computador)
        {
            computadores.Add(computador);
        }

        // Método para remover um computador
        public void RemoverComputador(Computador computador)
        {
            computadores.Remove(computador);
        }

        // Método para buscar um computador por modelo
        public Computador BuscarComputadorPorModelo(string modelo)
        {
            return computadores.Find(c => c.Modelo == modelo);
        }

        // Método para listar todos os computadores
        public void ListarComputadores()
        {
            foreach (var computador in computadores)
            {
                computador.ExibirDetalhes();
            }
        }
    }

    // Classe Cliente
    public class Cliente
    {
        // Atributos privados
        public string Nome;
        public string Cpf;
        private List<Computador> computadoresComprados = new List<Computador>();

        // Construtor
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
        }

        // Método para comprar um computador
        public void ComprarComputador(Computador computador, Estoque estoque)
        {
            Computador computadorSelecionado = estoque.BuscarComputadorPorModelo(computador.Modelo);
            if (computadorSelecionado != null && computadorSelecionado.QuantidadeEmEstoque > 0)
            {
                computadoresComprados.Add(computadorSelecionado);
                computadorSelecionado.QuantidadeEmEstoque--;
                Console.WriteLine($"{Nome} comprou o computador '{computador.Modelo}'.");
            }
            else
            {
                Console.WriteLine($"O computador '{computador.Modelo}' não está disponível em estoque.");
            }
        }

        // Método para exibir computadores comprados
        public void ExibirComputadoresComprados()
        {
            Console.WriteLine($"Computadores comprados por {Nome}:");
            foreach (var computador in computadoresComprados)
            {
                computador.ExibirDetalhes();
            }
        }
    }

    // Classe Venda
    public class Venda
    {
        // Atributos privados
        private Cliente cliente;
        private Computador computador;
        private DateTime dataVenda;
        private double valor;

        // Construtor
        public Venda(Cliente cliente, Computador computador, DateTime dataVenda, double valor)
        {
            this.cliente = cliente;
            this.computador = computador;
            this.dataVenda = dataVenda;
            this.valor = valor;
        }

        // Método para exibir detalhes da venda
        public void ExibirDetalhesVenda()
        {
            Console.WriteLine($"Venda realizada em {dataVenda.ToShortDateString()} para {cliente.Nome}");
            Console.WriteLine($"Computador: {computador.Modelo}, Valor: {valor:C}");
        }
    }
}

using ProjetoLocadora;
using System;

class Program {
    static void Main(string[] args) {
        var locadora = new Locadora();
        string arqFilmes = "filmes.txt";
        string arqClientes = "clientes.txt";

        locadora.CarregarFilmes(arqFilmes);
        locadora.CarregarClientes(arqClientes);

        while (true) {
            Console.Clear();
            Console.WriteLine("=== MENU LOCADORA ===");
            Console.WriteLine("1 - Cadastrar Filme");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Realizar Aluguel");
            Console.WriteLine("4 - Listar Filmes Disponíveis");
            Console.WriteLine("5 - Listar Tudo");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao) {
                case "1":
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Gênero: ");
                    string genero = Console.ReadLine();
                    Console.Write("Ano: ");
                    int ano = int.Parse(Console.ReadLine());
                    locadora.CadastrarFilme(new Filme(titulo, genero, ano));
                    locadora.SalvarFilmes(arqFilmes);
                    Console.WriteLine("Filme cadastrado!");
                    break;

                case "2":
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();
                    locadora.CadastrarCliente(new Cliente(nome, cpf));
                    locadora.SalvarClientes(arqClientes);
                    Console.WriteLine("Cliente cadastrado!");
                    break;

                case "3":
                    Console.Write("CPF do cliente: ");
                    string cpfCliente = Console.ReadLine();
                    Console.Write("Título do filme: ");
                    string tituloFilme = Console.ReadLine();
                    locadora.RealizarAluguel(cpfCliente, tituloFilme);
                    locadora.SalvarFilmes(arqFilmes);
                    break;

                case "4":
                    Console.WriteLine("Filmes disponíveis:");
                    locadora.ListarFilmesDisponiveis();
                    break;

                case "5":
                    Console.WriteLine("=== TODOS OS FILMES ===");
                    foreach (IEntidade filme in locadora.Filmes) {
                        filme.Exibir();
                    }

                    Console.WriteLine("\n=== TODOS OS CLIENTES ===");
                    foreach (IEntidade cliente in locadora.Clientes) {
                        cliente.Exibir();
                    }
                    break;


                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

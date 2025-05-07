using ProjetoLocadora;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Locadora {
    public List<Filme> Filmes = new();
    public List<Cliente> Clientes = new();

    public void CadastrarFilme(Filme filme) => Filmes.Add(filme);

    public void CadastrarCliente(Cliente cliente) => Clientes.Add(cliente);

    public void ListarFilmesDisponiveis() {
        foreach (var f in Filmes.Where(f => f.Disponibilidade))
            Console.WriteLine($"{f.Titulo} ({f.Ano}) - {f.Genero}");
    }

    public void RealizarAluguel(string cpfCliente, string tituloFilme) {
        var cliente = Clientes.FirstOrDefault(c => c.Cpf == cpfCliente);
        var filme = Filmes.FirstOrDefault(f => f.Titulo == tituloFilme && f.Disponibilidade);

        if (cliente != null && filme != null) {
            filme.Disponibilidade = false;
            Console.WriteLine("Aluguel realizado com sucesso!");
        }
        else {
            Console.WriteLine("Cliente ou filme não encontrado ou filme indisponível.");
        }
    }

    public void SalvarFilmes(string caminho) {
        File.WriteAllLines(caminho, Filmes.Select(f => f.ToString()));
    }

    public void CarregarFilmes(string caminho) {
        if (File.Exists(caminho))
            Filmes = File.ReadAllLines(caminho).Select(Filme.FromString).ToList();
    }

    public void SalvarClientes(string caminho) {
        File.WriteAllLines(caminho, Clientes.Select(c => c.ToString()));
    }

    public void CarregarClientes(string caminho) {
        if (File.Exists(caminho))
            Clientes = File.ReadAllLines(caminho).Select(Cliente.FromString).ToList();
    }
}

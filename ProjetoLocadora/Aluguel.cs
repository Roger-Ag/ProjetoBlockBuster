using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLocadora {
    internal class Aluguel {

        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Aluguel(Cliente cliente, Filme filme) {
            Cliente = cliente;
            Filme = filme;
            DataAluguel = DateTime.Now;
            DataDevolucao = null;
        }

        public void Devolver() {
            DataDevolucao = DateTime.Now;
            Filme.Disponibilidade = true;
        }
    }
}

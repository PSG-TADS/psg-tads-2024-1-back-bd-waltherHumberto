using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocadoraVeiculos.Models;


namespace LocadoraVeiculos.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; } // Chave prim�ria

        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CNH { get; set; } // N�mero da Carteira de Habilita��o
        public string? CPF { get; set; } // N�mero do CPF

        // Relacionamento de navega��o com a classe Reserva
        public ICollection<Reserva>? Reservas { get; set; }
    }
}

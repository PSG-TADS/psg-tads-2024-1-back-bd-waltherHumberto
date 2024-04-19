using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocadoraVeiculos.Models;


namespace LocadoraVeiculos.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; } // Chave primária

        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CNH { get; set; } // Número da Carteira de Habilitação
        public string? CPF { get; set; } // Número do CPF

        // Relacionamento de navegação com a classe Reserva
        public ICollection<Reserva>? Reservas { get; set; }
    }
}

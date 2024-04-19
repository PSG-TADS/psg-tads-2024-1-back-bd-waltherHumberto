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

        // Relacionamento de navega��o com a classe Reserva
        public ICollection<Reserva>? Reservas { get; set; }
    }
}

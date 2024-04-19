using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocadoraVeiculos.Models;


namespace LocadoraVeiculos.Models
{
    // Defini��o da classe Veiculo
    public class Veiculo
    {
        [Key]
        public int VeiculoID { get; set; } // Chave prim�ria

        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public string? Status { get; set; }
        public string? Placa { get; set; }
        public string? Cor { get; set; }

        // Relacionamento de navega��o com a classe Reserva
        public ICollection<Reserva>? Reservas { get; set; }

    }
}

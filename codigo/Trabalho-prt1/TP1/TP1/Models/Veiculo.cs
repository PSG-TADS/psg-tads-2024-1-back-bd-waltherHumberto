using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocadoraVeiculos.Models;


namespace LocadoraVeiculos.Models
{
    // Definição da classe Veiculo
    public class Veiculo
    {
        [Key]
        public int VeiculoID { get; set; } // Chave primária

        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public string? Status { get; set; }
        public string? Placa { get; set; }
        public string? Cor { get; set; }

        // Relacionamento de navegação com a classe Reserva
        public ICollection<Reserva>? Reservas { get; set; }

    }
}

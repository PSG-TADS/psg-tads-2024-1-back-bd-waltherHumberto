using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocadoraVeiculos.Models;


namespace LocadoraVeiculos.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; } // Chave primária

        public int VeiculoID { get; set; } // Chave estrangeira para Veiculo
        public int ClienteID { get; set; } // Chave estrangeira para Cliente
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        // Definição da chave estrangeira para o relacionamento com Veiculo
        [ForeignKey("VeiculoID")]
        public Veiculo? Veiculo { get; set; }

        // Definição da chave estrangeira para o relacionamento com Cliente
        [ForeignKey("ClienteID")]
        public Cliente? Cliente { get; set; }
    }
}

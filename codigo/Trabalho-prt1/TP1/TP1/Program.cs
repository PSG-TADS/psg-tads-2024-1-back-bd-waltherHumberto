using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos
{
    internal class VeiculoController
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

        // Defini��o da classe Cliente
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

        // Defini��o da classe Reserva
        public class Reserva
        {
            [Key]
            public int ReservaID { get; set; } // Chave prim�ria

            public int VeiculoID { get; set; } // Chave estrangeira para Veiculo
            public int ClienteID { get; set; } // Chave estrangeira para Cliente
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }

            // Defini��o da chave estrangeira para o relacionamento com Veiculo
            [ForeignKey("VeiculoID")]
            public Veiculo? Veiculo { get; set; }

            // Defini��o da chave estrangeira para o relacionamento com Cliente
            [ForeignKey("ClienteID")]
            public Cliente? Cliente { get; set; }
        }


        // Defini��o do contexto do banco de dados
        public class ApplicationContext : DbContext
        {

            public ApplicationContext(DbContextOptions<ApplicationContext> options) :
             base(options)
            { }
            // Define as tabelas do banco de dados
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Reserva> Reservas { get; set; }

            // Configura��es de conex�o com o banco de dados
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                _ = optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database= LocaVeiculos;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        // M�todo principal
        static void Main(string[] args)
        {
      

        }
    }
}

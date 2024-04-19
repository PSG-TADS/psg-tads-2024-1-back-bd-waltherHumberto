using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos
{
    internal class VeiculoController
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

        // Definição da classe Cliente
        public class Cliente
        {
            [Key]
            public int ClienteID { get; set; } // Chave primária

            public string? Nome { get; set; }
            public string? Endereco { get; set; }
            public string? Telefone { get; set; }

            // Relacionamento de navegação com a classe Reserva
            public ICollection<Reserva>? Reservas { get; set; }
        }

        // Definição da classe Reserva
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


        // Definição do contexto do banco de dados
        public class ApplicationContext : DbContext
        {

            public ApplicationContext(DbContextOptions<ApplicationContext> options) :
             base(options)
            { }
            // Define as tabelas do banco de dados
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Reserva> Reservas { get; set; }

            // Configurações de conexão com o banco de dados
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                _ = optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database= LocaVeiculos;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        // Método principal
        static void Main(string[] args)
        {
      

        }
    }
}

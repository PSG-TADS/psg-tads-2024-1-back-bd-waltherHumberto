using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos
{
    internal class Program
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
            // Define as tabelas do banco de dados
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Reserva> Reservas { get; set; }

            // Configurações de conexão com o banco de dados
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                _ = optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database= LocadoraVeiculos;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        // Método principal
        static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                // Adiciona um novo veículo ao banco de dados
                var veiculo = new Veiculo()
                {
                    Marca = "Toyota",
                    Modelo = "Corolla",
                    Ano = 2020,
                    Status = "Disponível",
                    Placa = "XYZ-1234",
                    Cor = "Preto"
                };
                context.Veiculos.Add(veiculo);
                context.SaveChanges();

                // Adiciona um novo cliente ao banco de dados
                var cliente = new Cliente()
                {
                    Nome = "Walther Humberto",
                    Endereco = "Rua, 123",
                    Telefone = "(31) 91234-5678"
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();

                // Cria uma nova reserva associando um veículo e um cliente e adiciona ao banco de dados
                var reserva = new Reserva()
                {
                    VeiculoID = veiculo.VeiculoID,
                    ClienteID = cliente.ClienteID,
                    DataInicio = DateTime.Now,
                    DataFim = DateTime.Now.AddDays(7)
                };
                context.Reservas.Add(reserva);
                context.SaveChanges();
            }
        }
    }
}

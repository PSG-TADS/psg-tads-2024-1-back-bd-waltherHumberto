using Microsoft.EntityFrameworkCore;
using LocadoraVeiculos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos
{
    public class Program
    {
        // Método principal
        static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationContext>();

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();


        }
    }
}

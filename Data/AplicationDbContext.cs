using Microsoft.EntityFrameworkCore;
using proyectoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoCRUD.Data
{
    public class AplicationDbContext : DbContext
    {
        //Constructor
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }

        //Instanciar el modelo
        public DbSet<Libro> Libro { get; set; }
    }
}

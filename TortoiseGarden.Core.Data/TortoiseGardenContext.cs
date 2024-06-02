using Microsoft.EntityFrameworkCore;
using TortoiseGarden.Core.Entities;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TortoiseGarden.Core.Data
{
    public class TortoiseGardenContext : DbContext
    {
        private readonly string CONNECTIONSTRING = "Persist Security Info=True;Initial Catalog=TortoiseGarden;Data Source=DESKTOP-LE1AC62\\SQLEXPRESS; Application Name=DemoApp; Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTIONSTRING);
        }
    }
}

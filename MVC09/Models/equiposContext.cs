using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using practicaMVC05.Models;

namespace MVC09.Models
{
    public class equiposContext : DbContext
    {
        public equiposContext(DbContextOptions<equiposContext> options) : base(options)
        {
        }
        public DbSet<equipos> equipos { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
    }
}

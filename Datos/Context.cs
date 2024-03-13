using ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Datos
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options ) : base(options) 
        {
        }

        public DbSet<Alumno> Alumno { get; set;}


    }
}

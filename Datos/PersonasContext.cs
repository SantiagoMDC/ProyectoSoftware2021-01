using Microsoft.EntityFrameworkCore;
using Entity;

namespace Datos
{
    public class PersonasContext: DbContext
    {
        public PersonasContext(DbContextOptions options):base(options)
        {
            
        }
        
        public DbSet<Persona>personas{get;set;}
        public DbSet<Restaurante>restaurantes{get;set;}

        public DbSet<Vinculacion>vinculaciones{get;set;}
        public DbSet<ListaChequeo>listaChequeos{get;set;}

        public DbSet<User> Users { get; set; }

        public DbSet<Ambiental>ambientales{get;set;}
        public DbSet<Veterinaria>veterinarias{get;set;}

    }
}
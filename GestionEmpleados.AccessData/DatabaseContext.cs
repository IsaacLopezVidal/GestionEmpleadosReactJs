using GestionEmpleados.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GestionEmpleados.AccessData
{
    public class DatabaseContext : DbContext
    {
        public static DbContextOptions<DatabaseContext> Options;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Options = options;
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<SolicitudVacaciones> SolicitudVacaciones { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Familiar> Familiar { get; set; }
        public DbSet<Catalogos> Catalogos { get; set; }
        public DbSet<CatalogosDescripciones> CatalogosDescripciones { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRol>().HasKey(o => new { o.UsuarioID, o.RolID });
            modelBuilder.Entity<CatalogosDescripciones>().HasIndex(o => new { o.CatalogoId, o.CatalogoDescripcionId }).IsUnique(true);

            modelBuilder.Entity<Catalogos>().HasData(
                new Catalogos { CatalogoId = 1, Catalogo = "Cargo" },
                new Catalogos { CatalogoId = 2, Catalogo = "Departamento" },
                new Catalogos { CatalogoId = 3, Catalogo = "Rol" },
                new Catalogos { CatalogoId = 4, Catalogo = "EstatusVacaciones" },
                new Catalogos { CatalogoId = 5, Catalogo = "Tipo de Relacion" }
            );
            modelBuilder.Entity<CatalogosDescripciones>().HasData(
                new CatalogosDescripciones { CatalogoId = 1, CatalogoDescripcionId = 1000, ValorAlfanumerico=String.Empty, Descripcion = "Director" },
                new CatalogosDescripciones { CatalogoId = 1, CatalogoDescripcionId = 1001, ValorAlfanumerico=String.Empty, Descripcion = "Subdirector" },
                new CatalogosDescripciones { CatalogoId = 1, CatalogoDescripcionId = 1002, ValorAlfanumerico=String.Empty, Descripcion = "Gerente" },
                new CatalogosDescripciones { CatalogoId = 1, CatalogoDescripcionId = 1003, ValorAlfanumerico=String.Empty, Descripcion = "Vendedor" },
                new CatalogosDescripciones { CatalogoId = 2, CatalogoDescripcionId = 2000, ValorAlfanumerico=String.Empty, Descripcion = "Ventas" },
                new CatalogosDescripciones { CatalogoId = 3, CatalogoDescripcionId = 3000, ValorAlfanumerico=String.Empty, Descripcion = "Director" },
                new CatalogosDescripciones { CatalogoId = 3, CatalogoDescripcionId = 3001, ValorAlfanumerico=String.Empty, Descripcion = "Empleado" },
                new CatalogosDescripciones { CatalogoId = 4, CatalogoDescripcionId = 4000, ValorAlfanumerico=String.Empty, Descripcion = "Pendiente" },
                new CatalogosDescripciones { CatalogoId = 4, CatalogoDescripcionId = 4001, ValorAlfanumerico=String.Empty, Descripcion = "Aprobada" },
                new CatalogosDescripciones { CatalogoId = 4, CatalogoDescripcionId = 4002, ValorAlfanumerico=String.Empty, Descripcion = "Rechazada" },
                new CatalogosDescripciones { CatalogoId = 5, CatalogoDescripcionId = 5000, ValorAlfanumerico=String.Empty, Descripcion = "Padre" },
                new CatalogosDescripciones { CatalogoId = 5, CatalogoDescripcionId = 5001, ValorAlfanumerico=String.Empty, Descripcion = "Madre" },
                new CatalogosDescripciones { CatalogoId = 5, CatalogoDescripcionId = 5002, ValorAlfanumerico=String.Empty, Descripcion = "Esposo/a" },
                new CatalogosDescripciones { CatalogoId = 5, CatalogoDescripcionId = 5003, ValorAlfanumerico=String.Empty, Descripcion = "Hijo/a" },
                new CatalogosDescripciones { CatalogoId = 5, CatalogoDescripcionId = 5004, ValorAlfanumerico=String.Empty, Descripcion = "Conyuge" }
            );
            foreach (var relationship in modelBuilder.Model
                                      .GetEntityTypes()
                                      .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

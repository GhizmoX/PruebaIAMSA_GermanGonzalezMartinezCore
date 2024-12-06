using Microsoft.EntityFrameworkCore;

namespace ApiPruebas.Data
{
    public class ApiPruebasContext : DbContext
    {
        public ApiPruebasContext(DbContextOptions<ApiPruebasContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPruebas.Models.Usuarios> Usuarios { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPruebas.Models;

namespace ApiPruebas.Data
{
    public class ApiPruebasContext : DbContext
    {
        public ApiPruebasContext (DbContextOptions<ApiPruebasContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPruebas.Models.Usuarios> Usuarios { get; set; } = default!;
    }
}

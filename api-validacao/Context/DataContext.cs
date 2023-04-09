using api_validacao.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api_validacao.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
    }
}

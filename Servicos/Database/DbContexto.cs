using System;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Servicos.Database
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<ClienteModel> Clientes {get; set;}


    }
}
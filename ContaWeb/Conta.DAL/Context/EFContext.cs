using Microsoft.EntityFrameworkCore;
using Conta.DAL.Entidades;

namespace Conta.DAL.Context
{
    public class EFContext : DbContext
    {

        public EFContext(DbContextOptions<EFContext> options)
            : base(options) { }
        public DbSet<ContaDAO> Contas { get; set; }
        public DbSet<OperacaoDAO> Operacoes { get; set; }

    }
}

using ControleDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.ModuloSessao
{
    public class RepositorioSessaoEmOrm : RepositorioBaseEmOrm<Sessao>, IRepositorioSessao
    {
        public RepositorioSessaoEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Sessao> ObterRegistros()
        {
            return dbContext.Sessoes;
        }
    }
}

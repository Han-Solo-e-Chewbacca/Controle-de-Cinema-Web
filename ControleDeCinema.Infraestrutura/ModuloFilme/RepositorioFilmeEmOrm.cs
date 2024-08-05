using ControleDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Controle_de_Cinema_Web.Dominio.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloFilme
{
    public class RepositorioFilmeEmOrm : RepositorioBaseEmOrm<Filme>, IRepositorioFilme
    {
        public RepositorioFilmeEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Filme> ObterRegistros()
        {
            return dbContext.Filmes;
        }
    }
}
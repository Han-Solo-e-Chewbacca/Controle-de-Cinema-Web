using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.ModuloSala
{
    public class RepositorioSalaEmOrm : RepositorioBaseEmOrm<Sala>, IRepositorioSala
    {
        public RepositorioSalaEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Sala> ObterRegistros()
        {
            return dbContext.Salas;
        }
        
    }
}

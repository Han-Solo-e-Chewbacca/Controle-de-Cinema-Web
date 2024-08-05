using ControleDeCinema.Dominio.ModuloIngresso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.EntityFrameworkCore;
using ControleDeCinema.Dominio.ModuloFilme;

namespace ControleDeCinema.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioEmOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Funcionario> ObterRegistros()
        {
            return dbContext.Funcionarios;
        }
    }
}

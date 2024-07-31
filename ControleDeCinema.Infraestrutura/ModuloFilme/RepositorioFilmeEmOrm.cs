using ControleDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloFilme
{
    public class RepositorioFilmeEmOrm : IRepositorioFilme
    {
        ControleDeCinemaDbContext dbContext;

        public RepositorioFilmeEmOrm(ControleDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Filme registro)
        {
            dbContext.Filmes.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Filme registroOriginal, Filme registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            dbContext.Filmes.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Filme registro)
        {
            if (registro == null)
                return false;

            dbContext.Filmes.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Filme SelecionarPorId(int id)
        {
            return dbContext.Filmes.Find(id)!;
        }

        public List<Filme> SelecionarTodos()
        {
            return dbContext.Filmes.ToList();
        }
    }
}

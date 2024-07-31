using ControleDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloSessao
{
    public class RepositorioSessaoEmOrm : IRepositorioSessao
    {
        ControleDeCinemaDbContext dbContext;

        public RepositorioSessaoEmOrm(ControleDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Sessao registro)
        {
            dbContext.Sessoes.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Sessao registroOriginal, Sessao registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            dbContext.Sessoes.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Sessao registro)
        {
            if (registro == null)
                return false;

            dbContext.Sessoes.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Sessao SelecionarPorId(int id)
        {
            return dbContext.Sessoes.Find(id)!;
        }

        public List<Sessao> SelecionarTodos()
        {
            return dbContext.Sessoes.ToList();
        }
    }
}

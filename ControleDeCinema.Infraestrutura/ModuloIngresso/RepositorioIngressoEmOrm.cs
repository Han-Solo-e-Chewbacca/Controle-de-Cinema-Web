using ControleDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloIngresso
{
    public class RepositorioIngressoEmOrm : IRepositorioIngresso
    {
        ControleDeCinemaDbContext dbContext;

        public RepositorioIngressoEmOrm(ControleDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Ingresso registro)
        {
            dbContext.Ingressos.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Ingresso registroOriginal, Ingresso registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            dbContext.Ingressos.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Ingresso registro)
        {
            if (registro == null)
                return false;

            dbContext.Ingressos.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Ingresso SelecionarPorId(int id)
        {
            return dbContext.Ingressos.Find(id)!;
        }

        public List<Ingresso> SelecionarTodos()
        {
            return dbContext.Ingressos.ToList();
        }
    }
}

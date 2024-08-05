using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.Infra.Orm.ModuloSala;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Cinema_Web.Controllers
{
    public class SalaController : Controller
    {
        public ViewResult Listar()
        {
            var dbContext = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(dbContext);

            var salas = repositorioSala.SelecionarTodos();

            var listarSalasVm = salas
                .Select(g => new ListarSalaViewModel { Id = g.Id, Numero = g.Numero, Capacidade = g.Capacidade});

            return View(listarSalasVm);
        }

        public ViewResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Inserir(InserirSalaViewModel inserirSalaVm)
        {
            if (!ModelState.IsValid)
                return View(inserirSalaVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var sala = new Sala(inserirSalaVm.Numero, inserirSalaVm.Capacidade);

            repositorioSala.Inserir(sala);

            HttpContext.Response.StatusCode = 201;

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{sala.Id}] foi cadastrado com sucesso!",
                LinkRedirecionamento = "/sala/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Editar(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salaOriginal = repositorioSala.SelecionarPorId(id);

            var editarSalaVm = new EditarSalaViewModel
            {
                Id = id,
                Numero = salaOriginal.Numero,
                Capacidade = salaOriginal.Capacidade
            };

            return View(editarSalaVm);
        }

        [HttpPost]
        public ViewResult Editar(EditarSalaViewModel editarSalaVm)
        {
            if (!ModelState.IsValid)
                return View(editarSalaVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salaOriginal = repositorioSala.SelecionarPorId(editarSalaVm.Id);

            salaOriginal.Numero = editarSalaVm.Numero;
            salaOriginal.Capacidade = editarSalaVm.Capacidade;

            repositorioSala.Editar(salaOriginal);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{salaOriginal.Id}] foi editado com sucesso!",
                LinkRedirecionamento = "/sala/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Excluir(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salaParaExcluir = repositorioSala.SelecionarPorId(id);

            var excluirSalaVm = new ExcluirSalaViewModel
            {
                Id = id,
                Numero = salaParaExcluir.Numero,
                Capacidade = salaParaExcluir.Capacidade,
            };

            return View(excluirSalaVm);
        }

        [HttpPost, ActionName("excluir")]
        public ViewResult ExcluirConfirmado(ExcluirSalaViewModel excluirSalaVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salaParaExcluir = repositorioSala.SelecionarPorId(excluirSalaVm.Id);

            repositorioSala.Excluir(salaParaExcluir);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{salaParaExcluir.Id}] foi excluído com sucesso!",
                LinkRedirecionamento = "/filme/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Detalhes(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salaOriginal = repositorioSala.SelecionarPorId(id);

            var detalhesSalaVm = new DetalhesSalaViewModel()
            {
                Id = id,
                Numero = salaOriginal.Numero,
                Capacidade = salaOriginal.Capacidade,
            };

            return View(detalhesSalaVm);
        }
    }
}

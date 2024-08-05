using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.Infra.Orm.ModuloSessao;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Cinema_Web.Controllers
{
    public class SessaoController : Controller
    {
        public ViewResult Listar()
        {
            var dbContext = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(dbContext);

            var sessoes = repositorioSessao.SelecionarTodos();

            var listarSessoesVm = sessoes
                .Select(g => new ListarSessaoViewModel { Id = g.Id, Sala = g.Sala, Horario = g.Horario, Filme = g.Filme, QtdIngressos = g.QtdIngressos });

            return View(listarSessoesVm);
        }

        public ViewResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Inserir(InserirSessaoViewModel inserirSessaoVm)
        {
            if (!ModelState.IsValid)
                return View(inserirSessaoVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);
            

            var sessao = new Sessao(inserirSessaoVm.Sala, inserirSessaoVm.Horario, inserirSessaoVm.Filme,inserirSessaoVm.QtdIngressos);

            repositorioSessao.Inserir(sessao);

            HttpContext.Response.StatusCode = 201;

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{sessao.Id}] foi cadastrado com sucesso!",
                LinkRedirecionamento = "/sessao/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Editar(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessaoOriginal = repositorioSessao.SelecionarPorId(id);

            var editarSessaoVm = new EditarSessaoViewModel
            {
                Id = id,
                Sala = sessaoOriginal.Sala,
                Horario = sessaoOriginal.Horario,
                Filme = sessaoOriginal.Filme,
                QtdIngressos = sessaoOriginal.QtdIngressos,
            };

            return View(editarSessaoVm);
        }

        [HttpPost]
        public ViewResult Editar(EditarSessaoViewModel editarSessaoVm)
        {
            if (!ModelState.IsValid)
                return View(editarSessaoVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessaoOriginal = repositorioSessao.SelecionarPorId(editarSessaoVm.Id);

            sessaoOriginal.Sala = editarSessaoVm.Sala;
            sessaoOriginal.Horario = editarSessaoVm.Horario;
            sessaoOriginal.Filme = editarSessaoVm.Filme;
            sessaoOriginal.QtdIngressos = editarSessaoVm.QtdIngressos;

            repositorioSessao.Editar(sessaoOriginal);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{sessaoOriginal.Id}] foi editado com sucesso!",
                LinkRedirecionamento = "/filme/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Excluir(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessaoParaExcluir = repositorioSessao.SelecionarPorId(id);

            var excluirSessaoVm = new ExcluirSessaoViewModel()
            {
                Id = id,
                Sala = sessaoParaExcluir.Sala,
                Horario = sessaoParaExcluir.Horario,
                Filme = sessaoParaExcluir.Filme,
                QtdIngressos = sessaoParaExcluir.QtdIngressos,
            };

            return View(excluirSessaoVm);
        }

        [HttpPost, ActionName("excluir")]
        public ViewResult ExcluirConfirmado(ExcluirSessaoViewModel excluirSessaoVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessaoParaExcluir = repositorioSessao.SelecionarPorId(excluirSessaoVm.Id);

            repositorioSessao.Excluir(sessaoParaExcluir);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{sessaoParaExcluir.Id}] foi excluído com sucesso!",
                LinkRedirecionamento = "/sessao/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Detalhes(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessaoDetalhes = repositorioSessao.SelecionarPorId(id);

            var detalhesSessaoVm = new DetalhesSessaoViewModel
            {
                Id = id,
                Sala = sessaoDetalhes.Sala,
                Horario = sessaoDetalhes.Horario,
                Filme = sessaoDetalhes.Filme,
                QtdIngressos = sessaoDetalhes.QtdIngressos,
            };

            return View(detalhesSessaoVm);
        }
    }
}

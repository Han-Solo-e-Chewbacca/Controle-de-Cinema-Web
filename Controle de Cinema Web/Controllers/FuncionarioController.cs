using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.Infra.Orm.ModuloFuncionario;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Cinema_Web.Controllers
{
    public class FuncionarioController : Controller
    {
        public ViewResult Listar()
        {
            var dbContext = new ControleDeCinemaDbContext();
            var repositorioFilme = new RepositorioFuncionarioEmOrm(dbContext);

            var funcionarios = repositorioFilme.SelecionarTodos();

            var listarFuncionariosVm = funcionarios
                .Select(g => new ListarFuncionarioViewModel { Id = g.Id,  Nome = g.Nome, Login = g.Login, Senha = g.Senha });

            return View(listarFuncionariosVm);
        }

        public ViewResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Inserir(InserirFuncionarioViewModel inserirFuncionarioVm)
        {
            if (!ModelState.IsValid)
                return View(inserirFuncionarioVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

            var funcionario = new Funcionario(inserirFuncionarioVm.Nome, inserirFuncionarioVm.Login, inserirFuncionarioVm.Senha);

            repositorioFuncionario.Inserir(funcionario);

            HttpContext.Response.StatusCode = 201;

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{funcionario.Id}] foi cadastrado com sucesso!",
                LinkRedirecionamento = "/funcionario/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Editar(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

            var funcionarioOriginal = repositorioFuncionario.SelecionarPorId(id);

            var editarFuncionarioVm = new EditarFuncionarioViewModel
            {
                Id = id,
                Nome = funcionarioOriginal.Nome,
                Login = funcionarioOriginal.Login,
                Senha = funcionarioOriginal.Senha,
            };

            return View(editarFuncionarioVm);
        }

        [HttpPost]
        public ViewResult Editar(EditarFuncionarioViewModel editarFuncionarioVm)
        {
            if (!ModelState.IsValid)
                return View(editarFuncionarioVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

            var funcionarioOriginal = repositorioFuncionario.SelecionarPorId(editarFuncionarioVm.Id);

            funcionarioOriginal.Nome = editarFuncionarioVm.Nome;
            funcionarioOriginal.Login = editarFuncionarioVm.Login;
            funcionarioOriginal.Senha = editarFuncionarioVm.Senha;

            repositorioFuncionario.Editar(funcionarioOriginal);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{funcionarioOriginal.Id}] foi excluído com sucesso!",
                LinkRedirecionamento = "/funcionario/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Excluir(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

            var funcionarioParaExcluir = repositorioFuncionario.SelecionarPorId(id);

            var excluirFuncionarioVm = new ExcluirFuncionarioViewModel()
            {
                Id = id,
                Nome = funcionarioParaExcluir.Nome,
                Login = funcionarioParaExcluir.Login,
                Senha = funcionarioParaExcluir.Senha
            };

            return View(excluirFuncionarioVm);
        }

        [HttpPost, ActionName("excluir")]
        public ViewResult ExcluirConfirmado(ExcluirFuncionarioViewModel excluirFilmeVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

            var funcionarioParaExcluir = repositorioFuncionario.SelecionarPorId(excluirFilmeVm.Id);

            repositorioFuncionario.Excluir(funcionarioParaExcluir);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{funcionarioParaExcluir.Id}] foi excluído com sucesso!",
                LinkRedirecionamento = "/funcionario/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        public ViewResult Detalhes(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

            var funcionarioOriginal = repositorioFuncionario.SelecionarPorId(id);

            var detalhesFuncionarioVm = new DetalhesFuncionarioViewModel()
            {
                Id = id,
                Nome = funcionarioOriginal.Nome,
                Login = funcionarioOriginal.Login,
                Senha = funcionarioOriginal.Senha
            };

            return View(detalhesFuncionarioVm);
        }
    }
}

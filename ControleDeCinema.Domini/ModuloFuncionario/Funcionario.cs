using Controle_de_Cinema_Web.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSessao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeCinema.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }


        public Funcionario()
        {
        }
        public Funcionario(string nome, string login, string senha)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public override void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
        {
            Funcionario ingressoAtualizado = (Funcionario)entidadeAtualizada;

            Nome = ingressoAtualizado.Nome;
            Login = ingressoAtualizado.Login;
            Senha = ingressoAtualizado.Senha;

        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"Nome\" é obrigatório!");
            if (string.IsNullOrEmpty(Login.Trim()))
                erros.Add("O campo \"Login\" é obrigatório!");
            if (string.IsNullOrEmpty(Senha.Trim()))
                erros.Add("O campo \"Senha\" é obrigatório!");

            return erros;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controle_de_Cinema_Web.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeCinema.Dominio.ModuloIngresso
{
    public class Ingresso : EntidadeBase
    {
        public string Tipo { get; set; }

        public string Assento { get; set; }

        public decimal Valor { get; set; }

        public Sessao Sessao { get; set; }
        public Funcionario Funcionario { get; set; }

        public Ingresso()
        {
        }
        public Ingresso(string tipo, string assento, decimal valor,Sessao sessao,Funcionario funcionario)
        {
            Tipo = tipo;
            Assento = assento;
            Valor = valor;
            Sessao = sessao;
            Funcionario = funcionario;
        }

        public override void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
        {
            Ingresso ingressoAtualizado = (Ingresso)entidadeAtualizada;

            Tipo = ingressoAtualizado.Tipo;
            Assento = ingressoAtualizado.Assento;
            Valor = ingressoAtualizado.Valor;
            Sessao = ingressoAtualizado.Sessao;
            Funcionario = ingressoAtualizado.Funcionario;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Tipo.Trim()))
                erros.Add("O campo \"Tipo\" é obrigatório!");
            if (string.IsNullOrEmpty(Assento.Trim()))
                erros.Add("O campo \"Assento\" é obrigatório!");
            if (string.IsNullOrEmpty(Sessao.ToString().Trim()))
                erros.Add("O campo \"Numero\" é obrigatório!");
            if (Valor >= 0)
                erros.Add("O campo \"Capacidade\" é obrigatório!");
            if (string.IsNullOrEmpty(Funcionario.ToString().Trim()))
                erros.Add("O campo \"Numero\" é obrigatório!");
            return erros;
        }

        public override string ToString()
        {
            return "Ingresso " + Sessao.ToString();
        }
    }
}
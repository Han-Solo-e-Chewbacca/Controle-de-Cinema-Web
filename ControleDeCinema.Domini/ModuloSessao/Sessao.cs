using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controle_de_Cinema_Web.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeCinema.Dominio.ModuloSessao
{
    public class Sessao:EntidadeBase
    {
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public int QtdIngressos { get; set; }

        public Sessao()
        {
        }
        public Sessao(Sala sala, DateTime horario, Filme filme, int qtdIngressos)
        {
            Sala = sala;
            Horario = horario;
            Filme = filme;
            QtdIngressos = qtdIngressos;
        }

        public override void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
        {
            Sessao sessaoAtualizada = (Sessao)entidadeAtualizada;

            Sala = sessaoAtualizada.Sala;
            Horario = sessaoAtualizada.Horario;
            Filme = sessaoAtualizada.Filme;
            QtdIngressos = sessaoAtualizada.QtdIngressos;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Sala.Numero.Trim()))
                erros.Add("O campo \"Sala\" é obrigatório!");
            if (Horario <= DateTime.Now)
                erros.Add("O campo \"Horário\" é obrigatório!");
            if (Filme == null) 
                erros.Add("O campo \"Filme\" é obrigatório!");
            if (QtdIngressos >= 0)
                erros.Add("O campo \"Qtd.Ingressos\" é obrigatório!");

            return erros;
        }

        public override string ToString()
        {
            return Sala.ToString() + Filme.Titulo + Horario.Hour;
        }
    }
}
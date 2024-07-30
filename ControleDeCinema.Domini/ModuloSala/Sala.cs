using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controle_de_Cinema_Web.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloSessao;

namespace ControleDeCinema.Dominio.ModuloSala
{
    public class Sala : EntidadeBase
    {
        public string Numero { get; set; }

        public int Capacidade { get; set; }

        public Sala()
        {
        }
        public Sala(string Numero, int Capacidade)
        {
            this.Numero = Numero;
            this.Capacidade = Capacidade;
        }

        public override void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
        {
            Sala salaAtualizada = (Sala)entidadeAtualizada;

            Numero = salaAtualizada.Numero;
            Capacidade = salaAtualizada.Capacidade;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Numero.Trim()))
                erros.Add("O campo \"Numero\" é obrigatório!");

            if (Capacidade >=0)
                erros.Add("O campo \"Capacidade\" é obrigatório!");

            return erros;
        }

        public override string ToString()
        {
            return "Sala "+Numero;
        }
    }
}
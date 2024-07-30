using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Controle_de_Cinema_Web.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSessao;

namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme : EntidadeBase
    {
        public string Titulo { get; set; }

        public string Duracao { get; set; }

        public string Genero { get; set; }

        public Filme()
        {
        }
        public Filme(string titulo, string duracao, string genero)
        {
            Titulo = titulo;
            Duracao = duracao;
            Genero = genero;
        }

        public override void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
        {
            Filme FilmeAtualizado = (Filme)entidadeAtualizada;

            Titulo = FilmeAtualizado.Titulo;
            Duracao = FilmeAtualizado.Duracao;
            Genero = FilmeAtualizado.Genero;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"Titulo\" é obrigatório!");
            if (string.IsNullOrEmpty(Duracao.Trim()))
                erros.Add("O campo \"Duracao\" é obrigatório!");
            if (string.IsNullOrEmpty(Genero.Trim()))
                erros.Add("O campo \"Capacidade\" é obrigatório!");

            return erros;
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
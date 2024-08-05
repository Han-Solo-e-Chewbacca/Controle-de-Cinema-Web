using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;

public class InserirSessaoViewModel
{
    [Required(ErrorMessage = "É necessário selecionar uma sala!")]
    public Sala Sala { get; set; }
    public DateTime Horario { get; set; }

    [Required(ErrorMessage = "É necessário selecionar um filme!")]
    public Filme Filme { get; set; }
    [Required(ErrorMessage = "É necessário selecionar uma quantidade de ingressos!")]
    public int QtdIngressos { get; set; }
    public List<SelectListItem> Salas { get; set; }
    public List<SelectListItem> Filmes { get; set; }
}

public class EditarSessaoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "É necessário selecionar uma sala!")]
    public Sala Sala { get; set; }
    public DateTime Horario { get; set; }

    [Required(ErrorMessage = "É necessário selecionar um filme!")]
    public Filme Filme { get; set; }
    [Required(ErrorMessage = "É necessário selecionar uma quantidade de ingressos!")]
    public int QtdIngressos { get; set; }
    public List<SelectListItem> Salas  { get; set; }
    public List<SelectListItem> Filmes { get; set; }
}


public class ExcluirSessaoViewModel
{
    public int Id { get; set; }
    public Sala Sala { get; set; }
    public DateTime Horario { get; set; }
    public Filme Filme { get; set; }
    public int QtdIngressos { get; set; }
}

public class ListarSessaoViewModel
{
    public int Id { get; set; }
    public Sala Sala { get; set; }
    public DateTime Horario { get; set; }
    public Filme Filme { get; set; }
    public int QtdIngressos { get; set; }
}


public class DetalhesSessaoViewModel
{
    public int Id { get; set; }
    public Sala Sala { get; set; }
    public DateTime Horario { get; set; }
    public Filme Filme { get; set; }
    public int QtdIngressos { get; set; }
}


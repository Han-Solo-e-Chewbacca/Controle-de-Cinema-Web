using System;
using System.ComponentModel.DataAnnotations;

public class InserirFilmeViewModel
{
    [Required(ErrorMessage = "O campo título é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo título necessita de ao menos 3 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo duração é obrigatório!")]
    public string Duracao { get; set; } 
   
    [Required(ErrorMessage = "O campo duração é obrigatório!")]
    public string Genero { get; set; }
    
}

public class EditarFilmeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo título é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo título necessita de ao menos 3 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo duração é obrigatório!")]
    public string Duracao { get; set; }

    [Required(ErrorMessage = "O campo duração é obrigatório!")]
    public string Genero { get; set; }
}


public class ExcluirFilmeViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Duracao { get; set; }
    public string Genero { get; set; }
}

public class ListarFilmeViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Duracao { get; set; }
    public string Genero { get; set; }
}

public class DetalhesFilmeViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Duracao { get; set; }
    public string Genero { get; set; }
}

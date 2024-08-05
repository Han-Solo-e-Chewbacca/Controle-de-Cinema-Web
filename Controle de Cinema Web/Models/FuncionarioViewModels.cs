using System;
using System.ComponentModel.DataAnnotations;

public class InserirFuncionarioViewModel
{
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo nome necessita de ao menos 3 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo login é obrigatório!")]
    public string Login { get; set; } 
   
    [Required(ErrorMessage = "O campo senha é obrigatório!")]
    public string Senha { get; set; }
}

public class EditarFuncionarioViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo nome necessita de ao menos 3 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo login é obrigatório!")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório!")]
    public string Senha { get; set; }
}


public class ExcluirFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}

public class ListarFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}

public class DetalhesFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}

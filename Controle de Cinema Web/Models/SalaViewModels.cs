using System;
using System.ComponentModel.DataAnnotations;

public class InserirSalaViewModel
{
    [Required(ErrorMessage = "O campo número é obrigatório!")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "O campo capacidade é obrigatório!")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor de capacidade deve ser maior que zero!")]
    public int Capacidade { get; set; } 
   

}

public class EditarSalaViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo número é obrigatório!")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "O campo capacidade é obrigatório!")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor de capacidade deve ser maior que zero!")]
    public int Capacidade { get; set; }

}

public class ExcluirSalaViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidade { get; set; }
    }

    public class ListarSalaViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidade { get; set; }
    }

    public class DetalhesSalaViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidade { get; set; }
    }


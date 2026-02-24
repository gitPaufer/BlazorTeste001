using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public class FuncionarioDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MinLength(2, ErrorMessage = "Nome deve ter no mínimo 2 caracteres")]
    public string Nome { get; set; } = string.Empty;

    public string? Cpf { get; set; }
}

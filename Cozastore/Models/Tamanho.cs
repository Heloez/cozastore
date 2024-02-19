using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cozastore.Models;

[Table("Tamanho")]
public class Tamanho
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe a Sigla")]
    [StringLength(5, ErrorMessage = " A Sigla deve possuir no máximo 5 caracteres")]
    public string Sigla { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")] 
    [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]   
    public string Nome { get; set; } 
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cozastore.models;

[Table("Categoria")]
public class Categoria
{
     [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")] 
    [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]   
    public string Nome { get; set; } 

    [StringLength(300)]

    public string foto { get; set; }

    [Display(Name = "Exibir com filtro?")]

     public bool filtrar { get; set; } = false;

     [Display(Name = "Exibir com Banner?")]
      public bool banner { get; set; }

        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }
         [ForeignKey("CategoriaPaiId")]
        public Categoria CategoriaPai { get; set; }

}
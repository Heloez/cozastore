using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cozastore.Models;

[Table("ProdutoFoto")]

public class ProdutoFoto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
   [Display(Name ="Produto")]
   [Required(ErrorMessage ="Por favor, enforme o produto")]
   public int ProdutoId {get; set;}
   [ForeignKey("ProdutoId")]
   public Produto Produto {get; set;}  

    [Required(ErrorMessage = "Por favor, faça upload da foto")] 
    [StringLength(300)]   
    public string ArquivoFoto { get; set; } 


    [Display(Name = "Foto Destaque?")]
    public bool Destaque {get; set;}
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cozastore.Models;

[Table("Estoque")]

public class Estoque
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
   [Display(Name ="Produto")]
   [Required(ErrorMessage ="Por favor, enforme o produto")]
   public int ProdutoId {get; set;}
   [ForeignKey("ProdutoId")]
   public Produto Produto {get; set;}  

   [Display(Name ="Tamanho")]
   [Required(ErrorMessage ="Por favor, enforme o tamanho")]
   public int TamanhoId {get; set;}
   [ForeignKey("TamanhoId")]
   public Tamanho Tamanho {get; set;}  

   [Display(Name ="Cor")]
   [Required(ErrorMessage ="Por favor, enforme a cor")]
   public int CorId {get; set;}
   [ForeignKey("CorId")]
   public Cor Cor {get; set;}  

    [Display(Name = "Preço de Venda")]
    [Column(TypeName = "décimal(12,2)")]
    public decimal? Preco { get; set; }

    [Display(Name = "Preço com desconto")]
    [Column(TypeName = "décimal(12,2)")]
    public decimal? PrecoDesconto { get; set; }

    [Display(Name ="Qtde em Estoque")]
    [Required(ErrorMessage ="Por favor, informe a Qtde em Estoque")]
    public int QtdeEstoque {get; set;}
}

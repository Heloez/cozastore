using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cozastore.models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Cozastore.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")] 
    [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]   
    public string Nome { get; set; }
    
    [Display(Name ="Descrição Resumida")]
    [StringLength(1000, ErrorMessage = "A descrção resumida deve possuir no máximo 1000 caractéres")]

    public string DescricaoResumida { get; set; }

    [Display(Name ="Descrição Completa")]
    [StringLength(8000, ErrorMessage = "A descrção Completa deve possuir no máximo 8000 caractéres")]

    public string DescricaoCompleta { get; set; }

    [Display(Name = "SKU")]
    [StringLength(10, ErrorMessage = "O SKU deve possuir no máximo 10 caractéres")]

    public string SKU { get; set; }

    [Display(Name = "Preço")]
    [Column(TypeName = "décimal(12,2)")]
    [Required(ErrorMessage = "Por favor, informe o preço da venda")]
    public decimal Preco { get; set; }

    [Display(Name = "Preço com desconto")]
    [Column(TypeName = "décimal(12,2)")]
    [Required(ErrorMessage = "Por favor, informe o preço com Desconto")]
    public decimal PrecoDesconto { get; set; }

    [Display(Name ="Produtoem destaque?")]
    public bool Destaque { get; set; } = false;

    [Column(TypeName = "decimal(8,3)")]
    public double Peso { get; set; } = 0;

    [StringLength(50, ErrorMessage = "O material deve possuir no áximo 50 caracteres")]
    public string material { get; set; } 
    
     [Display(Name = "dimensões")]
     [StringLength(20, ErrorMessage = "A dimensões deve possuir no áximo 50 caracteres")]

     public string Dimensao { get; set;}

    [Display(Name ="Categoria")]
    [Required(ErrorMessage = "Por favor, informe a categoria")]

        public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]

    public Categoria Categoria { get; set;}
    } 

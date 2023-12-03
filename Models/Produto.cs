using System.ComponentModel.DataAnnotations.Schema;
using Lisator.models;

namespace listator.models;

public class Produto{
    public int ProdutoId { get; set; }
    public string? Modelo { get; set; }
    public string? NumeroSerie { get; set; }
    public string? Patrimonio { get; set; }
    List<Categoria>? Categorias { get; set; }
    public int CategoriaID { get; set; }
}
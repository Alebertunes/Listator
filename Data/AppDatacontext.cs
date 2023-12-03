using Lisator.models;
using listator.models;
using Microsoft.EntityFrameworkCore;

namespace Listator.models;

public class Appdatacontext :  DbContext {

public Appdatacontext(DbContextOptions<Appdatacontext> options) : base(options){

}

public DbSet<Categoria> Categorias{ get; set; }

public DbSet<Produto> Produtos { get; set; }

}
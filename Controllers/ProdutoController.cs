using listator.models;
using Listator.Controllers;
using Listator.models;
using Microsoft.AspNetCore.Mvc;

namespace listator.Controllers;

[ApiController]
[Route("Listator/Produto")]

public class ProdutoController : ControllerBase {

    private readonly Appdatacontext _ctx;

    public ProdutoController(Appdatacontext ctx) => _ctx = ctx;

    [HttpGet]
    [Route("Listar")]

    public IActionResult Listar(){
        try{

            List<Produto> produtos = _ctx.Produtos.ToList();

            return produtos.Count == 0? NotFound() : Ok(produtos);

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]

    public IActionResult Cadastrar([FromBody] Produto produto){
        try{
            _ctx.Add(produto);
            _ctx.SaveChanges();
            return Created("",produto);

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("atualizar")]

    public IActionResult Atualizar(int id, [FromBody] Produto produtoAtualizado){
        try{
            Produto? produtoEncontrado = _ctx.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if(produtoEncontrado == null){
                return BadRequest("Nenhum produto encontrado");
            }

            if(produtoAtualizado.Modelo != null){
            produtoEncontrado.Modelo = produtoAtualizado.Modelo;
            }
            if(produtoAtualizado.NumeroSerie != null){
            produtoEncontrado.NumeroSerie = produtoAtualizado.NumeroSerie;
            }
            if(produtoAtualizado.Patrimonio != null){
            produtoEncontrado.Patrimonio = produtoAtualizado.Patrimonio;
            }
            if(produtoEncontrado.CategoriaID != 0){
            produtoEncontrado.CategoriaID = produtoAtualizado.CategoriaID;
            }

            _ctx.Update(produtoEncontrado);
            _ctx.SaveChanges();
            return Ok("Produto atualizado");

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("Deletar")]

    public IActionResult Deletar(int produtoId){
        try{

            Produto? produto = _ctx.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto == null){
                return BadRequest("Nenhum produto encontrado");
            }

            _ctx.Remove(produto);
            _ctx.SaveChanges();
            return Ok("Produto deletado");

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }
}
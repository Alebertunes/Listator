using Lisator.models;
using Listator.models;
using Microsoft.AspNetCore.Mvc;

namespace Listator.Controllers;

[ApiController]
[Route("Listaor/Categoria")]

public class CategoriaController : ControllerBase {

    private readonly Appdatacontext _ctx;

    public CategoriaController(Appdatacontext ctx ) =>_ctx = ctx;

    [HttpGet]
    [Route("listar")]

    public IActionResult Listar(){
        try{

            List<Categoria> categorias = _ctx.Categorias.ToList();
            return Ok(categorias);
        }catch(Exception e){

            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult cadastrar([FromBody] Categoria categoria){

        try{
        
        _ctx.Add(categoria);
        _ctx.SaveChanges();
        return Created("", categoria);

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("Aualizar/{id}")]

    public IActionResult Atualizar(int id, [FromBody] Categoria categoria){

        try{

        Categoria? categoriasEncontrada = _ctx.Categorias.FirstOrDefault(c => c.CategoriaID == id);

        if (id <= 0){
            return BadRequest("Numero de ID invalido");
        }else
        if(categoriasEncontrada == null){
            return BadRequest("Nenhuma categoria encontrada");
        }
      

        if(categoriasEncontrada.Nome != categoria.Nome){
        categoriasEncontrada.Nome = categoria.Nome;
        }
        _ctx.Update(categoriasEncontrada);
        _ctx.SaveChanges();
        return Ok("Categoria atualizado");
        
        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }


    [HttpDelete]
    [Route("Deletar")]
    public IActionResult Deletar(int categoriaId){
        try{

            Categoria? categoria = _ctx.Categorias.FirstOrDefault(c => c.CategoriaID == categoriaId);

            if(categoriaId <= 0 ){
                return BadRequest("Numero de Id invalido");
            }else 
                if(categoria == null){
            return BadRequest("Nenhum categoria encontrada");
            }

            _ctx.Remove(categoria);
            _ctx.SaveChanges();
            return Ok("Categoria excluida");

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }
}
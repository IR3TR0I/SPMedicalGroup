using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using Senai.SPMGMobile.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/usuarios
    [Route("api/[controller]")]
     // Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    [Authorize(Roles = "1")]
    public class UsuariosController : ControllerBase
    {
      private IUsuarioRepository _usuarioRepository {get ; set; }

    private UsuariosController()
    {
        _usuarioRepository = new UsuarioRepository();
    }


    [HttpGet]
    public IActionResult Get()
    {
        try
        {
         // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.Listar());
        }
        catch (Exception erro)
        {
              
            return BadRequest(erro);
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetbyId(int id)
    {
        try
        {
            // Retorna a resposta da requisição e chama o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
        catch (Exception ErrorMessage)
        {

            return BadRequest(ErrorMessage);
        } 
    }
    [HttpPost]
    public IActionResult Post(Usuario novoUsuario)
    {
        try
        {
            // Faz a chamada para o método
            _usuarioRepository.Cadastrar(novoUsuario);
            // Retorna um status code
            return StatusCode(201);
        }
        catch (Exception ex)
        {  
            return BadRequest(ex);
        }
    }


    [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chamando o método
                _usuarioRepository.Deletar(id);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex);
            }
        }
    }
}


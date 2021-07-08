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
    //Resposta da API em formato JSON
    [Produces("application/json")]
    //Rota: http://localhost:5000/api/tiposUsuarios
    [Route("api/[controller]")]
    //Controlador API
    [ApiController]

    //Acesso apenas ao adm
    [Authorize(Roles = "1")]
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuariosRepository _tiposUsuarioRepository {get ; set; }

        public TiposUsuariosController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna a requisição e chama o método
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception Erro)
            {
                
                return BadRequest(Erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna a requisição e chama o método
                return Ok(_tiposUsuarioRepository.BuscarPorId());
            }
            catch (Exception Erro)
            {
                
                return BadRequest(Erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {
                //Retorna a requisição e chama o método
                _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);
                
                //retornar Status Code 201
                return StatusCode(201);
            }
            catch (Exception Ex)
            {
                
                return BadRequest(Ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            try
            {
                //Retorna a requisição e chama o método
                _tiposUsuarioRepository.Atualizar(id,tipoUsuarioAtualizado);
                //retornar status code 204
                return StatusCode(204);
            }
            catch (Exception Erro)
            {
                
                return BadRequest(Erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna a requisição e chama o método de deletar por Id
                _tiposUsuarioRepository.Deletar(id);

                //retornar um 204
                return StatusCode(204);
            }
            catch (Exception Erro)
            {
                
                return BadRequest(Erro);
            }
        }
    }
}

        


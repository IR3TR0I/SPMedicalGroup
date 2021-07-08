﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using Senai.SPMGMobile.WebApi.Repositories;
using Senai.SPMGMobile.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private new IUsuarioRepository User { get; set; }

        public LoginController()
        {
            User = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            try
            {
                Usuario Login = User.Login(login.Email, login.Senha);

                if (Login == null)
                {
                    return NotFound("Usuario ou senha incorretos");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, Login.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Login.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, Login.IdTipoUsuario.ToString()),
                    new Claim("role", Login.IdTipoUsuario.ToString()),
                    new Claim("nameUser", Login.Email)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Medical-chave-autenticacao"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "MedGrup.webApi",
                        audience: "MedGrup.webApi",
                        claims: Claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: creds
                    );

                return Ok(
                        new { token = new JwtSecurityTokenHandler().WriteToken(token) }
                    );

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}


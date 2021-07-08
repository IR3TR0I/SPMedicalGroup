using Senai.SPMGMobile.WebApi.Contexts;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();


        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if(UsuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if(usuarioAtualizado.Senha != null)
            {
                UsuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            if(usuarioAtualizado.IdTipoUsuario >0 )
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios
                .Select(u => new Usuario() 
                { 
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TiposUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novousuario)
        {
            ctx.Usuarios.Add(novousuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }


        public List<Usuario> Listar()
        {
            return ctx.Usuarios
            .Select(u => new Usuario() 
            { 
                IdUsuario = u.IdUsuario,
                NomeUsuario = u.NomeUsuario,
                Email = u.Emai,
                IdTipoUsuario = u.IdTipoUsuario,

                IdTipoUsuarioNavigation = new TiposUsuario()
                {
                    IdTipoUsuario = u.IdTipoUsuarioNavigatio.IdTipoUsuario,
                    TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                }
            })
            .ToList();        
        }

        public Usuario Login(String email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}


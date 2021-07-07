using Microsoft.EntityFrameworkCore;
using Senai.SPMGMobile.WebApi.Contexts;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public void Atualizar(int id, TiposUsuario tiposUsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}


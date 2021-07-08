using Sp_medical_group_tarde.Context;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMG.WebApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(tu =>tu.IdSituacao == id);
        }

        public List<SituacaoRepository> Listar()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
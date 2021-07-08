using Microsoft.EntityFrameworkCore;
using Sp_medical_group_tarde.Context;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMG.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(tu => tu.IdMedico ==id);
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos
            
            .Include(p => IdUsuarioNavigation)

            .ToList();
        }
    }
}
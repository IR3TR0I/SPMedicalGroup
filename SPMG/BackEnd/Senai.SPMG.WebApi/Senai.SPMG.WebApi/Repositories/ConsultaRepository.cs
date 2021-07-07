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
    public class ConsultaRepository : IConsultaRepository
    {

        SpMedGroupContext ctx = new SpMedGroupContext();
        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if(consultaAtualizada.Consulta != null)
            {
                consultaBuscada.nomeConsulta = consultaAtualizada.NomeConsultas;
            }

            if (consultaAtualizada.IdConsulta != null)
            {
                consultaBuscada.IdConsulta = consultaAtualizada.IdConsulta;
            }

            if (consultaAtualizada.IdConsulta > 0)
            {
                consultaBuscada.IdConsulta = consultaAtualizada.IdConsulta;
            }

            if (consultaAtualizada. == true || consultaAtualizada. == false)
            {
                consultaBuscada. = consultaAtualizada.;
            }
        }

        public Consulta BuscarporId(int Id)
        {
            return ctx.Consultas.FirstOrDefault(e => e.IdConsulta == Id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consultas.Remove(BuscarporId(id));

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas

            .ToList();
            
        }
    }
}

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

        public void Atualizar(int id, Consultum consultaAtualizada)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            if (consultaAtualizada.IdMedico != null)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            if (consultaAtualizada.IdSituacao != null)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            if (consultaAtualizada.DataConsulta > DateTime.Now)
            {
                consultaAtualizada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            if (consultaAtualizada.Descricao != null)
            {
                consultaBuscada.Descricao = consultaBuscada.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public Consultum BuscarporId(int Id)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdConsulta == Id);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consulta.Remove(BuscarporId(id));

            ctx.SaveChanges();
        }



        public List<Consultum> Listar()
        {
            return ctx.Consulta
                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .Include(p => p.IdMedicoNavigation.IdUsuarioNavigation)

                .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)

                .Include(p => p.IdMedicoNavigation.IdEspecialidadeNavigation)

                .ToList();

        }

        public List<Consultum> Minhas(int IdUsuario)
        {
            Paciente pacienteBuscado = ctx.Pacientes.FirstOrDefault(x => x.IdUsuario == IdUsuario);

            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(x => x.IdUsuario == IdUsuario);

            if (pacienteBuscado != null)
            {
                return ctx.Consulta.Where(x => x.IdPaciente == pacienteBuscado.IdPaciente)

                .Include(x => x.IdPacienteNavigation)

                .Include(x => x.IdMedicoNavigation)

                .Include(x => x.IdSituacaoNavigation)

                .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)

                .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(x => x.IdPacienteNavigation.IdUsuarioNavigation)

                .Select(x => new Consultum
                {
                    IdConsulta = x.IdConsulta,
                    IdMedicoNavigation = x.IdMedicoNavigation,
                    IdSituacaoNavigation = x.IdSituacaoNavigation,
                    Descricao = x.Descricao,
                    DataConsulta = x.DataConsulta
                })

                .ToList();
            }

            if (medicoBuscado != null)
            {
                return ctx.Consulta.Include(x => x.IdMedicoNavigation).Where(x => x.IdMedico == medicoBuscado.IdMedico)
                    .Include(x => x.IdPacienteNavigation)

                    .Include(x => x.IdMedicoNavigation)

                    .Include(x => x.IdSituacaoNavigation)

                    .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)

                    .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)

                    .Include(x => x.IdPacienteNavigation.IdUsuarioNavigation)

                    .Select(x => new Consultum
                    {
                        IdConsulta = x.IdConsulta,
                        IdMedicoNavigation = x.IdMedicoNavigation,
                        IdPacienteNavigation = x.IdPacienteNavigation,
                        IdSituacaoNavigation = x.IdSituacaoNavigation,
                        Descricao = x.Descricao,
                        DataConsulta = x.DataConsulta
                    })

                    .ToList();
            }

            return null;
        }

        public void Descricao(int id, Consultum novaDescricao)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            if (novaDescricao.Descricao != null)
            {
                consultaBuscada.Descricao = novaDescricao.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void AlterarStatus(int id, string ConsultaPermissao)
        {
            Consultum Consultabuscada = ctx.Consulta

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .FirstOrDefault(p => p.IdConsulta == id);

            switch (ConsultaPermissao)
            {
                case "1":
                    Consultabuscada.IdSituacao = 1;
                    break;

                case "2":
                    Consultabuscada.IdSituacao = 2;
                    break;

                case "3":
                    Consultabuscada.IdSituacao = 3;
                    break;

                default:
                    Consultabuscada.IdSituacao = Consultabuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(Consultabuscada);

            ctx.SaveChanges();
        }

        public void AlterarStatus(int id, int? idSituacao)
        {
            Consultum Consultabuscada = ctx.Consulta

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .FirstOrDefault(p => p.IdConsulta == id);

            ctx.Consulta.Update(Consultabuscada);

            ctx.SaveChanges();
        }
    }
}

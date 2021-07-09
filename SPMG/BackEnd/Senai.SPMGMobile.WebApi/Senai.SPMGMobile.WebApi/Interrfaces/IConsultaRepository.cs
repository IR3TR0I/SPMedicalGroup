using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface IConsultaRepository
    {
        List<Consultum> Listar();


        Consultum BuscarporId(int Id);

        void Cadastrar(Consultum novaConsulta);

        List<Consultum> Minhas(int IdUsuario);
        void Atualizar(int id, Consultum consultaAtualizada);
        void AlterarStatus(int id, String ConsultaPermissao);
        void Deletar(int id);
        void Descricao(int id, Consultum novaDescricao);
        void AlterarStatus(int id, int? idSituacao);
    }
}

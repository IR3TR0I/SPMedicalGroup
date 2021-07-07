using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface IConsultaRepository 
    {
       List<Consulta> Listar();


       Consulta BuscarporId(int Id);

       void Cadastrar(Consulta novaConsulta);


       void Atualizar(int id, Consulta consultaAtualizada); 

       void Deletar(int id); 
    }
}

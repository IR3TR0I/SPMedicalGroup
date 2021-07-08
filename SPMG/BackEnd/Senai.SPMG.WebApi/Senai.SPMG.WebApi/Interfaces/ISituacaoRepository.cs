namespace Senai.SPMG.WebApi.Interfaces
{
    public interface ISituacaoRepository
    {
        List<Situacao> Listar();
        Situacao BuscarPorId(int id);
    }
}
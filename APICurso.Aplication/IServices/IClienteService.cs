using WebApresentacao.Domain.DTO;
using WebApresentacao.Domain.Entities;

namespace WebApresentacao.Application.IServices
{
    public interface IClienteService : IBaseService<Cliente>
    {
        public void SalvarNovoCliente(RecebeCadastrarCliente recebeCadastrarCliente);              

        public void AlterarNomeCliente(RecebeClienteAlterarNome recebeClienteAlterarNome);
       
    }
}

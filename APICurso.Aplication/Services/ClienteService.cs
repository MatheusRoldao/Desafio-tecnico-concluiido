using WebApresentacao.Application.IServices;
using WebApresentacao.Domain.DTO;
using WebApresentacao.Domain.Entities;
using WebApresentacao.Infra.IRepositories;
using System;

namespace WebApresentacao.Application.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository repository;

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            repository = clienteRepository;
        }

        //parte para criar regras de negocio especificas para cada entidade    
       
        public void AlterarNomeCliente(RecebeClienteAlterarNome recebeClienteAlterarNome)
        {
            Cliente cliente = repository.FindById(recebeClienteAlterarNome.Id);
            if (cliente == null) throw new Exception("Cliente não encontrado"); // verifica se cliente esta no banco de dados
            
            var nomeAntigo = cliente.NomeCliente;
            
            cliente.AlterarNomeCliente(recebeClienteAlterarNome.NomeCliente);
            repository.Save(cliente);
          
            

        }
       

        public void SalvarNovoCliente(RecebeCadastrarCliente recebeCadastrarCliente)
        {
            //salvando um novo cliente
           Cliente cliente = new Cliente();
            try
            {            
                                  
                cliente.CadastrarNovoCliente( recebeCadastrarCliente.Id, recebeCadastrarCliente.NomeCliente, recebeCadastrarCliente.Sexo, recebeCadastrarCliente.DataNascimento, recebeCadastrarCliente.Idade, recebeCadastrarCliente.IdCidade, recebeCadastrarCliente.Logadouro);
                repository.Save(cliente);
            }
            catch 
            {
                throw;
            }

            

        }
        
    }
}

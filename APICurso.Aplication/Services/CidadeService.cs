using WebApresentacao.Application.IServices;
using WebApresentacao.Domain.DTO;
using WebApresentacao.Domain.Entities;
using WebApresentacao.Infra.IRepositories;
using System;
namespace WebApresentacao.Application.Services
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository repository;

        public CidadeService(ICidadeRepository cidadeRepository) : base(cidadeRepository)
        {
            repository = cidadeRepository;
        }

        public void SalvarNovaCidade(RecebeCadastrarCidade recebeCadastrarCidade)
        {
            //salvando um nova Cidade
            Cidade cidade = new Cidade();
            try
            {
                cidade.CadastrarNovaCidade(recebeCadastrarCidade.ID, recebeCadastrarCidade.Nome, recebeCadastrarCidade.Estado);
                repository.Save(cidade);
            }
            catch
            {
                throw;
            }



        }
       
    }
}

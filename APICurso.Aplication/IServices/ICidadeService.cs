using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApresentacao.Domain.DTO;
using WebApresentacao.Domain.Entities;

namespace WebApresentacao.Application.IServices
{
   public interface ICidadeService : IBaseService<Cidade>
    {
        public void SalvarNovaCidade(RecebeCadastrarCidade recebeCadastrarCidade);
    }
}

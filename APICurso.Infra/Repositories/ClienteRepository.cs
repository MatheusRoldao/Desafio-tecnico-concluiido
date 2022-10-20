using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApresentacao.Domain.Entities;
using WebApresentacao.Infra.Contexts;
using WebApresentacao.Infra.IRepositories;

namespace WebApresentacao.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        Context context;
        public ClienteRepository(Context ctx) : base(ctx)
        {
            context = ctx;
        }

        public override ICollection<Cliente> Get()
        {
            return context.Set<Cliente>()
                      .Include(t => t.Cidade.Id)
                      .ToList() as ICollection<Cliente>;
                     
        }
    }
}

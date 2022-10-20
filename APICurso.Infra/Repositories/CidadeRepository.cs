using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApresentacao.Domain.Entities;
using WebApresentacao.Infra.Contexts;
using WebApresentacao.Infra.IRepositories;

namespace WebApresentacao.Infra.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        Context context;
        public CidadeRepository(Context ctx) : base(ctx)
        {
            context = ctx;
        }

    }
}

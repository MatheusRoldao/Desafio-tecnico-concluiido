using WebApresentacao.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApresentacao.Infra.Mapping
{
    public class ClienteMap
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.NomeCliente);
            builder.Property(r => r.Sexo);
            builder.Property(r => r.DataNascimento);
            builder.Property(r => r.Idade);
            builder.Property(r => r.IdCidade);
            builder.HasOne(r => r.Cidade)
                   .WithMany()
                   .HasForeignKey(x => x.IdCidade);
            builder.Property(r => r.Logadouro);
            
        }
    }
}

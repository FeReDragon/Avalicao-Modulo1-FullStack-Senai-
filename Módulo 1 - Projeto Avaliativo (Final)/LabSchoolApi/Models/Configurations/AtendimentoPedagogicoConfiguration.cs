using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabSchoolApi.Models.Configurations
{
    public class AtendimentoPedagogicoConfiguration : IEntityTypeConfiguration<AtendimentoPedagogico>
    {
        public void Configure(EntityTypeBuilder<AtendimentoPedagogico> builder)
        {
            builder.HasKey(ap => ap.Codigo);
            builder.Property(ap => ap.Codigo).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(ap => ap.Aluno).WithMany(a => a.AtendimentosPedagogicos).HasForeignKey(ap => ap.CodigoAluno);
            builder.HasOne(ap => ap.Pedagogo).WithMany(p => p.AtendimentosPedagogicos).HasForeignKey(ap => ap.CodigoPedagogo);
        }
    }
}


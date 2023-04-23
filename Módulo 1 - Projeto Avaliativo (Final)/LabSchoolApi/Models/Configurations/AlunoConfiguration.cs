using LabSchoolApi.Models;
using LabSchoolApi.Models.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabSchoolApi.Models.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            // Configurações da classe Pessoa (superclasse)
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Telefone).HasMaxLength(20);
            builder.Property(p => p.DataNascimento).IsRequired();
            builder.Property(p => p.CPF).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();

            builder.HasKey(p => p.Codigo);

            // Configurações da classe Aluno
            builder.Property(a => a.SituacaoMatricula).IsRequired().HasConversion<string>();
            builder.Property(a => a.Nota).HasColumnType("decimal(5, 2)");
            builder.Property(a => a.QuantidadeAtendimentosPedagogicos).IsRequired();
        }
    }
}


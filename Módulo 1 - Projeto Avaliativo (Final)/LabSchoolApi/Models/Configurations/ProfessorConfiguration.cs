using LabSchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabSchoolApi.Models.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            // Configurações da classe Pessoa (superclasse)
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Telefone).HasMaxLength(20);
            builder.Property(p => p.DataNascimento).IsRequired();
            builder.Property(p => p.CPF).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();

            builder.HasKey(p => p.Codigo);

            // Configurações da classe Professor
            builder.Property(p => p.FormacaoAcademica).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ExperienciaDesenvolvimento).IsRequired().HasMaxLength(200);
        }
    }
}


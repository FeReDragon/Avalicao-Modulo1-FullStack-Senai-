using LabSchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabSchoolApi.Models.Configurations
{
    public class PedagogoConfiguration : IEntityTypeConfiguration<Pedagogo>
    {
        public void Configure(EntityTypeBuilder<Pedagogo> builder)
        {
            // Configurações da classe Pessoa (superclasse)
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Telefone).HasMaxLength(20);
            builder.Property(p => p.DataNascimento).IsRequired();
            builder.Property(p => p.CPF).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();

            // Configurar chave primária
            builder.HasKey(p => p.Codigo);

            // Configurações da classe Pedagogo
            builder.Property(p => p.QuantidadeAtendimentosPedagogicosRealizados).IsRequired();
        }
    }
}



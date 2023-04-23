using System;
using LabSchoolApi.Models;
using LabSchoolApi.Models.Enums;
using LabSchoolApi.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LabSchoolApi.Data
{
    public class LabSchoolDbContext : DbContext
    {
        public LabSchoolDbContext(DbContextOptions<LabSchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Pedagogo> Pedagogos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new PedagogoConfiguration());
            modelBuilder.ApplyConfiguration(new AtendimentoPedagogicoConfiguration());

            modelBuilder.Entity<Aluno>().Property(a => a.Codigo).ValueGeneratedOnAdd();
            modelBuilder.Entity<Pedagogo>().Property(p => p.Codigo).ValueGeneratedOnAdd();
            modelBuilder.Entity<Professor>().Property(p => p.Codigo).ValueGeneratedOnAdd();


            // Adicione aqui as configurações HasData
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { Codigo = 1, Nome = "Bart", Telefone = "11-11111-1", DataNascimento = new DateTime(2014, 10, 29), CPF = "11839750012", SituacaoMatricula = SituacaoMatricula.Inativo, Nota = 3.5, QuantidadeAtendimentosPedagogicos = 0 },
                new Aluno { Codigo = 2, Nome = "Lisa", Telefone = "11-22222-2", DataNascimento = new DateTime(2012, 10, 29), CPF = "17158947092", SituacaoMatricula = SituacaoMatricula.Ativo, Nota = 100, QuantidadeAtendimentosPedagogicos = 0 },
                new Aluno { Codigo = 3, Nome = "Meggie", Telefone = "12-20002-2", DataNascimento = new DateTime(2019, 10, 29), CPF = "63701210082", SituacaoMatricula = SituacaoMatricula.Ativo, Nota = 90, QuantidadeAtendimentosPedagogicos = 0 },
                new Aluno { Codigo = 4, Nome = "Milhouse", Telefone = "11-33333-2", DataNascimento = new DateTime(2014, 10, 29), CPF = "30119137052", SituacaoMatricula = SituacaoMatricula.Ativo, Nota = 80, QuantidadeAtendimentosPedagogicos = 0 },
                new Aluno { Codigo = 5, Nome = "Nelson", Telefone = "11-44333-4", DataNascimento = new DateTime(2007, 10, 29), CPF = "95704094011", SituacaoMatricula = SituacaoMatricula.Inativo, Nota = 20, QuantidadeAtendimentosPedagogicos = 0 }
            );

            modelBuilder.Entity<Professor>().HasData(
                new Professor { Codigo = 1, Nome = "Walter", Telefone = "14-22998-1", DataNascimento = new DateTime(1982, 10, 30), CPF = "40539019088", FormacaoAcademica = "Mestre em Química", Estado = (StatusProfessor)0, ExperienciaDesenvolvimento = 20 },
                new Professor { Codigo = 2, Nome = "Jesse", Telefone = "44-11111-1", DataNascimento = new DateTime(1997, 10, 30), CPF = "96107295034", FormacaoAcademica = "Bacharel em Física", Estado = (StatusProfessor)0, ExperienciaDesenvolvimento = 5 },
                new Professor { Codigo = 3, Nome = "Hank", Telefone = "44-11111-1", DataNascimento = new DateTime(1984, 10, 30), CPF = "70685977051", FormacaoAcademica = "Doutor em Geologia", Estado = (StatusProfessor)0, ExperienciaDesenvolvimento = 15 },
                new Professor { Codigo = 4, Nome = "Gustavo", Telefone = "44-11001-1", DataNascimento = new DateTime(1977, 10, 30), CPF = "57408927099", FormacaoAcademica = "MBA em Administração", Estado = (StatusProfessor)1, ExperienciaDesenvolvimento = 25 }
            );

            modelBuilder.Entity<Pedagogo>().HasData(
                new Pedagogo { Codigo = 1, Nome = "Saul", Telefone = "44-11998-1", DataNascimento = new DateTime(1980, 10, 30), CPF = "86940162033", QuantidadeAtendimentosPedagogicosRealizados = 20 },
                new Pedagogo { Codigo = 2, Nome = "John", Telefone = "11-67333-4", DataNascimento = new DateTime(2000, 10, 30), CPF = "62316840021", QuantidadeAtendimentosPedagogicosRealizados = 30 },
                new Pedagogo { Codigo = 3, Nome = "Sansa", Telefone = "22-22333-4", DataNascimento = new DateTime(2004, 10, 30), CPF = "49850253056", QuantidadeAtendimentosPedagogicosRealizados = 15 },
                new Pedagogo { Codigo = 4, Nome = "Tyrion", Telefone = "33-77333-4", DataNascimento = new DateTime(1990, 10, 30), CPF = "39125106047", QuantidadeAtendimentosPedagogicosRealizados = 25 },
                new Pedagogo { Codigo = 5, Nome = "Sandor", Telefone = "11-33333-2", DataNascimento = new DateTime(1995, 10, 30), CPF = "13289759018", QuantidadeAtendimentosPedagogicosRealizados = 10 }
            );
        }
    }
}

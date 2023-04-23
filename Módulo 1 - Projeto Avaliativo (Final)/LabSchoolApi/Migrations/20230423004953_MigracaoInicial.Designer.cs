﻿// <auto-generated />
using System;
using LabSchoolApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabSchoolApi.Migrations
{
    [DbContext(typeof(LabSchoolDbContext))]
    [Migration("20230423004953_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LabSchoolApi.Models.Aluno", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("QuantidadeAtendimentosPedagogicos")
                        .HasColumnType("int");

                    b.Property<string>("SituacaoMatricula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Codigo");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            CPF = "11839750012",
                            DataNascimento = new DateTime(2014, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Bart",
                            Nota = 3.5m,
                            QuantidadeAtendimentosPedagogicos = 0,
                            SituacaoMatricula = "Inativo",
                            Telefone = "11-11111-1"
                        },
                        new
                        {
                            Codigo = 2,
                            CPF = "17158947092",
                            DataNascimento = new DateTime(2012, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Lisa",
                            Nota = 100m,
                            QuantidadeAtendimentosPedagogicos = 0,
                            SituacaoMatricula = "Ativo",
                            Telefone = "11-22222-2"
                        },
                        new
                        {
                            Codigo = 3,
                            CPF = "63701210082",
                            DataNascimento = new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Meggie",
                            Nota = 90m,
                            QuantidadeAtendimentosPedagogicos = 0,
                            SituacaoMatricula = "Ativo",
                            Telefone = "12-20002-2"
                        },
                        new
                        {
                            Codigo = 4,
                            CPF = "30119137052",
                            DataNascimento = new DateTime(2014, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Milhouse",
                            Nota = 80m,
                            QuantidadeAtendimentosPedagogicos = 0,
                            SituacaoMatricula = "Ativo",
                            Telefone = "11-33333-2"
                        },
                        new
                        {
                            Codigo = 5,
                            CPF = "95704094011",
                            DataNascimento = new DateTime(2007, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Nelson",
                            Nota = 20m,
                            QuantidadeAtendimentosPedagogicos = 0,
                            SituacaoMatricula = "Inativo",
                            Telefone = "11-44333-4"
                        });
                });

            modelBuilder.Entity("LabSchoolApi.Models.AtendimentoPedagogico", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CodigoAluno")
                        .HasColumnType("int");

                    b.Property<int>("CodigoPedagogo")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoAluno");

                    b.HasIndex("CodigoPedagogo");

                    b.ToTable("AtendimentoPedagogico");
                });

            modelBuilder.Entity("LabSchoolApi.Models.Pedagogo", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QuantidadeAtendimentosPedagogicosRealizados")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Codigo");

                    b.ToTable("Pedagogos");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            CPF = "86940162033",
                            DataNascimento = new DateTime(1980, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Saul",
                            QuantidadeAtendimentosPedagogicosRealizados = 20,
                            Telefone = "44-11998-1"
                        },
                        new
                        {
                            Codigo = 2,
                            CPF = "62316840021",
                            DataNascimento = new DateTime(2000, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "John",
                            QuantidadeAtendimentosPedagogicosRealizados = 30,
                            Telefone = "11-67333-4"
                        },
                        new
                        {
                            Codigo = 3,
                            CPF = "49850253056",
                            DataNascimento = new DateTime(2004, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Sansa",
                            QuantidadeAtendimentosPedagogicosRealizados = 15,
                            Telefone = "22-22333-4"
                        },
                        new
                        {
                            Codigo = 4,
                            CPF = "39125106047",
                            DataNascimento = new DateTime(1990, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Tyrion",
                            QuantidadeAtendimentosPedagogicosRealizados = 25,
                            Telefone = "33-77333-4"
                        },
                        new
                        {
                            Codigo = 5,
                            CPF = "13289759018",
                            DataNascimento = new DateTime(1995, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Sandor",
                            QuantidadeAtendimentosPedagogicosRealizados = 10,
                            Telefone = "11-33333-2"
                        });
                });

            modelBuilder.Entity("LabSchoolApi.Models.Professor", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("ExperienciaDesenvolvimento")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.Property<string>("FormacaoAcademica")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Codigo");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            CPF = "40539019088",
                            DataNascimento = new DateTime(1982, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = 0,
                            ExperienciaDesenvolvimento = 20,
                            FormacaoAcademica = "Mestre em Química",
                            Nome = "Walter",
                            Telefone = "14-22998-1"
                        },
                        new
                        {
                            Codigo = 2,
                            CPF = "96107295034",
                            DataNascimento = new DateTime(1997, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = 0,
                            ExperienciaDesenvolvimento = 5,
                            FormacaoAcademica = "Bacharel em Física",
                            Nome = "Jesse",
                            Telefone = "44-11111-1"
                        },
                        new
                        {
                            Codigo = 3,
                            CPF = "70685977051",
                            DataNascimento = new DateTime(1984, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = 0,
                            ExperienciaDesenvolvimento = 15,
                            FormacaoAcademica = "Doutor em Geologia",
                            Nome = "Hank",
                            Telefone = "44-11111-1"
                        },
                        new
                        {
                            Codigo = 4,
                            CPF = "57408927099",
                            DataNascimento = new DateTime(1977, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = 1,
                            ExperienciaDesenvolvimento = 25,
                            FormacaoAcademica = "MBA em Administração",
                            Nome = "Gustavo",
                            Telefone = "44-11001-1"
                        });
                });

            modelBuilder.Entity("LabSchoolApi.Models.AtendimentoPedagogico", b =>
                {
                    b.HasOne("LabSchoolApi.Models.Aluno", "Aluno")
                        .WithMany("AtendimentosPedagogicos")
                        .HasForeignKey("CodigoAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabSchoolApi.Models.Pedagogo", "Pedagogo")
                        .WithMany("AtendimentosPedagogicos")
                        .HasForeignKey("CodigoPedagogo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Pedagogo");
                });

            modelBuilder.Entity("LabSchoolApi.Models.Aluno", b =>
                {
                    b.Navigation("AtendimentosPedagogicos");
                });

            modelBuilder.Entity("LabSchoolApi.Models.Pedagogo", b =>
                {
                    b.Navigation("AtendimentosPedagogicos");
                });
#pragma warning restore 612, 618
        }
    }
}

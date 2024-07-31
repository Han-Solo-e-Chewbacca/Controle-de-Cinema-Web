using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using static System.Net.Mime.MediaTypeNames;

namespace ControleDeCinema.Infra.Orm.Compartilhado
{
    public class ControleDeCinemaDbContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ControleDeCinemaOrm;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>(filmeBuilder =>
            {
                filmeBuilder.ToTable("TBFilme");

                filmeBuilder.Property(m => m.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                filmeBuilder.Property(m => m.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(200)"); 
                filmeBuilder.Property(m => m.Genero)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                filmeBuilder.Property(m => m.Duracao)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Funcionario>(funcionarioBuilder =>
            {
                funcionarioBuilder.ToTable("TBFuncionario");

                funcionarioBuilder.Property(m => m.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                funcionarioBuilder.Property(m => m.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                funcionarioBuilder.Property(m => m.Login)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                funcionarioBuilder.Property(m => m.Senha)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Sala>(salaBuilder =>
            {
                salaBuilder.ToTable("TBSala");

                salaBuilder.Property(m => m.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                salaBuilder.Property(m => m.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                salaBuilder.Property(m => m.Capacidade)
                    .IsRequired()
                    .HasColumnType("int");
                
            });
            modelBuilder.Entity<Sessao>(sessaoBuilder =>
            {
                sessaoBuilder.ToTable("TBSessao");

                sessaoBuilder.Property(m => m.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                sessaoBuilder.Property(m => m.Horario)
                    .IsRequired()
                    .HasColumnType("datetime");
                sessaoBuilder.HasOne(m => m.Filme)
                    .WithMany()
                    .IsRequired()
                    .HasForeignKey("Filme_Id")
                    .HasConstraintName("FK_TBSessao_TBFilme")
                    .OnDelete(DeleteBehavior.NoAction);
                sessaoBuilder.HasOne(m => m.Sala)
                    .WithMany()
                    .IsRequired()
                    .HasForeignKey("Sala_Id")
                    .HasConstraintName("FK_TBSessao_TBSala")
                    .OnDelete(DeleteBehavior.NoAction);
                sessaoBuilder.Property(m => m.QtdIngressos)
                    .IsRequired()
                    .HasColumnType("int");
            });

            modelBuilder.Entity<Ingresso>(ingressoBuilder =>
            {
                ingressoBuilder.ToTable("TBIngresso");

                ingressoBuilder.Property(m => m.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                ingressoBuilder.Property(m => m.Assento)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                ingressoBuilder.HasOne(m => m.Sessao)
                    .WithMany()
                    .IsRequired()
                    .HasForeignKey("Sessao_Id")
                    .HasConstraintName("FK_TBIngresso_TBSessao")
                    .OnDelete(DeleteBehavior.NoAction);
                ingressoBuilder.HasOne(m => m.Funcionario)
                    .WithMany()
                    .IsRequired()
                    .HasForeignKey("Funcionario_Id")
                    .HasConstraintName("FK_TBIngresso_TBFuncionario")
                    .OnDelete(DeleteBehavior.NoAction);
                ingressoBuilder.Property(m => m.Tipo)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                ingressoBuilder.Property(m => m.Valor)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");
            });


            //modelBuilder.Entity<Conta>(contaBuilder =>
            //{
            //    contaBuilder.ToTable("TBConta");

            //    contaBuilder.Property(c => c.Id)
            //        .IsRequired()
            //        .ValueGeneratedOnAdd();

            //    contaBuilder.Property(c => c.Titular)
            //        .IsRequired()
            //        .HasColumnType("varchar(200)");

            //    contaBuilder.Property(c => c.Abertura)
            //        .IsRequired()
            //        .HasColumnType("datetime2");

            //    contaBuilder.Property(c => c.Fechamento)
            //        .HasColumnType("datetime2");

            //    contaBuilder.Property(c => c.EstaAberta)
            //        .IsRequired()
            //        .HasColumnType("bit");

            //    contaBuilder.HasOne(c => c.Mesa)
            //        .WithMany(m => m.Contas)
            //        .HasForeignKey("Mesa_Id")
            //        .HasConstraintName("FK_TBConta_TBMesa")
            //        .IsRequired()
            //        .OnDelete(DeleteBehavior.Restrict);

            //    contaBuilder.HasOne(c => c.Garcom)
            //      .WithMany()
            //      .HasForeignKey("Garcom_Id")
            //      .HasConstraintName("FK_TBConta_TBGarcom")
            //      .IsRequired()
            //      .OnDelete(DeleteBehavior.Restrict);

            //    contaBuilder.HasMany(c => c.Pedidos)
            //        .WithOne()
            //        .HasForeignKey("Conta_Id")
            //        .HasConstraintName("FK_TBConta_TBProduto");
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}

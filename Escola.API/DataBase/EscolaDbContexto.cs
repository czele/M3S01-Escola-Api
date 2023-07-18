using Microsoft.EntityFrameworkCore;
using Escola.API.Model;

namespace Escola.API.DataBase
{
    public class EscolaDbContexto : DbContext
    {
        public virtual DbSet<Aluno> Alunos { get; set; }

        public virtual DbSet<Turma> Turmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=escolaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("ALUNO");

            modelBuilder.Entity<Aluno>().HasKey(x => x.Id)
                                        .HasName("PK_ALUNO_ID");

            modelBuilder.Entity<Aluno>().Property(x => x.Id)
                                        .HasColumnName("PK_ID" )
                                        .HasColumnType("int");

            modelBuilder.Entity<Aluno>().Property(x => x.Nome)
                                        .IsRequired()
                                        .HasColumnName("NOME")
                                        .HasColumnType("varchar")
                                        .HasMaxLength(50);

            modelBuilder.Entity<Aluno>().Property(x => x.Sobrenome)
                                        .IsRequired()
                                        .HasColumnName("SOBRENOME")
                                        .HasColumnType("varchar")
                                        .HasMaxLength(150);

            modelBuilder.Entity<Aluno>().Ignore(x => x.Idade);

            modelBuilder.Entity<Aluno>().Property(x => x.Email)
                                        .IsRequired()
                                        .HasColumnName("EMAIL")
                                        .HasColumnType("varchar")
                                        .HasMaxLength(50);


            modelBuilder.Entity<Aluno>().HasIndex(x => x.Email)
                                        .IsUnique();

            modelBuilder.Entity<Aluno>().Property(x => x.Genero)
                                        .HasColumnName("GENERO")
                                        .HasColumnType("varchar")
                                        .HasMaxLength(20);

            modelBuilder.Entity<Aluno>().Property(x => x.Telefone)
                                        .HasColumnName("TELEFONE")
                                        .HasColumnType("varchar")
                                        .HasMaxLength(30);

            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento)
                                        .HasColumnName("DATA_NASCIMENTO")
                                        .HasColumnType("datetime2");


            modelBuilder.Entity<Turma>().ToTable("TURMA");

            modelBuilder.Entity<Turma>().Property(x => x.Id)
                                        .HasColumnType("int")
                                        .HasColumnName("ID");

            modelBuilder.Entity<Turma>().HasKey(x => x.Id);


            modelBuilder.Entity<Turma>().Property(x => x.Curso)
                                        .HasColumnType("varchar")
                                        .HasMaxLength(50)
                                        .HasDefaultValue("Curso Basico")
                                        .HasColumnName("CURSO");

            modelBuilder.Entity<Turma>().Property(x => x.Nome)
                                        .HasColumnType("varchar")
                                        .HasMaxLength(50)
                                        .HasColumnName("NOME");

            modelBuilder.Entity<Turma>().HasIndex(x => x.Nome)
                                        .IsUnique();


            modelBuilder.Entity<Boletim>().ToTable("BOLETIM");

            modelBuilder.Entity<Boletim>().HasKey(x => x.Id)
                                          .HasName("PK_BOLETIM_ID");

            modelBuilder.Entity<Boletim>().Property(x => x.Id)
                                          .HasColumnName("ID")
                                          .HasColumnType("int");

            modelBuilder.Entity<Boletim>().Property(x => x.Data)
                                          .HasColumnName("DATA")
                                          .HasColumnType("datetime2");

            modelBuilder.Entity<Boletim>().HasOne(x => x.Aluno)
                                          .WithMany(x => x.Boletins)
                                          .HasForeignKey(x => x.AlunoId);

            modelBuilder.Entity<Boletim>().HasMany(x => x.NotasMaterias)
                                          .WithOne(x => x.Boletim)
                                          .HasForeignKey(x => x.MateriaId);

            modelBuilder.Entity<NotasMateria>().ToTable("NOTAS_MATERIA");

            modelBuilder.Entity<NotasMateria>().HasKey(x => x.Id)
                                               .HasName("PK_NOTASMATERIA_ID");

            modelBuilder.Entity<NotasMateria>().HasOne(x => x.Materia)
                                               .WithMany(x => x.NotasMaterias)
                                               .HasForeignKey(x => x.MateriaId);

            modelBuilder.Entity<Materia>().ToTable("MATERIA");

            modelBuilder.Entity<Materia>().HasKey(x => x.Id)
                                          .HasName("PK_MATERIA_ID");

            modelBuilder.Entity<Materia>().Property(x => x.Id)
                                          .HasColumnName("ID")
                                          .HasColumnType("int");

            modelBuilder.Entity<Materia>().Property(x => x.Nome)
                                          .HasColumnName("NOME")
                                          .HasColumnType("varchar")
                                          .HasMaxLength(50);

        }
    }
}

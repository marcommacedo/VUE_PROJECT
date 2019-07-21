using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projectschoolAPI.Models;

namespace projectschoolAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>().HasData(new List<Professor>()
            {
                new Professor() {
                    Id = 1,
                    Nome = "Marco"
                }
            });

            builder.Entity<Aluno>().HasData(new List<Aluno>()
            {
                new Aluno() {
                    Id = 1,
                    Nome = "Michelle",
                    Sobrenome = "Pardinho",
                    DataNascimento = "21/04/1993",
                    ProfessorId = 1
                }
            });
        }
    }
}
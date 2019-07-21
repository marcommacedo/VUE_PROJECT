using System.Threading.Tasks;
using projectschoolAPI.Models;

namespace projectschoolAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor);
        Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor);
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno);
    }
}
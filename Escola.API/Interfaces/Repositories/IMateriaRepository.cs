using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Repositories
{
    public interface IMateriaRepository : IBaseRepository<Materia, int>
    {
        List<Materia> ObterPorNome(string NomeAluno);
    }
}

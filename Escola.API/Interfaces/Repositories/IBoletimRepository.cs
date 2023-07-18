using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Repositories
{
    public interface IBoletimRepository : IBaseRepository<Boletim, int>
    {
        List<Boletim> ObterPorAlunoId(int AlunoId);
    }
}


using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class BoletimRepository : BaseRepository<Boletim, int>, IBoletimRepository
    {
       public BoletimRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }

        public List<Boletim> ObterPorAlunoId(int AlunoId)
        {
            return _context.Set<Boletim>().Where(x => x.AlunoId == AlunoId).ToList();
        }
    }
}

using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class MateriaRepository : BaseRepository<Materia, int>, IMateriaRepository
    {
        public MateriaRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }

        public List<Materia> ObterPorNome(string NomeAluno)
        {
            return _context.Set<Materia>().Where(x => x.Nome == NomeAluno).ToList();
        }


    }
}

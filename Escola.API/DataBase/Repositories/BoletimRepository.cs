
using Escola.API.Interfaces.Repositories;
using Escola.API.Model;

namespace Escola.API.DataBase.Repositories
{
    public class BoletimRepository : BaseRepository<Boletim, int>, IBoletimRepository
    {
       public BoletimRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }
    }
}

using System.Collections.Generic;

namespace Escola.API.Model
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<NotasMateria> NotasMaterias { get; set; }
    }
}

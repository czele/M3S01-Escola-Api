using Escola.API.Model;

namespace Escola.API.DTO
{
    public class MateriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public MateriaDTO() { }

        public MateriaDTO(Materia materia)
        {
            Nome = materia.Nome;
        }

    }
}

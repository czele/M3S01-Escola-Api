using Escola.API.DTO;

namespace Escola.API.Model
{
    public class NotasMateria
    { 
        public int Id { get; set; }
        public virtual Boletim Boletim { get; set; }
        public int BoletimId { get; set; }
        public virtual Materia Materia { get; set; }
        public int MateriaId { get; set; }
        public int Nota { get; set; }
       
        public NotasMateria() { }
        public NotasMateria(NotasMateriaDTO notasMateriaDTO)
        {
            Id = notasMateriaDTO.Id;
            BoletimId = notasMateriaDTO.BoletimId;
            MateriaId = notasMateriaDTO.MateriaId;
            Nota = notasMateriaDTO.Nota;
        }

        public void Update(NotasMateria notasMateria)
        {
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
    }
}
}

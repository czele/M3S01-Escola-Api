using Escola.API.Model;
using System;

namespace Escola.API.DTO
{
    public class BoletimDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int AlunoId { get; set; }

        public BoletimDTO() { }
        public BoletimDTO(Boletim boletim)
        {
            Id = boletim.Id;
            Data = boletim.Data;
            AlunoId = boletim.AlunoId;
        }
    }
}

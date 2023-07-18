using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Services
{
    public interface IBoletimService
    {
        public Boletim ObterPorId(int id);
        public List<Boletim> ObterPorAluno(int AlunoId);
        Boletim Cadastrar(Boletim boletim);
        Boletim Atualizar(Boletim boletim);
        void Excluir(int id);
    }
}

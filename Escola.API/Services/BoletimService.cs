using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Services
{
    public class BoletimService : IBoletimService
    {
        private readonly IBoletimRepository _boletimRepository;
        private readonly IAlunoService _alunoService;

        public BoletimService(IBoletimRepository boletimRepository, IAlunoService alunoService)
        {
            _boletimRepository = boletimRepository;
            _alunoService = alunoService;
        }
        
        public Boletim Atualizar(Boletim boletim)
        {
            var boletimAt = _boletimRepository.ObterPorId(boletim.Id);

            if (boletimAt == null)
            {
                throw new NotFoundException("Boletin não cadastrado");

            }
            boletimAt.Update(boletim);

            _boletimRepository.Atualizar(boletimAt);
            return boletimAt;
        }

        public Boletim Cadastrar(Boletim boletim)
        {
            if(_alunoService.ObterPorId(boletim.AlunoId) == null)
            {
                throw new NotFoundException("Aluno não cadastrado");
            }
            _boletimRepository.Inserir(boletim);
            return boletim;
        }

        public void Excluir(int id)
        {
            var boletim = _boletimRepository.ObterPorId(id);

            if (boletim == null)
            {
                throw new NotFoundException("Boletim não cadastrado");
            }

            _boletimRepository.Excluir(boletim);
        }

        public List<Boletim> ObterPorAluno(int AlunoId)
        {
            return ObterPorAluno(AlunoId);
        }

        public Boletim ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

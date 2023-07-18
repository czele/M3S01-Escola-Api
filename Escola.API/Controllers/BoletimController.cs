using Escola.API.DTO;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoletimController : Controller
    {  
        private readonly IBoletimService _boletimService;

        public BoletimController(IBoletimService boletimService)
        {
            _boletimService = boletimService;
        }

        [HttpPost("/alunos/{AlunoId}/boletins")]
        public ActionResult Post(BoletimDTO boletim, int AlunoId)
        {
            boletim.AlunoId = AlunoId;

            _boletimService.Cadastrar(new Boletim(boletim));
            return Ok();
        }
    }
}

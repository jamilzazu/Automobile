using Automobile.Proprietarios.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Controllers
{
    [ApiController]
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioController(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        [AllowAnonymous]
        [HttpGet("proprietarios")]
        public async Task<IEnumerable<Proprietario>> Index()
        {
            return await _proprietarioRepository.ObterTodos();
        }

        [AllowAnonymous]
        [HttpGet("proprietario/{id}")]
        public async Task<Proprietario> ProprietarioPorId(Guid id)
        {
            return await _proprietarioRepository.ObterPorId(id);
        }
        [AllowAnonymous]
        [HttpGet("proprietario/{cpf}")]
        public async Task<Proprietario> ProprietarioPorCpf(string cpf)
        {
            return await _proprietarioRepository.ObterPorCpf(cpf);
        }
    }
}
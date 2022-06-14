using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_UC14_AT2.Models;
using SENAI_UC14_AT2.Repositories;

namespace SENAI_UC14_AT2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar() 
        {
            try 
            {
                return Ok(_projetoRepository.Listar());
            }

            catch(Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Busca projeto por id.
        /// </summary>
        /// <param name="id">chave do campo.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id) 
        {
            try 
            {
                Projeto projeto = _projetoRepository.BuscarPorId(id);

                if(projeto == null) 
                {
                    return NotFound();
                }

                return Ok(projeto);
            }

            catch (Exception) 
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto) 
        {
            try 
            {
                _projetoRepository.Cadastrar(projeto);

                return StatusCode(201);
            }

            catch (Exception) 
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            try
            {
                Projeto projetoEncontrado = _projetoRepository.BuscarPorId(id);

                if (projetoEncontrado == null)
                {
                    return NotFound();
                }

                _projetoRepository.Atualizar(id, projeto);

                return StatusCode(204);
            }

            catch (Exception) 
            {
                throw;
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Projeto projetoEncontrado = _projetoRepository.BuscarPorId(id);

                if (projetoEncontrado == null)
                {
                    return NotFound();
                }

                _projetoRepository.Deletar(id);

                return StatusCode(204);
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository filmeRepository { get; set; }

        public FilmesController()
        {
            filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return filmeRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain filmeRecebido)
        {
            filmeRepository.Cadastrar(filmeRecebido);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = filmeRepository.GetById(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum Filme Encontrado");
            }

            return Ok(filmeBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            filmeRepository.Deletar(id);

            return Ok("Genero Deletado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = filmeRepository.GetById(id);

            try
            {
                filmeRepository.Atualizar(id, filmeAtualizado);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }        
    }
}
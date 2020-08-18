using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLucasVieiraVicente.Data.Repository.Interfaces;
using ApiLucasVieiraVicente.Data.UoW.Interfaces;
using ApiLucasVieiraVicente.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLucasVieiraVicente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IUoW _uow;
        public GameController(IUoW uow) { _uow = uow; }

        // GET: GameController
        [HttpGet]        
        public ActionResult GetAll()
        {
            var values = _uow.GameRepository.GetAll();
            return Ok(values);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public ActionResult GetById(Guid id)
        {
            var game = _uow.GameRepository.GetById(id);
            _uow.Dispose();

            if (game == null)
                return BadRequest("Nenhum jogo encontrado");
            else
                return Ok(game);
        }

        [HttpGet]
        [Route("ByName/{name}")]
        public ActionResult GetByName(string name)
        {
            var game = _uow.GameRepository.GetByName(name);
            _uow.Dispose();

            if (game == null)
                return BadRequest("Nenhum jogo encontrado");
            else
                return Ok(game);
        }

        // POST: GameController/Create
        [HttpPost]        
        public ActionResult Create([FromBody]Game game)
        {
            try
            {
                if (!game.IsValid())
                    return BadRequest("Verifique os campos");

                _uow.GameRepository.Add(game);
                _uow.Commit();

                return Ok("Valores registrados com sucesso");
            }
            catch
            {
                return BadRequest("Houve um erro na requisição");
            }
        }
        
        [HttpPut]        
        public ActionResult Edit(Game game)
        {
            try
            {
                if (!game.IsValid())
                    return BadRequest("Verifique os campos");

                _uow.GameRepository.Update(game);
                _uow.Commit();

                return Ok("Atualização realizada com sucesso!");
            }
            catch
            {
                return BadRequest("Houve um problema na requisição");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var game = _uow.GameRepository.GetById(id);

                if (game == null)
                    return BadRequest("Nenhum jogo foi encontrado");

                _uow.GameRepository.Remove(game);
                _uow.Commit();

                return Ok("Remoção concluida com sucesso");
            }
            catch
            {
                return BadRequest("Houve falha na requisição");
            }
        }
    }
}

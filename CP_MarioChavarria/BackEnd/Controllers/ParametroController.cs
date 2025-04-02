using BackEnd.DTO;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParametroController : ControllerBase
    {

        IParametroService _parametroService;

        public ParametroController(IParametroService parametroService)
        {
            this._parametroService = parametroService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var parametros = _parametroService.GetParametros();
            return Ok(parametros);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var parametro = _parametroService.GetById(id);
            return Ok(parametro);
        }

        // POST api/<ProgramaController>
        [HttpPost]
        public void Post([FromBody] ParametroDTO parametroDTO)
        {
            _parametroService.Add(parametroDTO);
        }

        // PUT api/<ProgramaController>/5
        [HttpPut]
        public void Put([FromBody] ParametroDTO parametroDTO)
        {
            _parametroService.Update(parametroDTO);
        }

        // DELETE api/<ProgramaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _parametroService.Delete(id);
        }

    }
}

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

        //POST api/<ProgramaController>
        [HttpPost]
        public void Post([FromBody] ParametroDTO parametroDTO)
        {
            _parametroService.Add(parametroDTO);

        }

        //[HttpPost]
        //public IActionResult Post([FromBody] ParametroDTO parametroDTO)
        //{
        //    if (parametroDTO == null)
        //    {
        //        return BadRequest("The parametroDTO field is required.");
        //    }
        //    try
        //    {
        //        string descripcionString = "SGVsbG8gV29ybGQ=";
        //        parametroDTO.Descripcion= Convert.FromBase64String(descripcionString);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    _parametroService.Add(parametroDTO);
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] ParametroDTO parametroDTO)
        //{
        //    if (parametroDTO == null)
        //    {
        //        return BadRequest("The parametroDTO field is required.");
        //    }

        //    _parametroService.Add(parametroDTO);
        //    return Ok();
        //}



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

using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaController : ControllerBase
    {
        IProgramaService _programaService;

        public ProgramaController(IProgramaService programaService)
        {
            this._programaService = programaService;
        }


        // GET: api/<ProgramaController>
        [HttpGet]
        public ActionResult Get()
        {
            var programas = _programaService.GetProgramas();
            return Ok(programas);
        }

        // GET api/<ProgramaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var programa = _programaService.GetProgramaById(id);
            return Ok(programa);
        }

        // POST api/<ProgramaController>
        [HttpPost]
        public void Post([FromBody] ProgramaDTO programaDTO)
        {
            _programaService.AddPrograma(programaDTO);
        }

        // PUT api/<ProgramaController>/5
        [HttpPut]
        public void Put([FromBody] ProgramaDTO programaDTO)
        {
            _programaService.UpdatePrograma(programaDTO);
        }

        // DELETE api/<ProgramaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _programaService.DeletePrograma(id);
        }
    }
}

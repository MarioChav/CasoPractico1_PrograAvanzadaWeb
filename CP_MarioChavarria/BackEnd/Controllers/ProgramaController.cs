using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
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
            var programa = _programaService.GetById(id);
            return Ok(programa);
        }

        // POST api/<ProgramaController>
        [HttpPost]
        public void Post([FromBody] ProgramaDTO programaDTO)
        {
            _programaService.Add(programaDTO);
        }

        // PUT api/<ProgramaController>/5
        [HttpPut]
        public void Put([FromBody] ProgramaDTO programaDTO)
        {
            _programaService.Update(programaDTO);
        }

        // DELETE api/<ProgramaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _programaService.Delete(id);
        }
    }
}

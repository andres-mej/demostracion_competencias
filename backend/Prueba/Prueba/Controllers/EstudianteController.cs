using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using Prueba.BLL;
using Microsoft.Extensions.Configuration;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api")]
    public class EstudianteController : ControllerBase
    {

        private readonly ILogger<EstudianteController> _logger;
        private readonly IEstudianteLogic _estudianteLogic;
        private readonly IConfiguration _configuration;

        public EstudianteController(ILogger<EstudianteController> logger, IEstudianteLogic estudianteLogic, IConfiguration configuration)
        {
            this._logger = logger;
            this._estudianteLogic = estudianteLogic;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("estudiante")]
        public ActionResult<Estudiante> AddEstudiante([FromBody]EstudianteDTO newEstudianteDTO)
        {
            Estudiante newEstudiante = _estudianteLogic.AddEstudiante(newEstudianteDTO);
            // var dbServer = _configuration.GetSection("Database").GetSection("ConnectionString");
            // newEstudianteDTO.Nombres =
            return newEstudiante;
        }

        [HttpGet]
        [Route("estudiante")]
        public ActionResult<List<Estudiante>> GetEstudiantes()
        {
            return _estudianteLogic.GetAll();
        }

        [HttpPut]
        [Route("estudiante/{id}")]
        public ActionResult<Estudiante> UpdateEstudiante(string id, [FromBody]EstudianteDTO updateEstudianteDTO)
        {
            return _estudianteLogic.UpdateEstudiante(id, updateEstudianteDTO);
        }

        [HttpDelete]
        [Route("estudiante/{id}")]
        public ActionResult<Estudiante> DeleteEstudiante(string id)
        {
            return _estudianteLogic.DeleteEstudiante(id);
        }
    }

}

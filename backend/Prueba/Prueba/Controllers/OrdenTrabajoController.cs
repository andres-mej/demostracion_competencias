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

    public class OrdenTrabajoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<OrdenTrabajoController> _logger;
        private readonly IOrdenTrabajoLogic _ordenTrabajoLogic;

        public OrdenTrabajoController(ILogger<OrdenTrabajoController> logger, IOrdenTrabajoLogic ordenTrabajoLogic, IConfiguration configuration)
        {
            this._logger = logger;
            this._ordenTrabajoLogic = ordenTrabajoLogic;
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("ordenTrabajo")]
        public ActionResult<List<OrdenTrabajo>> GetOrdenTrabajo()
        {
            return _ordenTrabajoLogic.GetAll();
        }

        [HttpPost]
        [Route("ordenTrabajo")]
        public ActionResult<OrdenTrabajo> AddOrdenTrabajo([FromBody]OrdenTrabajoDTO newOrdenTrabajoDTO)
        {
            OrdenTrabajo newOrdenTrabajo = _ordenTrabajoLogic.AddOrden(newOrdenTrabajoDTO);
            return newOrdenTrabajo;
        }

        [HttpPut]
        [Route("ordenTrabajo/{id}")]
        public ActionResult<OrdenTrabajo> UpdateOrdenTrabajo( string id, [FromBody]OrdenTrabajoDTO updateOrdenTrabajoDTO)
        {
            return _ordenTrabajoLogic.UpdateOrdenTrabajo(id, updateOrdenTrabajoDTO);
        }

        [HttpDelete]
        [Route("ordenTrabajo/{id}")]
        public ActionResult<OrdenTrabajo> DeleteOrdenTrabajo(string id)
        {
            return _ordenTrabajoLogic.DeleteEstudiante(id);
        }

    }
}

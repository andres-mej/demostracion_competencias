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
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteLogic _clienteLogic;
        private readonly IConfiguration _configuration;

        public ClienteController(ILogger<ClienteController> logger, IClienteLogic clienteLogic, IConfiguration configuration)
        {
            this._logger = logger;
            this._clienteLogic = clienteLogic;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("cliente")]
        public ActionResult<Cliente> AddCliente([FromBody]ClienteDTO newClienteDTO)
        {
            Cliente newCliente = _clienteLogic.AddCliente(newClienteDTO);
            // var dbServer = _configuration.GetSection("Database").GetSection("ConnectionString");
            // newClienteDTO.Nombres =
            return newCliente;
        }

        [HttpGet]
        [Route("cliente")]
        public ActionResult<List<Cliente>> GetClientes()
        {
            return _clienteLogic.GetAll();
        }

        [HttpPut]
        [Route("cliente/{id}")]
        public ActionResult<Cliente> UpdateCliente(string id, [FromBody]ClienteDTO updateClienteDTO)
        {
            return _clienteLogic.UpdateCliente(id, updateClienteDTO);
        }

        [HttpDelete]
        [Route("cliente/{id}")]
        public ActionResult<Cliente> DeleteCliente(string id)
        {
            return _clienteLogic.DeleteCliente(id);
        }
    }

}

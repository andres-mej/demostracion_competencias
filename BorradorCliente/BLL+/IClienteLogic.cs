using System;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using System.Collections.Generic;

namespace Prueba.BLL
{
    public interface IClienteLogic
    {
        public Cliente AddCliente(ClienteDTO newCliente);
        public List<Cliente> GetAll();
        public Cliente UpdateCliente(string id, ClienteDTO updateCliente);
        public Cliente DeleteCliente(string id);
    }
}

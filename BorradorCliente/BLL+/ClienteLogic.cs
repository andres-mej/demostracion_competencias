using System;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using Prueba.DataBase;
using System.Collections.Generic;
using System.Linq;
namespace Prueba.BLL
{
    public class ClienteLogic: IClienteLogic
    {

        private readonly IClienteDB _clienteDB;
        public ClienteLogic(IClienteDB clienteDB)
        {
            this._clienteDB = clienteDB;
        }

        public Cliente AddCliente(ClienteDTO newCliente)
        {
            Cliente cliente = new Cliente()
            {
                Id = generateClienteId(),
                Nombres = newCliente.Nombres,
                Apellidos = newCliente.Apellidos
            };

            return _clienteDB.AddCliente(cliente);
        }

        public Cliente DeleteCliente(string id)
        {
            return _clienteDB.DeleteCliente(id);
        }

        public List<Cliente> GetAll()
        {
            return _clienteDB.GetAll();
        }

        public Cliente UpdateCliente(string id, ClienteDTO updateCliente)
        {
            Cliente cliente = new Cliente()
            {
                Nombres = updateCliente.Nombres,
                Apellidos = updateCliente.Apellidos
            };

            return _clienteDB.UpdateCliente(id, cliente);
        }

        private string generateClienteId()
        {
            if (GetAll().Count > 0)
            {
                Cliente lastCliente = GetAll().Last();
                int id = Convert.ToInt32(lastCliente.Id.Split("-")[1]) + 1;
                return "C-" + id;
            } else
            {
                return "C-0";

            }


        }
    }
}

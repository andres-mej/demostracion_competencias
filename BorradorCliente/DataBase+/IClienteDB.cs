using System;
using Prueba.DataBase.Models;
using System.Collections.Generic;

namespace Prueba.DataBase
{
    public interface IClienteDB
    {
        public Cliente AddCliente(Cliente newCliente);
        public List<Cliente> GetAll();
        public Cliente UpdateCliente(string id, Cliente updateCliente);
        public Cliente DeleteCliente(string id);
    }
}

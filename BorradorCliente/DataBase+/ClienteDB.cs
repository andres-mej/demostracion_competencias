using System;
using System.Collections.Generic;
using Prueba.DataBase.Models;
using System.Linq;

namespace Prueba.DataBase
{
    public class ClienteDB: IClienteDB
    {
        private List<Cliente> Clientes { get; set; }

        public ClienteDB()
        {
            this.Clientes = new List<Cliente> {
            new Cliente() {
                Id = "C-0",
                Nombres = "Javier",
                Apellidos = "Martinez Peña"
            },
            new Cliente() {
                Id="C-1",
                Nombres="Paola",
                Apellidos= "Figueroa Guzman"
            },
            new Cliente() {
                Id = "C-2",
                Nombres = "Kevin Daniel",
                Apellidos = "Herrera Polo"
            },
            new Cliente() {
                Id = "C-3",
                Nombres = "Manuel Jorge",
                Apellidos = "Rodriguez Lora"
            },
            new Cliente() {
                Id = "C-4",
                Nombres = "Carolina Vera",
                Apellidos = "Nuñez Rea"
            }
            };    
        }

        Cliente IClienteDB.AddCliente(Cliente newCliente)
        {
            this.Cliente.Add(newCliente);
            return newCliente;
        }

        Cliente IClienteDB.DeleteCliente(string id)
        {
            Cliente cliente = this.Clientes.FirstOrDefault(cli => cli.Id == id);
            if (cliente != null)
            {
                this.Clientes.RemoveAll((cli) => cli.Id == id);
            }
            return cliente;
        }

        List<Cliente> IClienteDB.GetAll()
        {
            return this.Clientes;
        }

        Cliente IClienteDB.UpdateCliente(string id, Cliente updateCliente)
        {
            Cliente newCliente = null;
            foreach(Cliente cliente in this.Clientes)
            {
                if (cliente.Id == id)
                {
                    newCliente = cliente;
                    cliente.Nombres = updateCliente.Nombres;
                    cliente.Apellidos = updateCliente.Apellidos;
                }
            }
            return newCliente;
        }
    }
}

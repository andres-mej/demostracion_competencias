using System;
using System.Collections.Generic;
using Prueba.DataBase.Models;
using System.Linq;

namespace Prueba.DataBase
{
    public class OrdenTrabajoDB : IOrdenTrabajoDB
    {
        private List<OrdenTrabajo> OrdenTrabajo { get; set; }

        public OrdenTrabajoDB()
        {
            this.OrdenTrabajo = new List<OrdenTrabajo>
            {
                new OrdenTrabajo()
                {
                    Id = "2022-01",
                    Estado = "Entregado",
                    FechaInicio = "2022-05-05",
                    FechaEntrega = "2022-05-10",
                    NombreProducto = "Persinas Roller Black Out",
                    Medidas = "3x6",
                    Cantidad = 19.06,
                    PrecioUnitario = 180,
                    PrecioTotal = 3430.8,
                    NombreCliente = "Hughes Schools",
                    TelefonoCliente = "77411223"

                },
                new OrdenTrabajo()
                {
                    Id = "2022-02",
                    Estado = "Terminado",
                    FechaInicio = "2022-05-06",
                    FechaEntrega = "2022-05-11",
                    NombreProducto = "Persinas Roller Black Out",
                    Medidas = "4x4.5",
                    Cantidad = 17.55,
                    PrecioUnitario = 180,
                    PrecioTotal = 3160,
                    NombreCliente = "Hughes Schools",
                    TelefonoCliente = "77411223"

                },
                new OrdenTrabajo()
                {
                    Id = "2022-03",
                    Estado = "Proceso",
                    FechaInicio = "2022-05-12",
                    FechaEntrega = "2022-05-17",
                    NombreProducto = "Persianas Eclipse Brasilero",
                    Medidas = "2x6.5",
                    Cantidad = 13.0,
                    PrecioUnitario = 250,
                    PrecioTotal = 3250,
                    NombreCliente = "Hughes Schools",
                    TelefonoCliente = "77411223"

                },
                new OrdenTrabajo()
                {
                    Id = "2022-04",
                    Estado = "Proceso",
                    FechaInicio = "2022-05-12",
                    FechaEntrega = "2022-05-17",
                    NombreProducto = "Persianas Eclipse Brasilero",
                    Medidas = "4x4.5",
                    Cantidad = 17.55,
                    PrecioUnitario = 250,
                    PrecioTotal = 4387.5,
                    NombreCliente = "Hughes Schools",
                    TelefonoCliente = "77411223"

                }
            };

        }

        OrdenTrabajo IOrdenTrabajoDB.AddOrdenTrabajo(OrdenTrabajo newOrden)
        {
            this.OrdenTrabajo.Add(newOrden);

            return newOrden;
        }

        OrdenTrabajo IOrdenTrabajoDB.DeleteOrdenTrabajo(string id)
        {
            OrdenTrabajo orden = this.OrdenTrabajo.FirstOrDefault(x => x.Id == id);
            if(orden == null)
            {
                this.OrdenTrabajo.RemoveAll( (ord) => ord.Id == id);
            }
            return orden;
        }

        List<OrdenTrabajo> IOrdenTrabajoDB.GetAll()
        {
            return this.OrdenTrabajo;
        }

        OrdenTrabajo IOrdenTrabajoDB.UpdateOrdenTrabajo(string id, OrdenTrabajo updateOrden)
        {
            OrdenTrabajo newOrden = null;

            foreach (OrdenTrabajo orden in this.OrdenTrabajo)
            {
                if (orden.Id == id)
                {
                    newOrden = orden;
                    orden.NombreProducto = updateOrden.NombreProducto;
                    orden.NombreCliente = updateOrden.NombreCliente;
                }
            }
            return newOrden;
        }


    }
}

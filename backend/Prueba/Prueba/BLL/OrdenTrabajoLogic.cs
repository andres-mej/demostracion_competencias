using System;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using Prueba.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace Prueba.BLL
{
    public class OrdenTrabajoLogic: IOrdenTrabajoLogic
    {
        private readonly IOrdenTrabajoDB _ordenTrabajoDB;
        public OrdenTrabajoLogic(IOrdenTrabajoDB ordenTrabajoDB)
        {
            this._ordenTrabajoDB = ordenTrabajoDB;
        }

        public OrdenTrabajo AddOrden(OrdenTrabajoDTO newOrdenTrabajo)
        {
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo()
            {
                Id = generateOrdenId(),
                Estado = newOrdenTrabajo.Estado,
                FechaInicio = newOrdenTrabajo.FechaInicio,
                FechaEntrega = newOrdenTrabajo.FechaEntrega,
                NombreProducto = newOrdenTrabajo.NombreProducto,
                Medidas = newOrdenTrabajo.Medidas,
                Cantidad = newOrdenTrabajo.Cantidad,
                PrecioUnitario = newOrdenTrabajo.PrecioUnitario,
                PrecioTotal = newOrdenTrabajo.PrecioTotal,
                NombreCliente = newOrdenTrabajo.NombreCliente,
                TelefonoCliente = newOrdenTrabajo.TelefonoCliente,
            };

            return _ordenTrabajoDB.AddOrdenTrabajo(ordenTrabajo);
        }

        public List<OrdenTrabajo> GetAll()
        {
            return _ordenTrabajoDB.GetAll();
        }

        public OrdenTrabajo UpdateOrdenTrabajo(string id, OrdenTrabajoDTO updateOrdenTrabajo)
        {
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo()
            {
                Estado = updateOrdenTrabajo.Estado,
                FechaInicio = updateOrdenTrabajo.FechaInicio,
                FechaEntrega = updateOrdenTrabajo.FechaEntrega,
                NombreProducto = updateOrdenTrabajo.NombreProducto,
                Medidas = updateOrdenTrabajo.Medidas,
                Cantidad = updateOrdenTrabajo.Cantidad,
                PrecioUnitario = updateOrdenTrabajo.PrecioUnitario,
                PrecioTotal = updateOrdenTrabajo.PrecioTotal,
                NombreCliente = updateOrdenTrabajo.NombreCliente,
                TelefonoCliente = updateOrdenTrabajo.TelefonoCliente
            };

            return _ordenTrabajoDB.UpdateOrdenTrabajo(id, ordenTrabajo);
        }

        public OrdenTrabajo DeleteEstudiante(string id)
        {
            return _ordenTrabajoDB.DeleteOrdenTrabajo(id);
        }
        private string generateOrdenId()
        {
            string newId = "";
            if(GetAll().Count > 0 )
            {
                OrdenTrabajo lastOrdenTrabajo = GetAll().Last();
                int id = Convert.ToInt32(lastOrdenTrabajo.Id.Split("-")[1]) + 1;
                newId = "2022-" + id;
            }
            else
            {
                newId = "2022-01";
            }
            return newId;
        }


    }
}

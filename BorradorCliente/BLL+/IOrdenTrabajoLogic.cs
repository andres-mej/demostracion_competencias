using System;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using System.Collections.Generic;

namespace Prueba.BLL
{
    public interface IOrdenTrabajoLogic
    {
        public OrdenTrabajo AddOrden(OrdenTrabajoDTO newOrden);
        public List<OrdenTrabajo> GetAll();
        public OrdenTrabajo UpdateOrdenTrabajo(string id, OrdenTrabajoDTO uppdateOrden);
        public OrdenTrabajo DeleteCliente(string id);
    }
}

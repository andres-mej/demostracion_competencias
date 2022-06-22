using System;
using Prueba.DataBase.Models;
using System.Collections.Generic;

namespace Prueba.DataBase
{
    public interface IOrdenTrabajoDB
    {
        public OrdenTrabajo AddOrdenTrabajo(OrdenTrabajo newOrden);
        public List<OrdenTrabajo> GetAll();
        public OrdenTrabajo UpdateOrdenTrabajo(string id, OrdenTrabajo updateOrden);
        public OrdenTrabajo DeleteOrdenTrabajo(string id);
    }
}

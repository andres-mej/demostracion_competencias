namespace Prueba.DataBase.Models
{
    public class OrdenTrabajo
    {
        public string Id { get; set; }
        public string Estado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaEntrega { get; set; }
        public string NombreProducto { get; set; }
        public string Medidas { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }

    }
}

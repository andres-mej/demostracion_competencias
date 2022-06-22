
import React, { useEffect, useState } from "react";
import axios from "axios";

interface IOrdenCompra {
  id: string;
  estado: string;
  fechaInicio: string;
  fechaEntrega: string;
  nombreProducto: string;
  medidas: string;
  cantidad: number;
  precioUnitario: number;
  precioTotal: number;
  nombreCliente: string;
  telefonoCliente: string;
}

export const OrdenTrabajo = () => {
  //(props)
  const baseUrl = "https://localhost:5001/api/";

    const [estado, setEstado] = useState("");
    const [fechaInicio, setFechaInicio] = useState("");
    const [fechaEntrega, setFechaEntrega] = useState("");
    const [nombreProducto, setNombreProducto] = useState("");
    const [medidas, setMedidas] = useState("");
    const [cantidad, setCantidad] = useState(0);
    const [precioUnitario, setPrecioUnitario] = useState(0);
    const [precioTotal, setPrecioTotal] = useState(0);
    const [nombreCliente, setNombreCliente] = useState("");
    const [telefonoCliente, setTelefonoCliente] = useState("");
    const [ordenesCompra, setOrdenesCompra] = useState<IOrdenCompra[]>([]);

    // useEffect(() => {
    //   getOrdenesCompra();
    // });

    useEffect(() => {
      
      getOrdenesCompra();
    }, []);

    function getOrdenesCompra() {
      axios.get(baseUrl + "ordenTrabajo").then((res) => {
        setOrdenesCompra(res.data);
        console.log('repite',res.data);
      });
    }
    function postEstudiantes() {
      axios
        .post(baseUrl + "ordenTrabajo", {
          Estado: estado,
          FechaInicio: fechaInicio,
          FechaEntrega: fechaEntrega,
          NombreProducto: nombreProducto,
          Medidas: medidas,
          Cantidad: cantidad,
          PrecioUnitario: precioUnitario,
          PrecioTotal: precioTotal,
          NombreCliente: nombreCliente,
          TelefonoCliente: telefonoCliente,
        })
        .then((res) => {
          console.log("Posted");
        });
    }
    function updateEstudiante() {
      axios
        .put(baseUrl + "ordenTrabajo/E-4", {
          Nombres: "Andrea Luisa",
          Apellidos: "Caero Vargas",
        })
        .then((res) => {
          console.log("Updated E-0");
        });
    }
    function deleteEstudiante() {
      axios.delete(baseUrl + "ordenTrabajo/E-2").then((res) => {
        console.log("Delete E-2");
      });
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      await axios
        .post(baseUrl + "ordenTrabajo", {
          Estado: estado,
          FechaInicio: fechaInicio,
          FechaEntrega: fechaEntrega,
          NombreProducto: nombreProducto,
          Medidas: medidas,
          Cantidad: cantidad,
          PrecioUnitario: precioUnitario,
          PrecioTotal: precioTotal,
          NombreCliente: nombreCliente,
          TelefonoCliente: telefonoCliente,
        })
        .then((res) => {
          console.log("Posted", res);
        });
        getOrdenesCompra();
    };
    console.log({ ordenesCompra });
    return (
      <div className="panel">
        <div className="panel__option">
          <form onSubmit={handleSubmit}>
            <div className="row-form">
              <label>Producto: </label>
              <input
                type="text"
                onChange={(e) => setNombreProducto(e.target.value)}
              />
            </div>
            <div className="row-form">
              <label>Medidas: </label>
              <input type="text" onChange={(e) => setMedidas(e.target.value)} />
            </div>
            <div className="row-form">
              <label>Cantidad: </label>
              <input
                type="text"
                onChange={(e) => setCantidad(Number(e.target.value))}
              />
            </div>
            <div className="row-form">
              <label>Precio Unitario: </label>
              <input
                type="text"
                onChange={(e) => setPrecioUnitario(Number(e.target.value))}
              />
            </div>
            <div className="row-form">
              <label>Precio Total: </label>
              <input
                type="text"
                onChange={(e) => setPrecioTotal(Number(e.target.value))}
              />
            </div>
            <div className="row-form">
              <label>Fecha Inicio: </label>
              <input
                type="text"
                onChange={(e) => setFechaInicio(e.target.value)}
              />
            </div>
            <div className="row-form">
              <label>Fecha Entrega: </label>
              <input
                type="text"
                onChange={(e) => setFechaEntrega(e.target.value)}
              />
            </div>
            <div className="row-form">
              <label>Estado: </label>
              <input type="text" onChange={(e) => setEstado(e.target.value)} />
            </div>
            <div className="row-form">
              <label>Cliente: </label>
              <input
                type="text"
                onChange={(e) => setNombreCliente(e.target.value)}
              />
            </div>
            <div className="row-form">
              <label>Telef Contacto: </label>
              <input
                type="text"
                onChange={(e) => setTelefonoCliente(e.target.value)}
              />
            </div>
            <div className="row-form">
              <button className="btn btn-form" type="submit">
                Crear Orden
              </button>
            </div>
          </form>
        </div>
        <div className="panel__option">
          <button className="btn" onClick={getOrdenesCompra}>
            Get Estudiantes
          </button>
          <div>
            <table>
              <thead>
                <tr>
                  <th>ID</th>
                  <th>PRODUCTO</th>
                  <th>MEDIDAS</th>
                  <th>CANTIDAD</th>
                  <th>P. UNITARIO</th>
                  <th>P. TOTAL</th>
                  <th>F. INICIO</th>
                  <th>F. ENTREGA</th>
                  <th>ESTADO</th>
                  <th>CLIENTE</th>
                  <th>T. CONTACTO</th>
                </tr>
              </thead>
              <tbody>
                {ordenesCompra.map((orden, index) => (
                  <tr key={index}>
                    <td>{orden.id}</td>
                    <td>{orden.nombreProducto}</td>
                    <td>{orden.medidas}</td>
                    <td>{orden.cantidad}</td>
                    <td>{orden.precioUnitario}</td>
                    <td>{orden.precioTotal}</td>
                    <td>{orden.fechaInicio}</td>
                    <td>{orden.fechaEntrega}</td>
                    <td>{orden.estado}</td>
                    <td>{orden.nombreCliente}</td>
                    <td>{orden.telefonoCliente}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
        <div className="panel__option">
          <button className="btn" onClick={postEstudiantes}>
            Post Estudiantes
          </button>
        </div>
        <div className="panel__option">
          <button className="btn" onClick={updateEstudiante}>
            Update Estudiante
          </button>
        </div>
        <div className="panel__option">
          <button className="btn" onClick={deleteEstudiante}>
            Delete Estudiante
          </button>
        </div>
      </div>
    );

};
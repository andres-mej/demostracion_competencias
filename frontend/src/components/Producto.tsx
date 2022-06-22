
import React, { useEffect, useState } from "react";
import axios from "axios";

interface IEstudiante {
  id: string;
  nombres: string;
  apellidos: string;
}

export const Producto = () => {
  //(props)

    const [nombres, setNombres] = useState("");
    const [apellidos, setApellidos] = useState("");
    const [estudiantes, setEstudiantes] = useState<IEstudiante[]>([]);

    useEffect(() => {
      getEstudiantes();
    }, []);

    function getEstudiantes() {
      axios.get("https://localhost:5001/api/estudiante").then((res) => {
        setEstudiantes(res.data);
        console.log(res.data);
      });
    }
    function postEstudiantes() {
      axios
        .post("https://localhost:5001/api/estudiante", {
          Nombres: "JUAN",
          Apellidos: "PEREZ",
        })
        .then((res) => {
          console.log("Posted");
        });
    }
    function updateEstudiante() {
      axios
        .put("https://localhost:5001/api/estudiante/E-4", {
          Nombres: "Andrea Luisa",
          Apellidos: "Caero Vargas",
        })
        .then((res) => {
          console.log("Updated E-0");
        });
    }
    function deleteEstudiante() {
      axios.delete("https://localhost:5001/api/estudiante/E-2").then((res) => {
        console.log("Delete E-2");
      });
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      await axios
        .post("https://localhost:5001/api/estudiante", {
          Nombres: nombres,
          Apellidos: apellidos,
        })
        .then((res) => {
          console.log("Posted", res);
        });
    };
    console.log({ estudiantes });
    return (
      <div className="panel">
        <div className="panel__option">
          <form onSubmit={handleSubmit}>
            <div className="row-form">
              <label>Nombres: </label>
              <input type="text" onChange={(e) => setNombres(e.target.value)} />
            </div>
            <div className="row-form">
              <label>Apellidos: </label>
              <input
                type="text"
                onChange={(e) => setApellidos(e.target.value)}
              />
            </div>
            <div className="row-form">
              <button className="btn btn-form" type="submit">
                Crear Estudiante
              </button>
            </div>
          </form>
        </div>
        <div className="panel__option">
          <button className="btn" onClick={getEstudiantes}>
            Get Estudiantes
          </button>
          <div>
            <table>
              <thead>
                <tr>
                  <th>ID</th>
                  <th>NOMBRES</th>
                  <th>APE</th>
                </tr>
              </thead>
              <tbody>
                {estudiantes.map((estudiante, index) => (
                  <tr>
                    <td>{estudiante.id}</td>
                    <td>{estudiante.nombres}</td>
                    <td>{estudiante.apellidos}</td>
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
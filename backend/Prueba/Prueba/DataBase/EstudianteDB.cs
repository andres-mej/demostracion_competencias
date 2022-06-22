using System;
using System.Collections.Generic;
using Prueba.DataBase.Models;
using System.Linq;

namespace Prueba.DataBase
{
    public class EstudianteDB: IEstudianteDB
    {
        private List<Estudiante> Estudiantes { get; set; }

        public EstudianteDB()
        {
            this.Estudiantes = new List<Estudiante> {
            new Estudiante() {
                Id = "E-0",
                Nombres = "Andrea Natalia",
                Apellidos = "Villaroel Caero"
            },
            new Estudiante() {
                Id="E-1",
                Nombres="Miriam Camila",
                Apellidos= "Garcia Maita"
            },
            new Estudiante() {
                Id = "E-2",
                Nombres = "Vincent Alejandro",
                Apellidos = "Valenzuela Coria"
            },
            new Estudiante() {
                Id = "E-3",
                Nombres = "Andres Jorge",
                Apellidos = "Gamboa Baldi"
            },
            new Estudiante() {
                Id = "E-4",
                Nombres = "Vanessa Andrea",
                Apellidos = "Bustillos Najera"
            }
            };    
        }

        Estudiante IEstudianteDB.AddEstudiante(Estudiante newEstudiante)
        {
            this.Estudiantes.Add(newEstudiante);
            return newEstudiante;
        }

        Estudiante IEstudianteDB.DeleteEstudiante(string id)
        {
            Estudiante estudiante = this.Estudiantes.FirstOrDefault(est => est.Id == id);
            if (estudiante != null)
            {
                this.Estudiantes.RemoveAll((est) => est.Id == id);
            }
            return estudiante;
        }

        List<Estudiante> IEstudianteDB.GetAll()
        {
            return this.Estudiantes;
        }

        Estudiante IEstudianteDB.UpdateEstudiante(string id, Estudiante updateEstudiante)
        {
            Estudiante newEstudiante = null;
            foreach(Estudiante estudiante in this.Estudiantes)
            {
                if (estudiante.Id == id)
                {
                    newEstudiante = estudiante;
                    estudiante.Nombres = updateEstudiante.Nombres;
                    estudiante.Apellidos = updateEstudiante.Apellidos;
                }
            }
            return newEstudiante;
        }
    }
}

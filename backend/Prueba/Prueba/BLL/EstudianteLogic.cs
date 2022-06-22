using System;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using Prueba.DataBase;
using System.Collections.Generic;
using System.Linq;
namespace Prueba.BLL
{
    public class EstudianteLogic: IEstudianteLogic
    {

        private readonly IEstudianteDB _estudianteDB;
        public EstudianteLogic(IEstudianteDB estudianteDB)
        {
            this._estudianteDB = estudianteDB;
        }

        public Estudiante AddEstudiante(EstudianteDTO newEstudiante)
        {
            Estudiante estudiante = new Estudiante()
            {
                Id = generateEstudianteId(),
                Nombres = newEstudiante.Nombres,
                Apellidos = newEstudiante.Apellidos
            };

            return _estudianteDB.AddEstudiante(estudiante);
        }

        public Estudiante DeleteEstudiante(string id)
        {
            return _estudianteDB.DeleteEstudiante(id);
        }

        public List<Estudiante> GetAll()
        {
            return _estudianteDB.GetAll();
        }

        public Estudiante UpdateEstudiante(string id, EstudianteDTO updateEstudiante)
        {
            Estudiante estudiante = new Estudiante()
            {
                Nombres = updateEstudiante.Nombres,
                Apellidos = updateEstudiante.Apellidos
            };

            return _estudianteDB.UpdateEstudiante(id, estudiante);
        }

        private string generateEstudianteId()
        {
            if (GetAll().Count > 0)
            {
                Estudiante lastEstudiante = GetAll().Last();
                int id = Convert.ToInt32(lastEstudiante.Id.Split("-")[1]) + 1;
                return "E-" + id;
            } else
            {
                return "E-0";

            }


        }
    }
}

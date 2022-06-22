using System;
using Prueba.ModelsDTO;
using Prueba.DataBase.Models;
using System.Collections.Generic;

namespace Prueba.BLL
{
    public interface IEstudianteLogic
    {
        public Estudiante AddEstudiante(EstudianteDTO newEstudiante);
        public List<Estudiante> GetAll();
        public Estudiante UpdateEstudiante(string id, EstudianteDTO updateEstudiante);
        public Estudiante DeleteEstudiante(string id);
    }
}

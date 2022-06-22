using System;
using Prueba.DataBase.Models;
using System.Collections.Generic;

namespace Prueba.DataBase
{
    public interface IEstudianteDB
    {
        public Estudiante AddEstudiante(Estudiante newEstudiante);
        public List<Estudiante> GetAll();
        public Estudiante UpdateEstudiante(string id, Estudiante updateEstudiante);
        public Estudiante DeleteEstudiante(string id);
    }
}

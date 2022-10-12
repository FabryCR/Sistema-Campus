﻿namespace ProyectoCampus.Entities
{
    public class CursosObj
    {

        public int idCurso { get; set; }
        public string nombre { get; set; } = String.Empty;
        public int creditos { get; set; }
        public string carrera { get; set; } = String.Empty;
        public int idProfesor { get; set; }
        public int cuposDisponibles { get; set; }
        public string horario { get; set; } = String.Empty;

        public string nombreProfesor { get; set; } = string.Empty;
    }
}

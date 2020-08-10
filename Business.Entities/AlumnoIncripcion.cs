﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoIncripcion:BusinessEntity
    {
        private string _condicion;
        private int _idAlumno;
        private int _idCurso;
        private int _nota;

        public string Condicion
        {
            get { return _condicion; }
            set
            {
                _condicion = value;
            }
        }

        public int IdAlumno
        {
            get { return _idAlumno ; }
            set
            {
                _idAlumno = value;
            }
        }

        public int IdCurso
        {
            get { return _idCurso; }
            set
            {
                _idCurso = value;
            }
        }

        public int Nota
        {
            get { return _nota; }
            set
            {
                _nota = value;
            }
        }
    }
}
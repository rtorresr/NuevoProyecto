﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2GravedadProblema_E
    {
        public int idGravedadProblema { get; set; }
        public int descripProblema { get; set; }
        public bool completado { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; }

        //para completat
        public int nro;
         
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UA_AmpliacionCCP_E
    {
        public int idAmpliaciónCCP { get; set; }
        public int idCCP { get; set; }
        public int periodo { get; set; }
        public string nroCCP { get; set; }
        public decimal montoAmpliacion { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //para completar
        public int nro;

    }
}

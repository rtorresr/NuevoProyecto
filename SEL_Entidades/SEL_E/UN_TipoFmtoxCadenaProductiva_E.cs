﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_TipoFmtoxCadenaProductiva_E
    { 
        public int idTipoFrmtoxCadenaProductiva { get; set; }
        public int idTipoFormato { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;

    }
}

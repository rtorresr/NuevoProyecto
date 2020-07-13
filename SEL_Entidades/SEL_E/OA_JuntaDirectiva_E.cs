﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_JuntaDirectiva_E
    {
        public int idJuntaDirectiva { get; set; }
        public int idOA { get; set; }
        public string fechaRegistroSunarp { get; set; }
        public string fechaRegistroSel { get; set; }
        public string periodoDuracion { get; set; }
        public string fechInicio { get; set; }
        public string fechFin { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string rucOA;
        public string razSocialOA;
        public string nombUsuarioReg;
        public string nombUsuarioMod;


    }
}

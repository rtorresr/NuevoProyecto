using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2CondicionesLocales_E
    { 
        public int idCondicionesLocales { get; set; } 
        public int idCultivoCrianza { get; set; }
        public int idOA { get; set; }
        public string terrenoLocalPropio { get; set; }
        public int idTipoDocumentoAcred { get; set; }
        public string descDocumentoAcred { get; set; }
        public string especificacionOtroServBasico { get; set; }
        public string especificacionOtroViaAccesoPlantaProc { get; set; }
        public string especificacionOtroViaAccesoZonaProd { get; set; }
        public bool presentaMaquinariaProduccion { get; set; }
        public string descripMaquinariaProduccion { get; set; }
        public int tiempoMaxTraslado { get; set; }
        public int idUnidadMedidaMax { get; set; }
        public int tiempoMinTraslado { get; set; }
        public int idUnidadMedidaMin { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idusuariomodificacion { get; set; }
        public string fechamodificacion { get; set; }

        //Para completar
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
        public string rucOA;
        public int idTipoUnidMedMax;
        public int idTipoUnidMedMin;

    }
}

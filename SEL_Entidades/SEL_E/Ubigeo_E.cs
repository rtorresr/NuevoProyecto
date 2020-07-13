using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Ubigeo_E
    {
        public int id_Ubigeo { get; set; }
        public string codigoUbigeo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }

        //PARA COMPLETAR
        public string cod_departamento;
        public string cod_provincia;
        public string cod_distrito;

    }
}

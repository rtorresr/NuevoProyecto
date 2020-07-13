using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class CoordenadasUTM_E
    {
        public int idCoordenadasUTM { get; set; }
        public int idOA { get; set; }
        public int idSocio { get; set; }
        public int valorVertiiceX1 { get; set; }
        public int valorVerticeY1 { get; set; }
        public int valorVerticeX2 { get; set; }
        public int valorVerticeY2 { get; set; }
        public int valorVerticeX3 { get; set; }
        public int valorVerticeY3 { get; set; }
        public int valorVerticeX4 { get; set; }
        public int valorVerticeY4 { get; set; }
        public int valorVerticeX5 { get; set; }
        public int valorVerticeY5 { get; set; }
        public int valorVerticeX6 { get; set; }
        public int valorVerticeY6 { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string razSocialOA;
        public string nombSocio;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
         
    }
}

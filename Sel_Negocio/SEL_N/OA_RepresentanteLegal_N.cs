using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_RepresentanteLegal_N
    {

        OA_RepresentanteLegal_D oaRepLegal_D = new OA_RepresentanteLegal_D();

        public string agregar(OA_RepresentanteLegal_E objOARepLeg)
        {
            return oaRepLegal_D.agregar(objOARepLeg);
        }

        public string modificar(OA_RepresentanteLegal_E objOARepLeg)
        {
            return oaRepLegal_D.modificar(objOARepLeg);
        }

        public string eliminar(OA_RepresentanteLegal_E objOARepLeg)
        {
            return oaRepLegal_D.eliminar(objOARepLeg);
        }

        public OA_RepresentanteLegal_E obtenerRepresentanteLegal(int idOA, string rucOA)
        {
            return oaRepLegal_D.obtenerRepresentanteLegal(idOA, rucOA);
        }

        public bool validarRegistro(int idOA, int idCargo, string dniRep, string email, string fechNacim, string estaCiv, string dniCony, string telf1, string anexoRep, string telf2)
        {
            return oaRepLegal_D.validarRegistro(idOA, idCargo, dniRep, email, fechNacim, estaCiv, dniCony, telf1, anexoRep, telf2);
        }
         
    }
}

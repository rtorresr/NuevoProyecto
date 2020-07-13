using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_Contacto_N
    {
        OA_Contacto_D oaContacto_D = new OA_Contacto_D();

        public string agregar(OA_Contacto_E objOAContacto)
        {
            return oaContacto_D.agregar(objOAContacto);
        }
        public string modificar(OA_Contacto_E objOAContacto)
        {
            return oaContacto_D.modificar(objOAContacto);
        }

        public string eliminar(OA_Contacto_E objOAContacto)
        {
            return oaContacto_D.eliminar(objOAContacto);
        }

        public OA_Contacto_E obtenerContacto(int idOA, string rucOA)
        {
            return oaContacto_D.obtenerContacto(idOA, rucOA);
        }


        public bool validarRegistroContacto(int idOA, int idCargo, string dniCont, string nombre, string apelPaterno, string apelMaterno, string fechaNacim, string emailCont, string estaCiv, string dniCony, string nTelf1, string nTelf2)
        {
            return oaContacto_D.validarRegistroContacto(idOA, idCargo, dniCont, nombre, apelPaterno, apelMaterno, fechaNacim, emailCont, estaCiv, dniCony, nTelf1, nTelf2);
        }
         
    }
}

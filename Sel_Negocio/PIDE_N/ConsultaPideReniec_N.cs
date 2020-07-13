using SEL_Datos.PIDE_D;
using SEL_Entidades.PIDE_E;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.PIDE_N
{
    public class ConsultaPideReniec_N
    {

        ConsultaPideReniec_D consPideReniec_D = new ConsultaPideReniec_D();
 

        public datosReniec_E consultaReniecPide(string nroDniCon, string nroDniUsua, string nroRucEnt, string pwdUsua)
        {
            datosReniec_E  resultadosDR = new datosReniec_E();
             
            try
            {
                resultadosDR = consPideReniec_D.ConsultaReniecPide(nroDniCon, nroDniUsua, nroRucEnt, pwdUsua);
            }
            catch(FormatException fx)
            {
                Debug.WriteLine("Capa-Negocio-Error al consultar a Reniec: " + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            return resultadosDR;
        }


        public _filtrarReniecResp_E ConsultaReniecPideS(_filtrarReniecReq_E objrequest)
        {

            _filtrarReniecResp_E objResponse = new _filtrarReniecResp_E()
            {
                datosReniec = consPideReniec_D.ConsultaReniecPide(objrequest.nroDniCon, objrequest.nroDniUsua, objrequest.nroRucEnt, objrequest.pwdUsua)
            };
            return objResponse;
        }



    }
}

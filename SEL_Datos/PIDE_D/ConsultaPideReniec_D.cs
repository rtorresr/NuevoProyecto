using SEL_Entidades.PIDE_E;
using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace SEL_Datos.PIDE_D
{
    public class ConsultaPideReniec_D
    { 

           Utilitarios.utilitario ut = new Utilitarios.utilitario();

        public datosReniec_E ConsultaReniecPide(string nroDniCon, string nroDniUsua, string nroRucEnt, string pwdUsua)
        {
            datosReniec_E datoreniec_E = new datosReniec_E();
             
            try
            {
                  
                XDocument xdoc = XDocument.Load("https://ws5.pide.gob.pe/Rest/Reniec/Consultar?nuDniConsulta=" + nroDniCon + "&nuDniUsuario=" + nroDniUsua + "&nuRucUsuario=" + nroRucEnt + "&password=" + pwdUsua);

                var personas = from per in xdoc.Descendants("datosPersona") select per;

                foreach (XElement elem in personas)
                {
                    datoreniec_E.apPrimer = Convert.ToString(elem.Element("apPrimer").Value);
                    datoreniec_E.apSegundo = Convert.ToString(elem.Element("apSegundo").Value);
                    datoreniec_E.prenombres = Convert.ToString(elem.Element("prenombres").Value);
                    datoreniec_E.estadoCivil = Convert.ToString(elem.Element("estadoCivil").Value);
                    datoreniec_E.foto = Convert.ToString(elem.Element("foto").Value);
                    datoreniec_E.ubigeo = Convert.ToString(elem.Element("ubigeo").Value);
                    datoreniec_E.direccion = Convert.ToString(elem.Element("direccion").Value);
                    datoreniec_E.restriccion = Convert.ToString(elem.Element("restriccion").Value);
                }


            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener información general de Reniec: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }


            return datoreniec_E;
        }
         
    }
}

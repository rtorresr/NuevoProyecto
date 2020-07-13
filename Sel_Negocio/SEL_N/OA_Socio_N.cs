using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_Socio_N
    {
        OA_Socio_D oaSocico_D = new OA_Socio_D();


        public string agregar(OA_Socio_E objSocio)
        {
            return oaSocico_D.agregar(objSocio);
        }

        public string modificar(OA_Socio_E objSocio)
        {
            return oaSocico_D.modificar(objSocio);
        }

        public string eliminar(OA_Socio_E objSocio)
        {
            return oaSocico_D.eliminar(objSocio);
        }

        public string eliminarSocio(OA_Socio_E objSocio)
        {
            return oaSocico_D.eliminarSocio(objSocio);
        }

        

        public OA_Socio_E obtenerIdSocioOA(int idSocio)
        {
            return oaSocico_D.obtenerIdSocioOA(idSocio);
        }


        public OA_Socio_E obtenerSocioOA(int idSocio)
        {
            return oaSocico_D.obtenerSocioOA(idSocio);
        }

        public List<OA_Socio_E> listarSocio_OA(int idOADatos, string rucOA, string dniSocio, string nombSocio, string nroExpediente)
        {
            return oaSocico_D.listarSocio_OA(idOADatos, rucOA, dniSocio, nombSocio, nroExpediente);
        }

        //   public List<OA_Socio_E> obtenerCargoSocio()
        public OA_Socio_E obtenerCargoSocio()
        {
            return oaSocico_D.obtenerCargoSocio();
        }

        public string obtenerActividadEconomica(int idOADatos)
        {
            return oaSocico_D.obtenerActividadEconomica(idOADatos);
        }
        
        public string obtenerProductoPrincipal(int idOADatos)
        {
            return oaSocico_D.obtenerProductoPrincipal(idOADatos);
        }
          
        public string validarExistenciaSocioOA(string dniSocio)
        {
            return oaSocico_D.validarExistenciaSocioOA(dniSocio);
        }

        public bool validarRegistroSocio(OA_Socio_E objSocio)
        {
            return oaSocico_D.validarRegistroSocio(objSocio);
        }

        public OA_Datos_E obtenerID_OA_OADATOS(string rucOA)
        {
            return oaSocico_D.obtenerID_OA_OADATOS(rucOA);
        }

        public OA_Socio_E obtenerSocioxDni(int idOADatos, string dni)
        {
            return oaSocico_D.obtenerSocioxDni(idOADatos, dni);
        }

        public OA_Socio_E verificarDniConyuge(string dni)
        {
            return oaSocico_D.verificarDniConyuge(dni);
        }

        public OA_Socio_E validacionPadronSocios(int idOADatos, string rucOA, string nroExpediente)
        {
            return oaSocico_D.validacionPadronSocios(idOADatos, rucOA, nroExpediente);
        }
         
      
         
   }
}

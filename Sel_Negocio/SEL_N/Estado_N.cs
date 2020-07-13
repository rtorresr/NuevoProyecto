using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Estado_N
    {
        Estado_D estado_D = new Estado_D();
        public List<Estado_E> listarEstado(int idUnidadPcc,  string proceso, string tipoIncentivo)
        {
            return estado_D.listarEstado(idUnidadPcc, proceso, tipoIncentivo);
        }

        public List<Estado_E> listarEstadoxPerfil(int idUnidadPcc, string perfilUsuario, string proceso, string tipoIncentivo)
        {
            return estado_D.listarEstadoxPerfil(idUnidadPcc, perfilUsuario, proceso, tipoIncentivo);
        }

        public List<Estado_E> listaEstadoAct(int idUnidadPcc, string perfilUsuario, string proceso, string tipoIncentivo)
        {
            return estado_D.listaEstadoAct(idUnidadPcc, perfilUsuario, proceso, tipoIncentivo);
        }

		//PAQS
 		//LISTADO UP
        public List<Estado_E> listaEstadoUP()
        {
            return estado_D.listaEstadoUP();
        }


    }
}

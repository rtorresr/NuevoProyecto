using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Prorroga_N
    {

        Prorroga_D Pror_D = new Prorroga_D();

        public string agregarProrroga(Prorroga_E objProrroga)
        {
            return Pror_D.agregarProrroga(objProrroga);

        }

        public string modificarProrroga(Prorroga_E objProrroga)
        {
            return Pror_D.modificarProrroga(objProrroga);

        }

        public string eliminarProrroga(Prorroga_E objProrroga)
        {
            return Pror_D.eliminarProrroga(objProrroga);

        }

        public List<Prorroga_E> listarProrroga(string descripProrroga)
        {
            return Pror_D.listarProrroga(descripProrroga);

        }

        public Prorroga_E obtenerProrroga(int idProrroga)
        {
            return Pror_D.obtenerProrroga(idProrroga);
        }


        public bool validarProrroga(string descripProrroga)
        {
            return Pror_D.validarProrroga(descripProrroga);
        }



    }
}

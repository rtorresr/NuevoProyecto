using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UP_FuncionOperativa_N
    {

        UP_FuncionOperativa_D funcOperativa_D = new UP_FuncionOperativa_D();

        public string agregar(UP_FuncionOperativa_E objfunOpe)
        {
            return funcOperativa_D.agregar(objfunOpe);
        }

        public UP_FuncionOperativa_E obteneridFO(int id)
        {
            return funcOperativa_D.obteneridFO(id);
        }

        public string modificarFunOpe(UP_FuncionOperativa_E objFO)
        {
            return funcOperativa_D.modificarFunOpe(objFO);
        }

        public string eliminarFO(UP_FuncionOperativa_E objFO)
        {
            return funcOperativa_D.eliminarFO(objFO);
        }

        public List<UP_FuncionOperativa_E> listarFO()
        {
            return funcOperativa_D.listarFO();
        }

        public bool validarFuncionOperativa(string descripFuncion)
        {
            return funcOperativa_D.validarFuncionOperativa(descripFuncion);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos
{
    public class ConexionDB
    {
        //Singleton
        //private static ConexionDB conex = null; 


        //private SqlConnection conRH = new SqlConnection("Data Source=.;Initial Catalog=BD_RRHH;Integrated Security=true");
        //private SqlConnection conS = new SqlConnection("Data Source=.;Initial Catalog=BD_SEGURIDAD;Integrated Security=true");
        //private SqlConnection conSel = new SqlConnection("Data Source=.;Initial Catalog=BD_PCCSEL; Integrated Security=true");

        //BD-PC-Local-Agroideas
        //private SqlConnection conRH = new SqlConnection("Data Source=.;Initial Catalog=BD_RRHH; uid= sa; pwd=adminsql;");
        //private SqlConnection conS = new SqlConnection("Data Source=.;Initial Catalog=BD_SEGURIDAD; uid= sa; pwd=adminsql;");
        //private SqlConnection conSel = new SqlConnection("Data Source=.;Initial Catalog=BD_PCCSEL; uid= sa; pwd=adminsql;");

        //BD-PC-SVDesarrollo       
        private SqlConnection conRH = new SqlConnection("Data Source=.;Initial Catalog=BD_RRHH; uid= sa; pwd=@groideas-2018;");
        private SqlConnection conS = new SqlConnection("Data Source=.;Initial Catalog=BD_SEGURIDAD; uid= sa; pwd=@groideas-2018;");
        private SqlConnection conSel = new SqlConnection("Data Source=.;Initial Catalog=BD_PCCSEL; uid=sa; pwd=123456;");

        //BD-PC-Laptop
        //private SqlConnection conRH = new SqlConnection("Data Source=.;Initial Catalog=BD_RRHH; uid= sa; pwd=sql;");
        //private SqlConnection conS = new SqlConnection("Data Source=.;Initial Catalog=BD_SEGURIDAD; uid= sa; pwd=sql;");
        //private SqlConnection conSel = new SqlConnection("Data Source=.;Initial Catalog=BD_PCCSEL; uid= sa; pwd=sql;");

        //BD-PC-SERVIDOR-PRUEBA       
        //private SqlConnection conRH = new SqlConnection("Data Source=.;Initial Catalog=BD_RRHH; uid= sa; pwd=Agr43d21s12345;");
        //private SqlConnection conS = new SqlConnection("Data Source=.;Initial Catalog=BD_SEGURIDAD; uid= sa; pwd=Agr43d21s12345;");
        //private SqlConnection conSel = new SqlConnection("Data Source=.;Initial Catalog=BD_PCCSEL; uid= sa; pwd=Agr43d21s12345;");




        public SqlConnection CONSel
        {
            get
            {
                return conSel;
            }
        }
          
        public SqlConnection CONRH
        {
            get
            {
                return conRH;
            }
        }

        public SqlConnection CONS
        {
            get
            {
                return conS;
            }
        }
           
    }
}

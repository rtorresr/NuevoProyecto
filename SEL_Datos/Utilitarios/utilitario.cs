using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO; 
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SEL_Datos.Utilitarios
{
    public class utilitario
    {

        public void logsave(object obj, Exception ex)
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string path = "C://LogSel//logs//IDG//IDG_D.Txt"; 
            //string path = "~//LogSel//logs//IDG//IDG_D.Txt";
            //string path = @"~\LogSel\logs\IDG\IDG_D.Txt";
           
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(path, true);

                StackTrace stacktrace = new StackTrace();
                sw.WriteLine(obj.GetType().FullName + " " + fecha + " " + hora);
                sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
                sw.WriteLine("");
                sw.Flush();
            }
            catch(UnauthorizedAccessException uaaex)
            {
                FileAttributes attr = (new FileInfo(path)).Attributes;
                Debug.WriteLine("Error - No se puede acceder al archivo. " + uaaex.Message.ToString() + uaaex.StackTrace.ToString());
                if((attr & FileAttributes.ReadOnly) > 0)
                {
                    Debug.WriteLine("Este archivo es de solo lectura.");
                }

            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }

            }
                 
        }
         
        public string obtener_Fecha()
        {
            string fecActual = "";
            DateTime fechaActual = DateTime.Now;
            fecActual = fechaActual.ToString();
            return fecActual;
        }
          
        
    }
}
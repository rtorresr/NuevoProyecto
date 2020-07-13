using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPA.Web.ViewModel
{
    public class DataTableRequest
    {
        /// <summary>
        /// Numero de petición que se está realizando.
        /// </summary>
        public int draw { get; set; }
        /// <summary>
        /// Diccionario con la información de por medio de campo se va a realizar el ordenamiento.
        /// </summary>
        public Dictionary<string, string>[] order { get; set; }
        /// <summary>
        /// registró a partir de cual se va a iniciar el paginado.
        /// </summary>
        public int start { get; set; }
        /// <summary>
        /// Tamaño de la pagina
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// Valor de la búsqueda
        /// </summary>
        public Dictionary<string, string> search { get; set; }

    }
}
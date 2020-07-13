namespace SEL_Entidades.SEL_E
{
    public class UP_Proceso_E
    { 
        public int idProceso { get; set; }
        public string descripProceso { get; set; }
        public int idUnidadPcc { get; set; }
        public int idTipoSDA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }


        //Para completar
        public int nro;
        public string tipoSda;
        public string unidadPcc;
        public string nombUsuaReg;
        public string nombUsuaMod;

    }
}

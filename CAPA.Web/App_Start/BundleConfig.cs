using System.Web;
using System.Web.Optimization;

namespace CAPA.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery-1.10.2.min.js",
                         "~/Scripts/jquery-1.11.3.min.js",
                         "~/Scripts/jquery-3.4.1.min.js",
                         "~/Scripts/jquery.dataTables.js"
                       // "~/Scripts/jquery.forms.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquerySel").Include(

                        //JS DEL PIDE:
                        "~/Scripts/PIDE/js_ConsultaPideReniec.js",
                        "~/Scripts/PIDE/js_ConsultaPideSunat.js",

                        //JS DEL SEL:
                        
                        "~/Scripts/SEL/cargarSelectOpt_SEL.js",
                        "~/Scripts/SEL/eventosRegOA.js",
                        "~/Scripts/SEL/js_ActualizarEstadoExp.js",
                        "~/Scripts/SEL/js_BienServicios.js",
                        "~/Scripts/SEL/js_CadenaProductiva.js",
                        "~/Scripts/SEL/js_CargaLaboralEspecialista.js", 
                        "~/Scripts/SEL/js_Categoria.js", 
                        "~/Scripts/SEL/js_Estados.js",
                        "~/Scripts/SEL/js_ModuloHome.js",
                        "~/Scripts/SEL/js_Periodo.js",
                        "~/Scripts/SEL/js_Producto.js",
                        "~/Scripts/SEL/js_Prorroga.js",
                        "~/Scripts/SEL/js_SubCategoria.js",
                        "~/Scripts/SEL/js_TipoUnidMedida.js",
                        "~/Scripts/SEL/js_Ubigeo.js",
                        "~/Scripts/SEL/js_UnidadMedida.js", 
                        "~/Scripts/SEL/js_UnidadPcc.js",
                        "~/Scripts/SEL/js_UnidMedidaEstandar.js",
                        "~/Scripts/SEL/js_Val_UsuarioOA.js",
                        "~/Scripts/SEL/js_UsuarioPide.js", 
                        "~/Scripts/js_ValidarEstadoTrazabilidadOA.js",
                         

                        //SEL - OA 
                        "~/Scripts/SEL/OA/js_OA.js",
                        "~/Scripts/SEL/OA/js_OA_Contacto.js",
                        "~/Scripts/SEL/OA/js_OA_Datos.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_AlternativasSolucion.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_BienesServicios.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_CausasdelProblemaEsp.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_Cofinanciamiento.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_CondicionesLocales.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_CultivoCrianza.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_IdeaNegocio.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_ParticipacionCadVal.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_ProblemasEspecificos.js",
                        "~/Scripts/SEL/OA/js_OA_Fmto2_QuienesSomos.js",
                        "~/Scripts/SEL/OA/js_OA_JuntaDirectiva.js",
                        "~/Scripts/SEL/OA/js_OA_MiembroJD.js",
                        "~/Scripts/SEL/OA/js_OA_PreRegistro.js",
                        "~/Scripts/SEL/OA/js_OA_RepresentanteLegal.js", 
                        "~/Scripts/SEL/OA/js_OA_Socio.js",
                        "~/Scripts/SEL/OA/js_OA_ReporteOAFmto1.js",
                         "~/Scripts/SEL/OA/js_OA_ReporteOAFmto2.js",
                         "~/Scripts/SEL/OA/js_OA_ReporteOAFmto3.js",

                        //SEL - MP 
                        "~/Scripts/SEL/MP/js_MP_OARegistradas.js",
                        "~/Scripts/SEL/MP/js_MP_ExpedienteOA.js",
                        "~/Scripts/SEL/MP/js_MP_Cut_ExpedienteOA.js",
                        "~/Scripts/SEL/MP/js_MP_DocumentoAnexoOA.js",

                        //SEL - UP-c
                        "~/Scripts/SEL/UP-C/js_EstadoExpedientes.js",
                        "~/Scripts/SEL/UP-C/js_UP_EvalPrimerInforme.js",
                        "~/Scripts/SEL/UP-C/js_UP_EvalSegundoInforme.js",
                        "~/Scripts/SEL/UP-C/js_UP_ExpedientesRecepcionados.js",
                        "~/Scripts/SEL/UP-C/js_UP_RegistrarInformes.js",
                        "~/Scripts/SEL/UP-C/js_UP_tareaEjecutada.js",
                        "~/Scripts/SEL/UP-C/js_UP_AsignarEspecialistas.js",
                        "~/Scripts/SEL/UP-C/js_UP_ReasignarEspecialista.js",
                        "~/Scripts/SEL/UP-C/js_UP_ExpedientesAsignados.js",
                        "~/Scripts/SEL/UP-C/js_UP_TipoCompromiso.js",
                        "~/Scripts/SEL/UP-C/js_UP_Compromiso.js",
                        "~/Scripts/SEL/UP-C/js_UP_PadronSocios.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_Asignados.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_RepresentanteLegal.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_Contacto.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_Datos.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_PadronSocios.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_JuntaDirectiva.js",
                        "~/Scripts/SEL/UP-C/js_UP_OA_MiembroJD.js",
                        "~/Scripts/SEL/UP-C/js_UP_DocumentosAdjuntosOA.js",
                        "~/Scripts/SEL/UP-C/js_UP_Notificacion.js",
                        "~/Scripts/SEL/UP-C/js_UP_DarBajaOrganizacion.js",
                        "~/Scripts/SEL/UP-C/js_UP_ActualizaFormatoOA.js",
                        "~/Scripts/SEL/UP-C/js_UP_Confirma_BajaOA.js",
                        "~/Scripts/SEL/UP-C/js_UP_Estado_Asignado_Exp.js",

                        //SEL - UP-PRP
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_ComponenteInversion.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_ExpedienteAsignadoPRP.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_PadronSocios.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_OA.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_JuntaDirectiva.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_Evaluacion.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_consultaExpediente_OA.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_ObjGenerales.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_ObjEspecificos.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_DocumentoFormatoOA.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_DocumentoFichaOA_Socio.js",
                        "~/Scripts/SEL/UP-PRP/js_UP_PRP_EvaluacionDocumentaria.js",
                         "~/Scripts/SEL/UP-PRP/js_UP_PRP_OA_MiembroJD.js",


                        //SEL - UN
                        "~/Scripts/SEL/UN/js_UN_RecepcionSDA.js",
                        "~/Scripts/SEL/UN/js_UN_CbxCargaDatos.js",
                         

                        //---------------------------------//
                        //JS DE RRHH:
                        "~/Scripts/RRHH/cargarSelectOpt_UA.js",
                        "~/Scripts/RRHH/js_Sede.js",
                        "~/Scripts/RRHH/js_Trabajador.js",
                        "~/Scripts/RRHH/js_FamTrabajador.js",
                        "~/Scripts/RRHH/js_Cargo.js",
                        "~/Scripts/RRHH/js_TipoCargo.js",
                        "~/Scripts/RRHH/js_TipoDocumento.js",
                        "~/Scripts/RRHH/js_Area.js",
                        "~/Scripts/RRHH/js_AsignarCargo.js",
                        "~/Scripts/RRHH/js_TipoContrato.js",
                        "~/Scripts/RRHH/js_Contrato.js",
                        "~/Scripts/RRHH/js_LazoFamiliar.js",

                        //JS DE SEGURIDAD:
                        "~/Scripts/SEGURIDAD/cargarSelectOpt_UASis.js", 
                        "~/Scripts/SEGURIDAD/js_Inicio.js",
                        "~/Scripts/SEGURIDAD/js_Aplicacion.js",
                        "~/Scripts/SEGURIDAD/js_Modulos.js",
                        "~/Scripts/SEGURIDAD/js_MenuModulos.js",
                        "~/Scripts/SEGURIDAD/js_PermisosModulo.js",
                        "~/Scripts/SEGURIDAD/js_UsuarioPCC.js",
                         "~/Scripts/SEGURIDAD/js_UsuarioOA.js",
                        "~/Scripts/SEGURIDAD/js_TipoUsuario.js",
                        "~/Scripts/SEGURIDAD/js_Perfiles.js",
                        "~/Scripts/SEGURIDAD/js_UsuarAplicacion.js",
                        "~/Scripts/SEGURIDAD/js_ModuloPerfil.js",
                        "~/Scripts/SEGURIDAD/js_OpcionPerfil.js",
                        "~/Scripts/SEGURIDAD/js_MenuPerfil.js",
                        "~/Scripts/SEGURIDAD/js_AsignarPerfil.js",

                        //JS OTROS:
                        // "~/Scripts/printThis.js",
                        "~/Scripts/validacionCampos.js"

                        //"~/Scripts/bloqueoVistaCodigo.js"

                        ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(

                        "~/Scripts/jquery.validate",
                        "~/Scripts/jquery.validate.min.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/modernizr-2.6.2.js",
                      "~/Scripts/ace.min.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/select2.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/dataTables.css",
                      "~/Content/style.css",
                      "~/Content/style.css",
                      "~/Content/dist/css/skins/_all-skins.min.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                      "~/Content/font-awesome.min.css"));


            bundles.Add(new StyleBundle("~/Content/error").Include(
                      "~/Content/Error.css"));

            bundles.Add(new StyleBundle("~/Content/Comun").Include("~/Content/formularios/Comun.css"));

            // Para la depuración, establezca EnableOptimizations en false. Para obtener más información,
            // visite http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}

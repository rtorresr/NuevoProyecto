using System.ServiceModel; 
using SEL_Entidades.RRHH_E.filtros;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IBuscarxDniServ" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IBuscarxDniServ
    {
        [OperationContract]
        _buscarTrabajadorxDniResp trabajador(_buscarTrabajadorxDniReq objRequest);
    }
}

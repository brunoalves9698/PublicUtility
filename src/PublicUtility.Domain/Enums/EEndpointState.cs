using System.ComponentModel;

namespace PublicUtility.Domain.Enums
{
    public enum EEndpointState
    {
        [Description("Desconectado")]
        Disconnected = 0,

        [Description("Conectado")]
        Connected = 1,

        [Description("Armado")]
        Armed = 2,
    }
}

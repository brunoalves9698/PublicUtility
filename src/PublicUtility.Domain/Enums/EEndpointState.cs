using System.ComponentModel;

namespace PublicUtility.Domain.Enums
{
    public enum EEndpointState
    {
        [Description("Disconectado")]
        Disconnected = 0,

        [Description("Conectado")]
        Connected = 1,

        [Description("Armado")]
        Armed = 2,
    }
}

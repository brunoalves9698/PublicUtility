using Flunt.Notifications;
using Flunt.Validations;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Enums;

namespace PublicUtility.Domain.Commands.Inputs
{
    public class RegisterEndpointCommand : Notifiable, ICommand
    {
        public RegisterEndpointCommand() { }

        public RegisterEndpointCommand(
            string serialNumber,
            int meterModelId,
            int meterNumber,
            string meterFirmwareVersion,
            EEndpointState switchState)
        {
            SerialNumber = serialNumber;
            MeterModelId = meterModelId;
            MeterNumber = meterNumber;
            MeterFirmwareVersion = meterFirmwareVersion;
            SwitchState = switchState;
        }

        public string SerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public EEndpointState SwitchState { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(SerialNumber, "SerialNumber", "O campo \"Número de Série\" é obrigatório.")
                .HasMaxLen(MeterFirmwareVersion, 20, "MeterFirmwareVersion", "O campo \"Versão do Firmware\" deve conter no máximo 100 caracteres."));
        }
    }
}

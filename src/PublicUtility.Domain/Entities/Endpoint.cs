using PublicUtility.Domain.Entities.Core;
using PublicUtility.Domain.Enums;

namespace PublicUtility.Domain.Entities
{
    public class Endpoint : Entity
    {
        public Endpoint(
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

        public string SerialNumber { get; private set; }
        public int MeterModelId { get; private set; }
        public int MeterNumber { get; private set; }
        public string MeterFirmwareVersion { get; private set; }
        public EEndpointState SwitchState { get; private set; }

        public void Update(EEndpointState switchState)
        {
            SwitchState = switchState;
        }

        public void Disconnect()
        {
            SwitchState = EEndpointState.Disconnected;
        }

        public void Connect()
        {
            SwitchState = EEndpointState.Connected;
        }

        public void Arm()
        {
            SwitchState = EEndpointState.Armed;
        }

        public override string ToString()
        {
            return SerialNumber;
        }
    }
}

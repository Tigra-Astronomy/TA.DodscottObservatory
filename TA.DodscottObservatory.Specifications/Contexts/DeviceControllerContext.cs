using TA.Ascom.ReactiveCommunications;
using TA.DodscottObservatory.DeviceLayer;

namespace TA.DodscottObservatory.Specifications.Contexts
{
    class DeviceControllerContext
    {
    public ITransactionProcessor TransactionProcessor { get; set; }
    public ICommunicationChannel Channel { get; set; }

    public ControllerActions Actions { get; set; }
    }
}

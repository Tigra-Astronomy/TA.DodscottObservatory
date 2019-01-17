using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;

namespace TA.DodscottObservatory.Specifications.Contexts {
    class StateMachineContext
        {
        public IControllerActions Actions { get; set; }
        public ControllerStateMachine Machine { get; set; }

        public HardwareStatus HardwareStatus { get; set; }
        }
    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
{
    public static class ControllerStateMachineExtensions
    {
        public static void StartInReadyState(this ControllerStateMachine machine)
        {
            machine.Initialize(new ReadyState(machine));
        }
    }
}

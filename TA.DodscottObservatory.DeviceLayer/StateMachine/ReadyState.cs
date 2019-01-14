using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
{
    class ReadyState : ControllerStateBase, IControllerState
    {
    /// <inheritdoc />
    public ReadyState(ControllerStateMachine machine) : base(machine) { }

    /// <inheritdoc />
    public override void OpenShutter()
        {
        ResetTimeout(TimeSpan.FromMinutes(5));
        machine.ControllerActions.OpenShutter();
        var nextState = new ShutterMovingState(machine);
        machine.TransitionToState(nextState);
        }
    }

    internal class ShutterMovingState : ControllerStateBase, IControllerState
        {
        /// <inheritdoc />
        public ShutterMovingState(ControllerStateMachine machine) : base(machine) { }

        /// <inheritdoc />
        public override void OnEnter()
            {
            // ToDo - kick off a task to monitor the progress
            // ToDo - report the shutter state as "opening"
            ResetTimeout(TimeSpan.FromMinutes(5));  // ToDo: factor out into settings
            base.OnEnter();
            }

        /// <inheritdoc />
        protected override void HandleTimeout()
            {
            var nextState = new ReadyState(machine);
            machine.TransitionToState(nextState);
            }
        }
    }

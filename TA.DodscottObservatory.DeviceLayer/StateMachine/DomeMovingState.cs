using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog.Fluent;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
{
    class DomeMovingState : ControllerStateBase
    {
    private Task monitoringTask;

    /// <inheritdoc />
    public DomeMovingState(ControllerStateMachine machine) : base(machine) { }

    /// <inheritdoc />
    public override void OnEnter()
        {
        // ToDo - report the shutter state as "opening"
        ResetTimeout(TimeSpan.FromMinutes(5)); // ToDo: factor out into settings
        monitoringTask = StartMonitoringDomeMovement(timeoutCancellation.Token);
        base.OnEnter();
        }

    private async Task StartMonitoringDomeMovement(CancellationToken cancel)
        {
        while (!cancel.IsCancellationRequested)
            {
            try
                {
                machine.HardwareStatus.DomeState = machine.ControllerActions.GetDomeState();
                machine.HardwareStatus.DomeAzimuth = machine.ControllerActions.GetDomePosition();
                }
            catch (TransactionException e)
                {
                Log.Error().Exception(e).Message($"MonitorDomeMovement: {e.Message}").Write();
                }
            if (!IsDomeMoving())
                machine.TransitionToState(new ReadyState(machine));
            await Task.Delay(TimeSpan.FromSeconds(1), cancel);
            }
        }

    private bool IsDomeMoving()
        {
        return false;
        }
    }
}

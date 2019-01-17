// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: ShutterMovingState.cs  Last modified: 2019-01-17@03:45 by Tim Long

using System;
using System.Threading;
using System.Threading.Tasks;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    internal class ShutterMovingState : ControllerStateBase, IControllerState
        {
        /// <inheritdoc />
        public ShutterMovingState(ControllerStateMachine machine) : base(machine) { }

        /// <inheritdoc />
        public override void OnEnter()
            {
            // ToDo - kick off a task to monitor the progress
            // ToDo - report the shutter state as "opening"
            ResetTimeout(TimeSpan.FromMinutes(5)); // ToDo: factor out into settings
            StartMonitoringShutterMovement(timeoutCancellation.Token);
            base.OnEnter();
            }

        private async void StartMonitoringShutterMovement(CancellationToken cancel)
            {
            while (!cancel.IsCancellationRequested)
                {
                machine.HardwareStatus.ShutterState = machine.ControllerActions.QueryShutterState();
                machine.HardwareStatus.ShutterPosition= machine.ControllerActions.QueryShutterPosition();
                await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }

        /// <inheritdoc />
        protected override void HandleTimeout()
            {
            var nextState = new ReadyState(machine);
            machine.TransitionToState(nextState);
            }
        }
    }
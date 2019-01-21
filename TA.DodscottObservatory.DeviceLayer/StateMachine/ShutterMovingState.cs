// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: ShutterMovingState.cs  Last modified: 2019-01-17@03:45 by Tim Long

using System;
using System.Threading;
using System.Threading.Tasks;
using NLog.Fluent;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    internal class ShutterMovingState : ControllerStateBase, IControllerState
        {
        private Task monitoringTask;

        /// <inheritdoc />
        public ShutterMovingState(ControllerStateMachine machine) : base(machine) { }

        /// <inheritdoc />
        public override void OnEnter()
            {
            // ToDo - kick off a task to monitor the progress
            // ToDo - report the shutter state as "opening"
            ResetTimeout(TimeSpan.FromMinutes(5)); // ToDo: factor out into settings
            monitoringTask = StartMonitoringShutterMovement(timeoutCancellation.Token);
            base.OnEnter();
            }

        private async Task StartMonitoringShutterMovement(CancellationToken cancel)
            {
            while (!cancel.IsCancellationRequested)
                {
                try
                    {
                    machine.HardwareStatus.ShutterState = machine.ControllerActions.GetShutterState();
                    machine.HardwareStatus.ShutterPosition= machine.ControllerActions.GetShutterPosition();
                    }
                catch (TransactionException e)
                    {
                    Log.Error().Exception(e).Message($"MonitorShutterMovement: {e.Message}").Write();
                    }
                if (!IsShutterMoving())
                    machine.TransitionToState(new ReadyState(machine));
                await Task.Delay(TimeSpan.FromSeconds(1), cancel);
                }
            }

        private bool IsShutterMoving()
            {
            var state = machine.HardwareStatus.ShutterState;
            switch (state)
                {
                    case ShutterState.IsFullyOpen:
                    case ShutterState.IsFullyClosed:
                    case ShutterState.IsShutterError:
                        return false;
                    case ShutterState.IsOpening:
                    case ShutterState.IsClosing:
                        return true;
                    default:
                        throw new ArgumentOutOfRangeException();
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
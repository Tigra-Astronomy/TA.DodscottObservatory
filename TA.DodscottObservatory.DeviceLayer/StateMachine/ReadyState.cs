// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: ReadyState.cs  Last modified: 2019-01-17@04:10 by Tim Long

using System;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    internal class ReadyState : ControllerStateBase, IControllerState
        {
        /// <inheritdoc />
        public ReadyState(ControllerStateMachine machine) : base(machine) { }

        /// <inheritdoc />
        public override void OnEnter()
            {
            machine.InReadyState.Set();
            base.OnEnter();
            }

        /// <inheritdoc />
        public override void OnExit()
            {
            machine.InReadyState.Reset();
            base.OnExit();
            }

        /// <inheritdoc />
        public override void OpenShutter()
            {
            ResetTimeout(TimeSpan.FromMinutes(5));
            machine.ControllerActions.OpenShutter();
            machine.HardwareStatus.ShutterState = ShutterState.IsOpening;
            var nextState = new ShutterMovingState(machine);
            machine.TransitionToState(nextState);
            }
        }
    }
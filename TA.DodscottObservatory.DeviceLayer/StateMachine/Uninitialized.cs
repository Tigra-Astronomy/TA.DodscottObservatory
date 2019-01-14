// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: Uninitialized.cs  Last modified: 2019-01-13@20:31 by Tim Long

using System;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    internal class Uninitialized : IControllerState
        {
        private readonly InvalidOperationException uninitialized =
            new InvalidOperationException("Call Initialize() before using the state machine");

        public void OnEnter()
            {
            throw uninitialized;
            }

        public void OnExit() { }

        /// <inheritdoc />
        public void OpenShutter() => throw uninitialized;

        public string Name => nameof(Uninitialized);
        }
    }
﻿// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: ControllerStateMachine.cs  Last modified: 2019-01-13@20:27 by Tim Long

using System;
using System.Threading;
using JetBrains.Annotations;
using NLog.Fluent;

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    public class ControllerStateMachine
        {
        internal readonly ManualResetEvent InReadyState = new ManualResetEvent(false);
        [CanBeNull] internal CancellationTokenSource KeepAliveCancellationSource;

        public ControllerStateMachine(ControllerActions controllerActions)
            {
            ControllerActions = controllerActions;
            CurrentState = new Uninitialized();
            }

        internal ControllerActions ControllerActions { get; }

        internal IControllerState CurrentState { get; private set; }

        /// <summary>
        ///     Initializes the state machine and optionally sets the starting state.
        /// </summary>
        /// <param name="startState"></param>
        public void Initialize(IControllerState startState)
            {
            TransitionToState(startState);
            }

        public void TransitionToState([NotNull] IControllerState targetState)
            {
            if (targetState == null) throw new ArgumentNullException(nameof(targetState));
            try
                {
                CurrentState.OnExit();
                }
            catch (Exception ex)
                {
                Log.Error()
                    .Exception(ex)
                    .Message($"Unexpected exception leaving state {CurrentState.Name}")
                    .Write();
                }

            CurrentState = targetState;
            try
                {
                CurrentState.OnEnter();
                }
            catch (Exception ex)
                {
                Log.Error()
                    .Exception(ex)
                    .Message($"Unexpected exception entering state {targetState.Name}")
                    .Write();
                }
            }

        /// <summary>
        ///     Waits for the state machine to enter the Ready state. If the state is not reached within
        ///     the specified time limit, an exception is thrown.
        /// </summary>
        /// <param name="timeout">THe maximum amount of time to wait.</param>
        /// <exception cref="TimeoutException">
        ///     Thrown if the state machine is not ready within the
        ///     allotted time.
        /// </exception>
        public void WaitForReady(TimeSpan timeout)
            {
            var signalled = InReadyState.WaitOne(timeout);
            if (!signalled)
                {
                var message = $"State machine did not enter the ready state within the allotted time of {timeout}";
                Log.Error().Message(message).Write();
                throw new TimeoutException(message);
                }
            }
        }
    }
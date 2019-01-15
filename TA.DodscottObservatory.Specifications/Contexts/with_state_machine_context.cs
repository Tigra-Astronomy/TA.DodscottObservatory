// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: with_state_machine_context.cs  Last modified: 2019-01-15@05:24 by Tim Long

using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;

namespace TA.DodscottObservatory.Specifications.Contexts
    {
    #region  Context base classes
    class with_state_machine_context
        {
        Establish context = () => StateMachineBuilder = new StateMachineContextBuilder();
        protected static StateMachineContextBuilder StateMachineBuilder;

        protected static StateMachineContext Context { get; set; }

        protected static IControllerActions Actions => Context.Actions;

        protected static  ControllerStateMachine Machine => Context.Machine;
        }
    #endregion
    }
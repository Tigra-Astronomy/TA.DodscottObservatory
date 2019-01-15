// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: StateMachineContextBuilder.cs  Last modified: 2019-01-15@05:24 by Tim Long

using FakeItEasy;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.Contexts
    {
    class StateMachineContextBuilder
        {
        bool initializeInReadyState = false;
        public StateMachineContext Build()
            {
            var actions = A.Fake<IControllerActions>();
            var machine = new ControllerStateMachine(actions);
            if (initializeInReadyState)
                machine.Initialize(new ReadyState(machine));
            var context = new StateMachineContext
                {
                Actions = actions,
                Machine = machine
                };
            return context;
            }

        public StateMachineContextBuilder InReadyState()
            {
            initializeInReadyState = true;
            return this;
            }
        }
    }
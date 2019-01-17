// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: StateMachineContextBuilder.cs  Last modified: 2019-01-15@05:24 by Tim Long

using System;
using System.ComponentModel;
using FakeItEasy;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.Contexts
    {
    class StateMachineContextBuilder
        {
        bool initializeInReadyState = false;
        PropertyChangedEventHandler propertyChangedAction = null;
        bool mockShutterOpening = false;

        public StateMachineContext Build()
            {
            var actions = ConfigureActions();
            var status = new HardwareStatus();
            if (propertyChangedAction != null)
                status.PropertyChanged += propertyChangedAction;
            var machine = new ControllerStateMachine(actions, status);
            if (initializeInReadyState)
                machine.Initialize(new ReadyState(machine));
            var context = new StateMachineContext
                {
                Actions = actions,
                Machine = machine,
                HardwareStatus = status
                };
            return context;
            }

        private IControllerActions ConfigureActions()
            {
            var actions = A.Fake<IControllerActions>();
            if (mockShutterOpening)
                {
                A.CallTo(() => actions.QueryShutterState()).Returns(ShutterState.IsOpening);
                }
            return actions;
            }

        public StateMachineContextBuilder InReadyState()
            {
            initializeInReadyState = true;
            return this;
            }

        public StateMachineContextBuilder HandlePropertyChanged(PropertyChangedEventHandler action)
            {
            propertyChangedAction = action;
            return this;
            }

        public StateMachineContextBuilder WithShutterOpening()
            {
            mockShutterOpening = true;
            return this;
            }
        }
    }
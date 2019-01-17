// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: StateMachineSpecs.cs  Last modified: 2019-01-17@03:21 by Tim Long

using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.StateMachine
    {
    [Subject(typeof(ControllerStateMachine), "construction")]
    class when_constructing_the_state_machine : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder.Build();
        It should_be_uninitialized = () => Context.Machine.CurrentState.ShouldBeOfExactType<Uninitialized>();
        }

    [Subject(typeof(ControllerStateMachine), "initialization")]
    class when_initializing_the_state_machine_to_the_ready_state : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder.Build();
        Because of = () => Machine.Initialize(new ReadyState(Machine));
        It should_be_in_the_ready_state = () => Machine.CurrentState.ShouldBeOfExactType<ReadyState>();
        }

    [Subject(typeof(ControllerStateMachine), "initialization")]
    class when_the_user_fails_to_initialize_the_state_machine : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder.Build();
        Because of = () => Exception = Catch.Exception(() => Machine.OpenShutter());
        It should_throw = () => Exception.ShouldBeOfExactType<InvalidOperationException>();
        static Exception Exception;
        }

    [Subject(typeof(ControllerStateMachine), "Open Shutter")]
    class when_in_ready_state_and_open_shutter_trigger_is_received : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder
            .InReadyState()
            .HandlePropertyChanged((sender, args) => PropertiesChanged.Add(args.PropertyName))
            .WithShutterOpening()
            .Build();
        Because of = () => Machine.OpenShutter();
        It should_invoke_the_open_shutter_action =
            () => A.CallTo(() => Actions.OpenShutter()).MustHaveHappenedOnceExactly();
        It should_transition_to_shutter_moving_state =
            () => Machine.CurrentState.Name.ShouldEqual(nameof(ShutterMovingState));
        It should_indicate_shutter_opening = () => HardwareStatus.ShutterState.ShouldEqual(ShutterState.IsOpening);
        It should_change_the_shutter_state_property = () =>
            PropertiesChanged.Any(p => p == nameof(DeviceLayer.HardwareStatus.ShutterState)).ShouldBeTrue();
        static readonly List<string> PropertiesChanged = new List<string>();
        }
    }
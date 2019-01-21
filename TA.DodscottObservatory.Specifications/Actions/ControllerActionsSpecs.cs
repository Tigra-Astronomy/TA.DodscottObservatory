// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: ControllerActionsSpecs.cs  Last modified: 2019-01-19@20:05 by Tim Long

using System;
using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Contexts;
using TA.DodscottObservatory.Specifications.TestHelpers;
using static TA.DodscottObservatory.DeviceLayer.Constants;

namespace TA.DodscottObservatory.Specifications.Actions
    {
    class when_invoking_the_get_dome_state_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ds3#")
            .Build();
        Because of = () => state = Actions.GetDomeState();
        It should_send_the_get_dome_state_command = () => FakeChannel.ShouldHaveSent(CmdGetDomeState);
        It should_return_the_expected_status = () => state.ShouldEqual(DomeState.IsStopped);
        static DomeState state;
        }

    class when_invoking_the_get_shutter_state_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss3#")
            .Build();
        Because of = () => state = Actions.GetShutterState();
        It should_send_the_get_shutter_state_command = () => FakeChannel.ShouldHaveSent(CmdGetShutterState);
        It should_return_the_expected_status = () => state.ShouldEqual(ShutterState.IsClosing);
        static ShutterState state;
        }

    class when_invoking_the_open_shutter_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss2#")
            .Build();
        Because of = () => state = Actions.OpenShutter();
        It should_send_the_open_shutter_command = () => FakeChannel.ShouldHaveSent(CmdOpenShutter);
        It should_return_shutter_opening_status = () => state.ShouldEqual(ShutterState.IsOpening);
        static ShutterState state;
        }

    class when_invoking_the_close_shutter_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss3#")
            .Build();
        Because of = () => state = Actions.CloseShutter();
        It should_send_the_close_shutter_command = () => FakeChannel.ShouldHaveSent(CmdCloseShutter);
        It should_return_shutter_closing_status = () => state.ShouldEqual(ShutterState.IsClosing);
        static ShutterState state;
        }

    class when_invoking_the_query_shutter_state_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss3#")
            .Build();
        Because of = () => state = Actions.GetShutterState();
        It should_send_the_query_shutter_state_command = () => FakeChannel.ShouldHaveSent(CmdGetShutterState);
        It should_return_shutter_closing_status = () => state.ShouldEqual(ShutterState.IsClosing);
        static ShutterState state;
        }

    class when_invoking_the_query_shutter_position_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~s%10.5#")
            .Build();
        Because of = () => position = Actions.GetShutterPosition();
        It should_send_the_query_shutter_state_command = () => FakeChannel.ShouldHaveSent(CmdGetShutterPosition);
        It should_return_the_percent_open = () => position.ShouldEqual(10.5);
        static double position;
        }

    [Subject(typeof(ControllerActions), "timeout")]
    internal class when_querying_shutter_state_receives_no_response : with_fake_comms_stack
        {
        Establish context = () => Context=ContextBuilder.Build();
        Because of = () => Exception = Catch.Exception(() => state = Actions.GetShutterState());
        It should_throw = () => Exception.ShouldBeOfExactType<TransactionException>();
        static ShutterState state;
        static Exception Exception;
        }

    [Subject(typeof(ControllerActions), "timeout")]
    internal class when_open_shutter_action_receives_no_response : with_fake_comms_stack
        {
        Establish context = () => Context=ContextBuilder.Build();
        Because of = () => Exception = Catch.Exception(() => state = Actions.OpenShutter());
        It should_throw = () => Exception.ShouldBeOfExactType<TransactionException>();
        static ShutterState state;
        static Exception Exception;
        }

    [Subject(typeof(ControllerActions), "timeout")]
    internal class when_close_shutter_action_receives_no_response : with_fake_comms_stack
        {
        Establish context = () => Context=ContextBuilder.Build();
        Because of = () => Exception = Catch.Exception(() => state = Actions.CloseShutter());
        It should_throw = () => Exception.ShouldBeOfExactType<TransactionException>();
        static ShutterState state;
        static Exception Exception;
        }

    [Subject(typeof(ControllerActions), "timeout")]
    internal class when_querying_shutter_position_receives_no_response : with_fake_comms_stack
        {
        Establish context = () => Context=ContextBuilder.Build();
        Because of = () => exception = Catch.Exception(() => position = Actions.GetShutterPosition());
        It should_throw = () => exception.ShouldBeOfExactType<TransactionException>();
        static double position;
        static Exception exception;
        }

    [Subject(typeof(ControllerActions), "timeout")]
    internal class when_querying_rotation_state_receives_no_response : with_fake_comms_stack
        {
        Establish context = () => Context=ContextBuilder.Build();
        Because of = () => exception = Catch.Exception(() => state = Actions.GetDomeState());
        It should_throw = () => exception.ShouldBeOfExactType<TransactionException>();
        static DomeState state;
        static Exception exception;
        }

    /*
     *         DomeState RequestDomeStatus();

        ShutterState OpenShutter();

        ShutterState CloseShutter();

        ShutterState QueryShutterState();

        double QueryShutterPosition();

     */
}
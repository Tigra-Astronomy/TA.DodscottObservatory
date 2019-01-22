
using System;
using System.Threading.Tasks;
using FakeItEasy;
using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.StateMachine
    {
    [Subject(typeof(ShutterMovingState), "Cancellation")]
    internal class when_transitioning_to_shutter_moving_state : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder
            .InReadyState()
            .Build();
        Because of = () => Machine.TransitionToState(new ShutterMovingState(Machine));
        It should_request_the_shutter_state = () => A.CallTo(() => Actions.GetShutterState()).MustHaveHappened();
        It should_request_the_shutter_position =
            () => A.CallTo(() => Actions.GetShutterPosition()).MustHaveHappened();
        }

    [Subject(typeof(ShutterMovingState), "end of motion detection")]
    internal class when_the_shutter_stops_moving : with_state_machine_context
        {
        Establish context = () =>
            {
            Context = StateMachineBuilder
                .InReadyState()
                .Build();
            A.CallTo(()=>Actions.GetShutterState()).ReturnsNextFromSequence(ShutterState.IsFullyOpen);
            A.CallTo(()=>Actions.GetShutterPosition()).ReturnsNextFromSequence(100.0);
            };
        Because of = () =>
            {
            Machine.TransitionToState(new ShutterMovingState(Machine));
            Machine.WaitForReady(TimeSpan.FromSeconds(3));
            };
        It should_return_to_ready_state = () =>  Machine.CurrentState.Name.ShouldEqual(nameof(ReadyState));
        }

    [Subject(typeof(DomeMovingState), "progress monitoring")]
    internal class when_transitioning_to_dome_moving_state : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder
            .InReadyState()
            .Build();
        Because of = () => Machine.TransitionToState(new DomeMovingState(Machine));
        It should_request_the_dome_state = () => A.CallTo(() => Actions.GetDomeState()).MustHaveHappened();
        It should_request_the_dome_position =
            () => A.CallTo(() => Actions.GetDomePosition()).MustHaveHappened();
        }


    [Subject(typeof(DomeMovingState), "end of motion detection")]
    internal class when_the_dome_stops_moving : with_state_machine_context
        {
        Establish context = () =>
            {
            Context = StateMachineBuilder
                .InReadyState()
                .Build();
            A.CallTo(() => Actions.GetDomeState()).ReturnsNextFromSequence(DomeState.IsStopped);
            A.CallTo(() => Actions.GetDomePosition()).ReturnsNextFromSequence(100.0);
            };
        Because of = () =>
            {
            Machine.TransitionToState(new DomeMovingState(Machine));
            Machine.WaitForReady(TimeSpan.FromSeconds(3));
            };
        It should_return_to_ready_state = () => Machine.CurrentState.Name.ShouldEqual(nameof(ReadyState));
        }

}
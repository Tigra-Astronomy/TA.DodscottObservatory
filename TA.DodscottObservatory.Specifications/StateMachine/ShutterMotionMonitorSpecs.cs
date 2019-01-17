
using System;
using System.Threading.Tasks;
using FakeItEasy;
using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer.StateMachine;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.StateMachine
    {
    [Subject(typeof(ShutterMotionMonitor), "Cancellation")]
    internal class when_transitioning_to_shutter_moving_state : with_state_machine_context
        {
        Establish context = () => Context = StateMachineBuilder
            .InReadyState()
            .Build();
        Because of = () => Machine.TransitionToState(new ShutterMovingState(Machine));
        It should_request_the_shutter_state = () => A.CallTo(() => Actions.QueryShutterState()).MustHaveHappened();
        It should_request_the_shutter_position = () => A.CallTo(() => Actions.QueryShutterPosition()).MustHaveHappened();
        }

    class ShutterMotionMonitor { }
    }
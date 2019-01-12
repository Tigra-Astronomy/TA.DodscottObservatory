using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Contexts;
using TA.DodscottObservatory.Specifications.TestHelpers;
using static TA.DodscottObservatory.DeviceLayer.Constants;

namespace TA.DodscottObservatory.Specifications.Actions
    {
    internal class when_invoking_the_get_dome_state_action : with_fake_comms_stack
        {
        Establish context = () => Context=ContextBuilder
            .WithFakeResponse("~ds3#")
            .Build();
        Because of = () => state = Actions.RequestDomeStatus();
        It should_send_the_get_dome_state_command = () => FakeChannel.ShouldHaveSent(CmdGetDomeState);
        It should_return_the_expected_status = () => state.ShouldEqual(DomeState.IsStopped);
        static DomeState state;
        }

    internal class when_invoking_the_get_shutter_state_action:with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss3#")
            .Build();
        Because of = () => state = Actions.GetShutterState();
        It should_send_the_get_shutter_state_command = () => FakeChannel.ShouldHaveSent(CmdGetShutterState);
        It should_return_the_expected_status = () => state.ShouldEqual(ShutterState.IsClosing);
        static ShutterState state;
        }
    internal class when_invoking_the_open_shutter_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss2#")
            .Build();
        Because of = () => state = Actions.OpenShutter();
        It should_send_the_open_shutter_command = () => FakeChannel.ShouldHaveSent(CmdOpenShutter);
        It should_return_shutter_opening_status = () => state.ShouldEqual(ShutterState.IsOpening);
        static ShutterState state;
        }
    internal class when_invoking_the_close_shutter_action : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder
            .WithFakeResponse("~ss3#")
            .Build();
        Because of = () => state = Actions.CloseShutter();
        It should_send_the_close_shutter_command = () => FakeChannel.ShouldHaveSent(CmdCloseShutter);
        It should_return_shutter_closing_status = () =>  state.ShouldEqual(ShutterState.IsClosing);
        static ShutterState state;
    }
}
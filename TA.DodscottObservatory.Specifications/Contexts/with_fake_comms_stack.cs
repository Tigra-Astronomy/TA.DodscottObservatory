using Machine.Specifications;
using TA.Ascom.ReactiveCommunications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Fakes;

namespace TA.DodscottObservatory.Specifications.Contexts {
    class with_fake_comms_stack
        {
        protected static DeviceControllerContextBuilder ContextBuilder;
        protected static DeviceControllerContext Context;

        protected static ICommunicationChannel Channel => Context.Channel;
        protected static FakeCommunicationChannel FakeChannel => Context.Channel as FakeCommunicationChannel;

        protected static ControllerActions Actions => Context.Actions;

        Establish context = () => { ContextBuilder = new DeviceControllerContextBuilder(); };

        Cleanup after = () =>
            {
            Context.TransactionProcessor = null;
            Channel?.Dispose();
            Context.Channel = null;
            Context.Actions = null;
            ContextBuilder = null;
            };
        }
    }
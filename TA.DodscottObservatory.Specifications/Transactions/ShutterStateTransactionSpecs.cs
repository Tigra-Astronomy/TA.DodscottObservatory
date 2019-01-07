using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.Transactions
    {
    [Subject(typeof(ShutterStateTransaction), "Receive response")]
    class when_receiving_a_shutter_opening_status : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder.WithFakeResponse("~ss2#").Build();
        Because of = () =>
            {
            transaction = new ShutterStateTransaction("smO");
            Context.TransactionProcessor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            };
        It should_indicate_shutter_opening = () => transaction.Value.ShouldEqual(ShutterState.IsOpening);
        static ShutterStateTransaction transaction;
        }
    }
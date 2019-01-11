using System;
using System.Diagnostics;
using System.Linq;
using Machine.Specifications;
using TA.Ascom.ReactiveCommunications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Contexts;

namespace TA.DodscottObservatory.Specifications.Transactions
{
    [Subject(typeof(DomeStateTransaction), "Receive response")]
    class when_receiving_a_dome_at_park_status : with_fake_comms_stack
    {
        Establish context = () => Context = ContextBuilder.WithFakeResponse("~ds1#").Build();
        Because of = () =>
        {
            transaction = new DomeStateTransaction("dgS");
            Context.TransactionProcessor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
        };
        It should_indicate_dome_parked = () => transaction.Value.ShouldEqual(DomeState.IsAtPark);
        static DomeStateTransaction transaction;
    }

    [Subject(typeof(DomeStateTransaction), "valid values")]
    class when_receiving_a_dome_status_with_invalid_values : with_fake_comms_stack
    {
        Establish context = () => Context = ContextBuilder.WithFakeResponse("~ds7#").Build();
        Because of = () =>
        {
            transaction = new DomeStateTransaction("dgS");
            Context.TransactionProcessor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
        };
        It should_fail = () => transaction.Failed.ShouldBeTrue();
        It should_time_out = () => transaction.ErrorMessage.Single().ShouldContain("Timed out");
        static DomeStateTransaction transaction;
    }

    [Subject(typeof(DomeStateTransaction), "timeout")]
    internal class when_no_dome_state_is_received_after_2_seconds : with_fake_comms_stack
    {
        Establish context = () => Context = ContextBuilder.Build();
        Because of = () =>
        {
            transaction = new DomeStateTransaction("dgS");
            Context.TransactionProcessor.CommitTransaction(transaction);
            stopwatch.Start();
            transaction.WaitForCompletionOrTimeout();
            stopwatch.Stop();
        };
        It should_time_out = () => transaction.ErrorMessage.Single().ShouldContain("Timed out");
        It should_fail = () => transaction.Failed.ShouldBeTrue();
        It should_fail_within_2_seconds = () => stopwatch.Elapsed.ShouldBeLessThanOrEqualTo(TimeSpan.FromSeconds(2.1));
        It should_fail_with_an_error_value = () => transaction.Value.ShouldEqual(DomeState.IsDomeError);
        static DomeStateTransaction transaction;
        static Stopwatch stopwatch = new Stopwatch();
    }
}
using System;
using System.Diagnostics;
using System.Linq;
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

    [Subject(typeof(ShutterStateTransaction), "valid values")]
    class when_receiving_a_shutter_status_with_invalid_values : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder.WithFakeResponse("~ss7#").Build();
        Because of = () =>
            {
            transaction = new ShutterStateTransaction("smO");
            Context.TransactionProcessor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            };
        It should_fail = () => transaction.Failed.ShouldBeTrue();
        It should_time_out = () => transaction.ErrorMessage.Single().ShouldContain("Timed out");
        static ShutterStateTransaction transaction;
        }

    [Subject(typeof(ShutterStateTransaction), "timeout")]
    internal class when_no_response_is_received_after_2_seconds : with_fake_comms_stack
        {
        Establish context = () => Context = ContextBuilder.Build();
        Because of = () =>
            {
            transaction = new ShutterStateTransaction("smO") ;
            Context.TransactionProcessor.CommitTransaction(transaction);
            stopwatch.Start();
            transaction.WaitForCompletionOrTimeout();
            stopwatch.Stop();
            };
        It should_time_out = () =>  transaction.ErrorMessage.Single().ShouldContain("Timed out");
        It should_fail = () => transaction.Failed.ShouldBeTrue();
        It should_fail_within_2_seconds = () => stopwatch.Elapsed.ShouldBeLessThanOrEqualTo(TimeSpan.FromSeconds(2.1));
        It should_fail_with_an_error_value = () => transaction.Value.ShouldEqual(ShutterState.IsShutterError);
        static ShutterStateTransaction transaction;
        static Stopwatch stopwatch = new Stopwatch();
        }
    }
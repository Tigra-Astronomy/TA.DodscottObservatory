using System;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using TA.Ascom.ReactiveCommunications;
using TA.Ascom.ReactiveCommunications.Diagnostics;

namespace TA.DodscottObservatory.DeviceLayer
{
    internal class DomeStateTransaction : TransactionBase
    {
        const string domeStateResponsePattern = @"~ds(?<State>[0-6])#";
        private static Regex domeStateResponseRegex = new Regex(domeStateResponsePattern,
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture |
            RegexOptions.Singleline);
        /// <inheritdoc />
        public DomeStateTransaction(string command) : base(command) { }

        /// <inheritdoc />
        public override void ObserveResponse(IObservable<char> source)
        {
            var domeStateResponses = from response in source.DelimitedMessageStrings('~', '#')
                                        where domeStateResponseRegex.IsMatch(response)
                                        select response;
            domeStateResponses
                .Trace("Dome State Response")
                .Take(1)
                .Subscribe(OnNext, OnError, OnCompleted);
        }

        /// <inheritdoc />
        protected override void OnCompleted()
        {
            if (Response.Any())
            {
                var captures = domeStateResponseRegex.Match(Response.Single());
                var value = captures.Groups["State"].Value;
                var valueInt = int.Parse(value);
                Value = (DomeState)valueInt;
            }
            base.OnCompleted();
        }

        /// <inheritdoc />
        protected override void OnError(Exception except)
        {
            Value = DomeState.IsDomeError;
            base.OnError(except);
        }

        public DomeState Value { get; private set; } = DomeState.IsDomeError;
    }
}
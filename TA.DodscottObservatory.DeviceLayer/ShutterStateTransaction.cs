using System;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using TA.Ascom.ReactiveCommunications;
using TA.Ascom.ReactiveCommunications.Diagnostics;

namespace TA.DodscottObservatory.DeviceLayer {
    internal class ShutterStateTransaction : TransactionBase
        {
        const string shutterStateResponsePattern = @"~ss(?<State>\d)#";
        private static Regex shutterStateResponseRegex = new Regex(shutterStateResponsePattern,
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture |
            RegexOptions.Singleline);
        /// <inheritdoc />
        public ShutterStateTransaction(string command) : base(command) { }

        /// <inheritdoc />
        public override void ObserveResponse(IObservable<char> source)
            {
            var terminatedStrings = source.DelimitedMessageStrings('~', '#');
            var shutterStateResponses =
                terminatedStrings.Where(response => shutterStateResponseRegex.IsMatch(response));
            var sequence = shutterStateResponses
                .Trace("Shutter State Response")
                .Take(1);
            sequence.Subscribe(OnNext, OnError, OnCompleted);
            }

        /// <inheritdoc />
        protected override void OnCompleted()
            {
            if (Response.Any())
                {
                var captures = shutterStateResponseRegex.Match(Response.Single());
                var value = captures.Groups["State"].Value;
                var valueInt = int.Parse(value);
                Value = (ShutterState) valueInt;
                }
            base.OnCompleted();
            }

        public ShutterState Value { get; private set; }
        }
    }
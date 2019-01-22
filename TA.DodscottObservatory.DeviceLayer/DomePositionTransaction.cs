// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: DomePositionTransaction.cs  Last modified: 2019-01-21@00:48 by Tim Long

using System;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using TA.Ascom.ReactiveCommunications;
using TA.Ascom.ReactiveCommunications.Diagnostics;
using static TA.DodscottObservatory.DeviceLayer.Constants;

namespace TA.DodscottObservatory.DeviceLayer
    {
    public class DomePositionTransaction : TransactionBase
        {
        private const string domePositionPattern = @"^da(?<Value>\d+(\.\d+)?)$";
        private static readonly Regex domePositionRegex = new Regex(domePositionPattern,
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture |
            RegexOptions.Singleline);

        /// <inheritdoc />
        public DomePositionTransaction(string command) : base(command) { }

        public double Value { get; private set; }

        public override void ObserveResponse(IObservable<char> source)
            {
            var query = from response in source.DelimitedMessageStrings(EncapsulationHeader[0], EncapsulationFooter[0])
                        let unencapsulatedResponse =
                            response.TrimStart(EncapsulationHeader[0]).TrimEnd(EncapsulationFooter[0])
                        let match = domePositionRegex.Match(unencapsulatedResponse)
                        where match.Success
                        select match.Groups["Value"].Value;
            query.Trace("Dome Position")
                .Take(1)
                .Subscribe(OnNext, OnError, OnCompleted);
            }

        /// <inheritdoc />
        protected override void OnCompleted()
            {
            if (Response.Any())
                try
                    {
                    Value = double.Parse(Response.Single());
                    base.OnCompleted();
                    }
                catch (FormatException e)
                    {
                    OnError(e);
                    }
            else
                OnError(new Exception("Invalid response"));
            }
        }
    }
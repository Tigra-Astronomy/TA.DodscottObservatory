using System;
using System.Text;
using TA.Ascom.ReactiveCommunications;

namespace TA.DodscottObservatory.DeviceLayer {
    internal class TransactionBase : DeviceTransaction {
        /// <inheritdoc />
        public TransactionBase(string command) : base(AddEncapsulation(command))
            {
            Timeout=TimeSpan.FromSeconds(2);
            }

        internal static string AddEncapsulation(string command)
            {
            var builder = new StringBuilder();
            if (!command.StartsWith(Constants.EncapsulationHeader))
                builder.Append(Constants.EncapsulationHeader);
            builder.Append(command);
            if (!command.EndsWith(Constants.EncapsulationFooter))
                builder.Append(Constants.EncapsulationFooter);
            return builder.ToString();
            }

        /// <inheritdoc />
        /// <inheritdoc />
        public override void ObserveResponse(IObservable<char> source) {  }
        }
    }
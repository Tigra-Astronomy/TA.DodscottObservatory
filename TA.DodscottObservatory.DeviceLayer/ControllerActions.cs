// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: ControllerActions.cs  Last modified: 2019-01-12@02:00 by Tim Long

using TA.Ascom.ReactiveCommunications;
using static TA.DodscottObservatory.DeviceLayer.Constants;

namespace TA.DodscottObservatory.DeviceLayer
    {
    public class ControllerActions : IControllerActions
        {
        private readonly ITransactionProcessor processor;

        public ControllerActions(ITransactionProcessor processor)
            {
            this.processor = processor;
            }

        public DomeState RequestDomeStatus()
            {
            var transaction = new DomeStateTransaction(CmdGetDomeState);
            processor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            return transaction.Value;
            }

        public ShutterState GetShutterState()
            {
            var transaction = new ShutterStateTransaction(CmdGetShutterState);
            processor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            return transaction.Value;
            }

        public ShutterState OpenShutter()
            {
            var transaction = new ShutterStateTransaction(CmdOpenShutter);
            processor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            return transaction.Value;
            }

        public ShutterState CloseShutter()
            {
            var transaction = new ShutterStateTransaction(CmdCloseShutter);
            processor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            return transaction.Value;
            }

        /// <inheritdoc />
        public ShutterState QueryShutterState()
            {
            var transaction = new ShutterStateTransaction(CmdGetShutterState);
            processor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            return transaction.Value;
            }

        /// <inheritdoc />
        public double QueryShutterPosition()
            {
            var transaction = new ShutterPositionTransaction(Constants.CmdGetShutterPosition);
            processor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            return transaction.Value;
            }
    }
    }
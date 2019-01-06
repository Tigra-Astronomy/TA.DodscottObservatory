// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2016-2019 Tigra Astronomy, all rights reserved.
// 
// File: BaseTransactionSpecs.cs  Last modified: 2019-01-06@02:03 by Tim Long

using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using static TA.DodscottObservatory.DeviceLayer.Constants;

namespace TA.DodscottObservatory.Specifications.Transactions
    {
    [Subject(typeof(TransactionBase), "construction")]
    internal class when_creating_a_transaction
        {
        //Arrange
        //Act
        Because of = () => Transaction = new TransactionBase("test");
        //Assert
        It should_add_the_encapsulation_footer = () => Transaction.Command.ShouldEndWith(EncapsulationFooter);
        It should_add_the_encapsulation_header = () => Transaction.Command.ShouldStartWith(EncapsulationHeader);
        private static TransactionBase Transaction;
        }
    }
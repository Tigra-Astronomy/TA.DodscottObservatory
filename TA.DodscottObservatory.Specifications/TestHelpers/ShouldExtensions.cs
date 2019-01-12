using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Fakes;

namespace TA.DodscottObservatory.Specifications.TestHelpers
{
    internal static class ShouldExtensions
    {
    public static void ShouldHaveSent(this FakeCommunicationChannel channel, string command)
        {
        var encapsulatedCommand = TransactionBase.AddEncapsulation(command);
        if (!channel.SendLog.Contains(encapsulatedCommand))
            throw new SpecificationException($"Channel should have sent [{encapsulatedCommand}] but did not.");
        }
    }
}

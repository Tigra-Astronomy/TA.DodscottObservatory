using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Ascom.ReactiveCommunications;

namespace TA.DodscottObservatory.DeviceLayer
{
    public class Diagnostics
    {
    public ITransactionProcessor InitialiseComms(string connectionString)
        {
        var factory = new ChannelFactory();
        var channel = factory.FromConnectionString(connectionString);
        var observer = new TransactionObserver(channel);
        var processor = new ReactiveTransactionProcessor();
        processor.SubscribeTransactionObserver(observer);
        channel.Open();
        return processor;
        }
    }
}

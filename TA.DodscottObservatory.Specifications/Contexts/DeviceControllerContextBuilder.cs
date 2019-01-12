using System;
using System.Text;
using TA.Ascom.ReactiveCommunications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Specifications.Fakes;

namespace TA.DodscottObservatory.Specifications.Contexts
{
    class DeviceControllerContextBuilder
    {
    private ChannelFactory channelFactory;
    private StringBuilder fakeResponseBuilder = new StringBuilder();
    private string connectionString = "Fake";
    private bool channelShouldBeOpen = true;

    public DeviceControllerContextBuilder()
        {
        channelFactory = new ChannelFactory();
        channelFactory.RegisterChannelType(
            p => p.StartsWith("Fake", StringComparison.InvariantCultureIgnoreCase),
            connection => new FakeEndpoint(),
            endpoint => new FakeCommunicationChannel(fakeResponseBuilder.ToString())
            );
        }

    public DeviceControllerContext Build()
        {
        var context = new DeviceControllerContext();
        var channel = channelFactory.FromConnectionString(connectionString);
        if (channelShouldBeOpen)
            channel.Open();
        var observer = new TransactionObserver(channel);
        var processor = new ReactiveTransactionProcessor();
        processor.SubscribeTransactionObserver(observer);
        context.Channel = channel;
        context.TransactionProcessor = processor;
        context.Actions = new ControllerActions(processor);
        return context;
        }

    public DeviceControllerContextBuilder WithFakeResponse(string fakeResponse)
        {
        fakeResponseBuilder.Append(fakeResponse);
        return this;
        }
    }
}

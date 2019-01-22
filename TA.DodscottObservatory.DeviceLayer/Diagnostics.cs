using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Ascom.ReactiveCommunications;
using TA.DodscottObservatory.DeviceLayer.StateMachine;

namespace TA.DodscottObservatory.DeviceLayer
{
    public static class Diagnostics
    {
    public static ITransactionProcessor InitialiseComms(string connectionString)
        {
        var factory = new ChannelFactory();
        var channel = factory.FromConnectionString(connectionString);
        var observer = new TransactionObserver(channel);
        var processor = new ReactiveTransactionProcessor();
        processor.SubscribeTransactionObserver(observer);
        channel.Open();
        return processor;
        }

    public static DeviceController CreateDeviceController(string connection)
        {
        var processor = InitialiseComms(connection);
        var status = new HardwareStatus();
        status.PropertyChanged += (sender, args) => Console.WriteLine($"{args.PropertyName} changed");
        var actions = new ControllerActions(processor);
        var machine = new ControllerStateMachine(actions, status);
        machine.Initialize(new ReadyState(machine));
        var controller = new DeviceController(machine);
        return controller;
        }
    }
}

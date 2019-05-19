// This file is part of the TA.DigitalDomeworks project
// 
// Copyright © 2016-2018 Tigra Astronomy, all rights reserved.
// 
// File: CompositionRoot.cs  Last modified: 2018-06-17@17:22 by Tim Long

using System;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Syntax;
using NLog.Fluent;
using TA.Ascom.ReactiveCommunications;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.DeviceLayer.StateMachine;
using TA.DodscottObservatory.Server.Properties;

namespace TA.DodscottObservatory.Server
    {
    public static class CompositionRoot
        {
        static CompositionRoot()
            {
            Kernel = new StandardKernel(new CoreModule());
            }

        private static ScopeObject CurrentScope { get; set; }

        public static IKernel Kernel { get; }

        public static void BeginSessionScope()
            {
            var scope = new ScopeObject();
            Log.Info()
                .Message($"Beginning session scope id={scope.ScopeId}")
                .Write();
            CurrentScope = scope;
            }

        public static IBindingNamedWithOrOnSyntax<T> InSessionScope<T>(this IBindingInSyntax<T> binding)
            {
            return binding.InScope(ctx => CurrentScope);
            }
        }

    internal class ScopeObject
        {
        private static int scopeId;

        public ScopeObject()
            {
            ++scopeId;
            }

        public int ScopeId => scopeId;
        }

    internal class CoreModule : NinjectModule
        {
        public override void Load()
        {
            Bind<ITransactionProcessor>().ToMethod(BuildTransactionProcessor).InSessionScope();
            Bind<TransactionObserver>().ToSelf().InSessionScope();
            Bind<ControllerStateMachine>().ToMethod(BuildStateMachine).InSessionScope();
            Bind<DeviceController>().ToSelf().InSessionScope();
            Bind<ICommunicationChannel>()
                .ToMethod(BuildCommunicationsChannel)
                .InSessionScope();
            Bind<ChannelFactory>().ToMethod(BuildChannelFactory).InSessionScope();
            //Bind<IClock>().To<SystemDateTimeUtcClock>().InSingletonScope();
            Bind<IControllerActions>().To<ControllerActions>().InSessionScope();
            //Bind<DeviceControllerOptions>().ToMethod(BuildDeviceOptions).InSessionScope();
            //Bind<ITransactionProcessor>().To<ReactiveTransactionProcessor>().InSessionScope();
            }

        private ControllerStateMachine BuildStateMachine(IContext arg)
        {
            var actions = Kernel.Get<IControllerActions>();
            var status = Kernel.Get<HardwareStatus>();
            var machine = new ControllerStateMachine(actions, status);
            machine.StartInReadyState();
            return machine;
        }

        private ICommunicationChannel BuildCommunicationsChannel(IContext context)
            {
            var channelFactory = Kernel.Get<ChannelFactory>();
            var channel = channelFactory.FromConnectionString(Settings.Default.ConnectionString);
            channel.Open();
            return channel;
            }

        private ITransactionProcessor BuildTransactionProcessor(IContext context)
        {
            var processor = new ReactiveTransactionProcessor();
            var observer = Kernel.Get<TransactionObserver>();
            processor.SubscribeTransactionObserver(observer);
            return processor;
        }

        private ChannelFactory BuildChannelFactory(IContext arg)
            {
            return new ChannelFactory();
            }

        //private DeviceControllerOptions BuildDeviceOptions(IContext arg)
        //    {
        //    var options = new DeviceControllerOptions
        //        {
        //        PerformShutterRecovery = Settings.Default.PerformShutterRecovery,
        //        MaximumShutterCloseTime = TimeSpan.FromSeconds((double) Settings.Default.ShutterOpenCloseTimeSeconds),
        //        MaximumFullRotationTime = TimeSpan.FromSeconds((double) Settings.Default.FullRotationTimeSeconds),
        //        KeepAliveTimerInterval = Settings.Default.KeepAliveTimerPeriod,
        //        CurrentDrawDetectionThreshold = Settings.Default.CurrentDrawDetectionThreshold,
        //        IgnoreHardwareShutterSensor = Settings.Default.IgnoreHardwareShutterSensor,
        //        ShutterTickTimeout = Settings.Default.ShutterTickTimeout
        //        };
        //    return options;
        //    }
        }
    }
// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: HardwareStatus.cs  Last modified: 2019-01-15@11:25 by Tim Long

using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using PostSharp.Patterns.Model;

namespace TA.DodscottObservatory.DeviceLayer
    {
    [NotifyPropertyChanged]
    public class HardwareStatus : INotifyPropertyChanged
        {
        public ShutterState ShutterState { get; set; }
        public double Azimuth { get; set; }

        public double ShutterPosition { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
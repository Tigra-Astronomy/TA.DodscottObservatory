// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: DeviceController.cs  Last modified: 2019-01-22@04:46 by Tim Long

using TA.DodscottObservatory.DeviceLayer.StateMachine;

namespace TA.DodscottObservatory.DeviceLayer
    {
    public class DeviceController
        {
        private readonly ControllerStateMachine machine;

        public DeviceController(ControllerStateMachine machine)
            {
            this.machine = machine;
            }

        private HardwareStatus Status => machine.HardwareStatus;

        public ShutterState ShutterState => Status.ShutterState;

        public DomeState DomeState => Status.DomeState;

        public double Azimuth => Status.Azimuth;

        public double ShutterPosition => Status.ShutterPosition;

        public void OpenShutter() => machine.OpenShutter();

        public void CloseShutter() => machine.CloseShutter();

        public void RotateToAzimuth(double azimuthDegrees) => machine.RotateToAzimuth(azimuthDegrees);
        }
    }
// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: IControllerStateTriggers.cs  Last modified: 2019-01-15@05:42 by Tim Long

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    public interface IControllerStateTriggers
        {
        void OpenShutter();

        void CloseShutter();

        void RotateToAzimuth(double targetAzimuthDegrees);
        }
    }
﻿// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: IControllerState.cs  Last modified: 2019-01-15@05:53 by Tim Long

namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    public interface IControllerState : IControllerStatePlumbing, IControllerStateTriggers { }
    }
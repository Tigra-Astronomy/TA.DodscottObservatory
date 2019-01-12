// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: DomeState.cs  Last modified: 2019-01-11@01:17 by Tim Long

namespace TA.DodscottObservatory.DeviceLayer
    {
    public enum DomeState
        {
        IsDomeError,
        IsAtPark,
        IsInHomeZone,
        IsStopped,
        IsSlewingClockwise,
        IsSlewingCounterClockwise,
        IsHoming
        }
    }
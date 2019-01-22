// This file is part of the TA.DodscottObservatory project
// 
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.
// 
// File: Constants.cs  Last modified: 2019-01-21@01:18 by Tim Long

namespace TA.DodscottObservatory.DeviceLayer
    {
    public static class Constants
        {
        public const string CmdGetDomeState = "dgS";
        public const string CmdGetShutterState = "sgS";
        public const string CmdOpenShutter = "smO";
        public const string CmdCloseShutter = "smC";
        public const string EncapsulationFooter = "#";
        public const string EncapsulationHeader = "~";
        public const string CmdGetShutterPosition = "sg%";
        public const string CmdGetDomeAzimuth = "dgA";
        public const string CmdRotateToAzimuth = "dmP";
        }
    }
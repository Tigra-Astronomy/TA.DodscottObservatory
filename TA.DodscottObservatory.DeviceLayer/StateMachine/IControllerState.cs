// This file is part of the TA.DigitalDomeworks project
// 
// Copyright © 2016-2018 Tigra Astronomy, all rights reserved.
// 
// File: IControllerState.cs  Last modified: 2018-03-28@00:58 by Tim Long


namespace TA.DodscottObservatory.DeviceLayer.StateMachine
    {
    public interface IControllerState
        {
        string Name { get; }

        /// <summary>
        ///     Called once when the state it first entered, but after the previous state's
        ///     <see cref="OnExit" /> method has been called.
        /// </summary>
        void OnEnter();

        /// <summary>
        ///     Called once when the state exits but before the next state's
        ///     <see cref="OnEnter" /> method is called.
        /// </summary>
        void OnExit();

        void OpenShutter();
        }
    }
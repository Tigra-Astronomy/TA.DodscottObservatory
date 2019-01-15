namespace TA.DodscottObservatory.DeviceLayer.StateMachine {
    public interface IControllerStatePlumbing {
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
        }
    }
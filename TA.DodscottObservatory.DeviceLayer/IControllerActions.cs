namespace TA.DodscottObservatory.DeviceLayer {
    public interface IControllerActions {
        DomeState RequestDomeStatus();

        ShutterState GetShutterState();

        ShutterState OpenShutter();

        ShutterState CloseShutter();
        }
    }
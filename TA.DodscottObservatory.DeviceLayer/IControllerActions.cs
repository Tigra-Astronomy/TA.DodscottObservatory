namespace TA.DodscottObservatory.DeviceLayer {
    public interface IControllerActions {
        DomeState GetDomeState();

        ShutterState OpenShutter();

        ShutterState CloseShutter();

        ShutterState GetShutterState();

        double GetShutterPosition();

        double GetDomePosition();

        DomeState RotateToAzimuth(double targetAzimuthDegrees);
        }
    }
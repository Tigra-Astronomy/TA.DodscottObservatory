using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ASCOM;
using ASCOM.DeviceInterface;
using TA.DodscottObservatory.DeviceLayer;
using TA.DodscottObservatory.Server;
using ShutterState = ASCOM.DeviceInterface.ShutterState;

namespace TA.DodscottObservatory
{
    [ProgId(SharedResources.DomeDriverId)]
    [Guid("2F95B133-954A-4568-B4CB-CB204F53907A")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [DeviceId(SharedResources.DomeDriverId, DeviceName = SharedResources.DomeDriverName)]
    [ServedClassName(SharedResources.DomeDriverName)]

    public class Dome : ReferenceCountedObject, IDomeV2
    {
        private readonly Guid clientId;
        private DeviceController controller;

        public Dome()
        {
            clientId = SharedResources.ConnectionManager.RegisterClient(SharedResources.DomeDriverId);
        }

        /// <inheritdoc />
        public void SetupDialog()
        {
        }

        /// <inheritdoc />
        public string Action(string ActionName, string ActionParameters)
        {
            return null;
        }

        /// <inheritdoc />
        public void CommandBlind(string Command, bool Raw = false)
        {
        }

        /// <inheritdoc />
        public bool CommandBool(string Command, bool Raw = false)
        {
            return false;
        }

        /// <inheritdoc />
        public string CommandString(string Command, bool Raw = false)
        {
            return null;
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public void AbortSlew()
        {
        }

        /// <inheritdoc />
        public void CloseShutter()
        {
            controller.CloseShutter();
        }

        /// <inheritdoc />
        public void FindHome()
        {
            
        }

        /// <inheritdoc />
        public void OpenShutter()
        {
            controller.OpenShutter();
        }

        /// <inheritdoc />
        public void Park()
        {
        }

        /// <inheritdoc />
        public void SetPark()
        {
        }

        /// <inheritdoc />
        public void SlewToAltitude(double Altitude)
        {
        }

        /// <inheritdoc />
        public void SlewToAzimuth(double Azimuth)
        {
            controller.RotateToAzimuth(Azimuth);
        }

        /// <inheritdoc />
        public void SyncToAzimuth(double Azimuth)
        {
        }

        /// <inheritdoc />
        public bool Connected
        {
            get => controller!=null;
            set
            {
                if (value)
                    controller = SharedResources.ConnectionManager.GoOnline(clientId);
                else
                {
                    controller = null;
                    SharedResources.ConnectionManager.GoOffline(clientId);
                }
            }
        }

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public string DriverInfo { get; }

        /// <inheritdoc />
        public string DriverVersion { get; }

        /// <inheritdoc />
        public short InterfaceVersion { get; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public ArrayList SupportedActions { get; }

        /// <inheritdoc />
        public double Altitude { get; }

        /// <inheritdoc />
        public bool AtHome { get; }

        /// <inheritdoc />
        public bool AtPark { get; }

        /// <inheritdoc />
        public double Azimuth { get; }

        /// <inheritdoc />
        public bool CanFindHome { get; }

        /// <inheritdoc />
        public bool CanPark { get; }

        /// <inheritdoc />
        public bool CanSetAltitude { get; }

        /// <inheritdoc />
        public bool CanSetAzimuth { get; }

        /// <inheritdoc />
        public bool CanSetPark { get; }

        /// <inheritdoc />
        public bool CanSetShutter { get; }

        /// <inheritdoc />
        public bool CanSlave { get; }

        /// <inheritdoc />
        public bool CanSyncAzimuth { get; }

        /// <inheritdoc />
        public ShutterState ShutterStatus { get; }

        /// <inheritdoc />
        public bool Slaved { get; set; }

        /// <inheritdoc />
        public bool Slewing { get; }
    }
}

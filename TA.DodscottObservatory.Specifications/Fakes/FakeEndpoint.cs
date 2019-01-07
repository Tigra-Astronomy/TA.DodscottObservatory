using TA.Ascom.ReactiveCommunications;

namespace TA.DodscottObservatory.Specifications.Fakes
    {
    class FakeEndpoint : DeviceEndpoint
        {
        public override string ToString()
            {
            return "fake device";
            }
        }
    }
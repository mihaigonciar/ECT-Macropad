using EyecraftTech.PicoHandler;

namespace EyecraftTech.Devices
{
    public abstract class BoardBase
    {
        public bool IsBoardConnected { get; private set; } = false;

        public readonly List<BoardModuleBase> Modules = [];

        public BoardBase(Pico board) 
        {
            board.HardwareConnected += OnHardwareConnectedInternal;
            board.HardwareDisconnected += OnHardwareDisconnectedInternal;
            board.DataReceived += ReadDataInternal;

            if (board.IsDeviceConnected)
            {
                OnHardwareConnectedInternal();
            }
        }

        protected virtual void OnHardwareConnected() { }
        protected virtual void OnHardwareDisconnected() { }
        protected virtual void ReadData(byte[] data) { }

        private void ReadDataInternal(byte[] data)
        {
            foreach (BoardModuleBase module in Modules) 
            {
                module.ProcessData(data);
            }

            ReadData(data);
        }

        private void OnHardwareConnectedInternal()
        {
            IsBoardConnected = true;
            OnHardwareConnected();
        }

        private void OnHardwareDisconnectedInternal()
        {
            IsBoardConnected = false;
            OnHardwareDisconnected();
        }
    }
}

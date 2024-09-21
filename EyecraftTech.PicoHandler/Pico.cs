using System.IO.Ports;
using EyecraftTech.Commons;

namespace EyecraftTech.PicoHandler
{
    public class Pico
    {
        #region Singleton
        internal static string ComPort { get; private set; } = "";

        public static Pico Board { get; private set; }

        public static void Initialize()
        {
            if (Board != null)
            {
                throw new InvalidOperationException("The Pico Board was already instantiated!");
            }

            Board = new Pico();
        }

        #endregion Singleton

        private readonly SerialPort _serialPort;

        public bool IsBoardConnected = false;

        public StringEvent RawDataReceived;
        public ByteArrayEvent DataReceived;

        public VoidEvent HardwareConnected;
        public VoidEvent HardwareDisconnected;

        private Pico() 
        {
            _serialPort = new()
            {
                PortName = "COM-1",
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                //Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500,
                DtrEnable = true,
            };

            _serialPort.DataReceived += sp_DataReceived;
            _serialPort.ErrorReceived += sp_ErrorReceived;

            HardwareConnected += OnHardwareConnected;
            HardwareDisconnected += OnHardwareDisconnected;
        }

        private void OnHardwareDisconnected()
        {
            IsBoardConnected = false;
        }

        private void OnHardwareConnected()
        {
            IsBoardConnected = true;
        }

        public bool Connect(out string message)
        {
            if (string.IsNullOrEmpty(ComPort))
            {
                message = "No COM port available.";
                return false;
            }

            return Connect(ComPort, out message);
        }

        public bool Connect(string portName, out string message)
        {
            ComPort = portName;
            _serialPort.PortName = portName;

            message = "";

            try
            {
                if (!(_serialPort.IsOpen))
                {
                    _serialPort.Open();
                    message = "Connection established successfully.";

                    HardwareConnected?.Invoke();

                    return true;
                }
                else
                {
                    message = "Device port is already being used!";
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Disconnect(out string message)
        {
            message = "";

            if (IsBoardConnected == false) return false;

            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    message = "Connection to the device closed successfully.";
                    return true;
                }
                else
                {
                    message = "The device is not connected!";
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SendData(string data, out string message)
        {
            if (_serialPort.IsOpen == false)
            {
                message = "Pico Device isn't connected.";
                return false;
            }

            try
            {
                _serialPort.Write(data + "\r");
                message = "Data sent successfully.";
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void sp_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadLine().Trim();
                RawDataReceived?.Invoke(data);

                if (data.StartsWith("["))
                {
                    DataReceived?.Invoke(ProcessStringData(data));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

        public static byte[] ProcessStringData(string data)
        {
            data = data.Replace("[", "").Replace("]", "");

            string[] splitData = data.Split(", ");

            List<byte> finalData = [];

            foreach (string str in splitData)
            {
                finalData.Add(byte.Parse(str));
            }

            return [.. finalData];
        }
    }
}

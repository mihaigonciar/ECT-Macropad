using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EyecraftTech.PicoHandler
{
    public static class HardwareManager
    {
        public static void Initialize()
        {
            Pico.Initialize();

            TryConnectSerialPort();

            Task.Run(StartUsbMonitoring);
        }

        private static void StartUsbMonitoring()
        {
            try
            {
                // Watch for USB device connection or disconnection events
                var query = "SELECT * FROM __InstanceOperationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Name LIKE '%USB%'";

                using (var watcher = new ManagementEventWatcher(query))
                {
                    watcher.EventArrived += new EventArrivedEventHandler(DeviceEventArrived);
                    watcher.Start();

                    // Keep this running indefinitely in a background thread
                    Console.WriteLine("USB monitoring started. Listening for events...");

                    // Use a long sleep to simulate background work without blocking
                    while (true)
                    {
                        Task.Delay(10000).Wait(); // Avoid busy waiting
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static void DeviceEventArrived(object sender, EventArrivedEventArgs e)
        {
            var instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string deviceName = instance["Name"].ToString();
            string deviceID = instance["DeviceID"].ToString();

            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                if (Pico.Board.IsBoardConnected) return;

                OnDeviceConnected(deviceName, deviceID);
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
            {
                if (!Pico.Board.IsBoardConnected) return;

                OnDeviceRemoved(deviceName, deviceID);
            }
        }

        static void OnDeviceConnected(string deviceName, string deviceID)
        {
            Console.WriteLine($"Device Connected: {deviceName} ({deviceID})");

            if (GetComPort(deviceName, out string comPort))
            {
                Pico.Board.Connect(comPort, out string msg);
                Console.WriteLine(msg);
            }
        }

        static void OnDeviceRemoved(string deviceName, string deviceID)
        {
            Console.WriteLine($"Device Disconnected: {deviceName} ({deviceID})");

            if (GetComPort(deviceName, out string comPort))
            {
                if (comPort == Pico.ComPort)
                {
                    Pico.Board.HardwareDisconnected?.Invoke();
                }
            }
        }

        // This works as it should.
        static bool TryConnectSerialPort()
        {
            try
            {
                // Search for USB Serial Devices with specific VID and PID
                string query = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%USB Serial Device%' AND DeviceID LIKE '%VID_DDFD&PID_5050%'";

                using (ManagementObjectSearcher searcher = new(query))
                {
                    foreach (var device in searcher.Get())
                    {
                        Console.WriteLine($"Found Device: {device["Name"]}");
                        Console.WriteLine($"Device ID: {device["DeviceID"]}");

                        //string comPort = (string)device["DeviceID"];

                        if (GetComPort((string)device["Name"], out string comResult))
                        {
                            Console.WriteLine($"Associated COM Port: {comResult}");

                            if (!Pico.Board.Connect(comResult, out string message))
                            {
                                Console.WriteLine(message);
                            }

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }

            return false;
        }

        private static bool GetComPort(string deviceName, out string comPort)
        {
            comPort = "";
            Match match = Regex.Match(deviceName, @"COM\d+");

            if (match.Success)
            {
                comPort = match.Value;
                return true;
            }

            return false;
        }

    }
}

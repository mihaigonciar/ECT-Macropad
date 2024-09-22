namespace EyecraftTech.Devices
{
    // Some examples:
    // A button needs 1 bit (0 - 1)
    // a linear encoder uses an entire byte (0-255)
    // a joystick might use either 1 or 2 bytes (or more!) per axis, depending on the agreed signal quality.

    public enum DataReadMode
    {
        /// <summary>
        /// Read a single bit from a byte.
        /// </summary>
        Bit,
        /// <summary>
        /// Read multiple bits from one byte.
        /// </summary>
        Bits,
        /// <summary>
        /// Read an entire byte.
        /// </summary>
        Byte,
        /// <summary>
        /// Read multiple bytes.
        /// </summary>
        Bytes
    }

    public abstract class BoardModuleBase
    {
        public readonly string ID;
        public readonly BoardBase Board;
        protected readonly DataReadMode _dataReadMode;
        protected readonly int[] _bytesIndices;
        protected readonly int[] _bitsIndices;

        // A module can repond to (separate cases):
        // 1 - a bit in a byte
        // 2 - multiple bits in a byte
        // 3 - entire byte
        // 4 - multiple bytes

        public BoardModuleBase(BoardBase board, string id, DataReadMode readMode, int[] byteIndices, int[] bitIndices)
        {
            ID = id;
            Board = board;
            Board.Modules.Add(this);

            _dataReadMode = readMode;
            _bytesIndices = byteIndices;
            _bitsIndices = bitIndices;
        }

        public abstract void ProcessData(byte[] data);
    }
}

using System.Drawing;

namespace EyecraftTech.Commons
{
    public delegate void VoidEvent();
    public delegate void BoolEvent(bool state);
    public delegate void IntEvent(int val);
    public delegate void StringEvent(string str);
    public delegate void ByteEvent(byte data);
    public delegate void ByteArrayEvent(byte[] bytes);
    public delegate void ColorEvent(Color color, float brightness);
}

using System.Runtime.Serialization;

namespace EyecraftTech.Devices
{
    public interface IAction
    {
        string Description { get; }
        void Execute();
    }
}

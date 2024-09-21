using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyecraftTech.Commons
{
    public static class Utils
    {
        public static bool IsBitSet(byte b, int pos) => (b & (1 << pos)) != 0;
    }
}

using System.Runtime.InteropServices;

namespace Rowan.Boot
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MultibootElfSection
    {
        public uint Num;
        public uint Size;
        public uint Addr;
        public uint Shndx;
    }
}
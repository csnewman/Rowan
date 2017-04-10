using System.Runtime.InteropServices;

namespace Rowan.Boot
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MultibootElfSection
    {
        public uint Num;
        public uint Size;
        public uint Addr;
        public uint Shndx;
    }
}
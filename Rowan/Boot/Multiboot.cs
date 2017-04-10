using System.Runtime.InteropServices;

namespace Rowan.Boot
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Multiboot
    {
        public uint Flags;
        public uint MemLower;
        public uint MemUpper;
        public uint BootDevice;
        public uint CommandLine;
        public uint ModsCount;
        public uint ModsAddress;
        public MultibootElfSection ElfSection;
        public uint MmapLength;
        public uint MmapAddress;
        public uint DrivesLength;
        public uint DrivesAddress;
        public uint ConfigTable;
        public uint BootLoaderName;
        public uint ApmTable;
        public uint VbeControlInfo;
        public uint VbeModeInfo;
        public ushort VbeMode;
        public ushort VbeInterfaceSeg;
        public ushort VbeInterfaceOff;
        public ushort VbeInterfaceLen;
    }
}
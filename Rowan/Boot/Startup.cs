using System;
using Rowan.Video;

namespace Rowan.Boot
{
    public static unsafe class Startup
    {
        public static void Start(Multiboot* mboot, int magic, UIntPtr esp)
        {
            BiosVideo.Init();

            //Print name
            BiosVideo.Print('R');
            BiosVideo.Print('o');
            BiosVideo.Print('w');
            BiosVideo.Print('a');
            BiosVideo.Print('n');
            BiosVideo.Print(' ');
            BiosVideo.Print('V');
            BiosVideo.Print('1');
            BiosVideo.Print('.');
            BiosVideo.Print('0');
            BiosVideo.Print(' ');

            //Print whether grub has been detected
            bool grubFound = magic == 0x2BADB002;
            BiosVideo.SetColors(grubFound ? VgaColor.Green : VgaColor.Red, VgaColor.Black);
            BiosVideo.Print('G');
            BiosVideo.Print('R');
            BiosVideo.Print('U');
            BiosVideo.Print('B');
            BiosVideo.Print('\n');
            BiosVideo.SetColors(VgaColor.White, VgaColor.Black);

            //Exit if grub is missing
            if (!grubFound) return;
        }
    }
}
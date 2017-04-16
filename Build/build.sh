nasm -f elf ./loader.s
ld -T link.ld -melf_i386  `find . -name "*.o" -type f` -o kernel.elf
cp ./kernel.elf ./iso/boot/kernel.elf
genisoimage -R -b boot/grub/stage2_eltorito -no-emul-boot -boot-load-size 4 -A os  -input-charset utf8 -quiet -boot-info-table -o os.iso iso
rm  `find . -name "*.o" -type f`
rm kernel.elf
rm ./iso/boot/kernel.elf
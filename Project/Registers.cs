using System.Runtime.InteropServices;

namespace ByteTerrace.Emulation.GameBoy;

[StructLayout(layoutKind: LayoutKind.Explicit)]
struct Registers
{
    [FieldOffset(offset: 1)]
    public byte A;
    [FieldOffset(offset: 0)]
    public ushort AF;
    [FieldOffset(offset: 3)]
    public byte B;
    [FieldOffset(offset: 2)]
    public ushort BC;
    [FieldOffset(offset: 2)]
    public byte C;
    [FieldOffset(offset: 5)]
    public byte D;
    [FieldOffset(offset: 4)]
    public ushort DE;
    [FieldOffset(offset: 4)]
    public byte E;
    [FieldOffset(offset: 0)]
    public byte F;
    [FieldOffset(offset: 6)]
    public ushort HL;
    [FieldOffset(offset: 7)]
    public byte H;
    [FieldOffset(offset: 6)]
    public byte L;
    [FieldOffset(offset: 10)]
    public ushort PC;
    [FieldOffset(offset: 8)]
    public ushort SP;
}

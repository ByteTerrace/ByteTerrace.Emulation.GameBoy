using CommunityToolkit.HighPerformance.Helpers;

namespace ByteTerrace.Emulation.GameBoy;

public static class ArithmeticLogicUnit
{
    private const int IndexC = 4;
    private const int IndexH = 5;
    private const int IndexN = 6;
    private const int IndexZ = 7;

    public static byte Adc(this byte value, byte other, ref uint flags) {
        var carry = (flags & 0x10);
        var sum = (value + other + carry);
        var result = (sum & 0xFF);
        var z = Convert.ToByte(value: (0 == result));
        var n = 0;
        var h = Convert.ToByte(value: (((value & 0x0F) + (other & 0x0F) + carry) > 0x0F));
        var c = Convert.ToByte(value: (sum > 0xFF));

        flags = ((byte)(
            (z << IndexZ)
          | (n << IndexN)
          | (h << IndexH)
          | (c << IndexC)
        ));

        return value;
    }
    public static byte Add(this byte value, byte other, ref uint flags) {
        var sum = (value + other);
        var result = (sum & 0xFF);
        var z = Convert.ToByte(value: (0 == result));
        var n = 0;
        var h = Convert.ToByte(value: (((value & 0x0F) + (other & 0x0F)) > 0x0F));
        var c = Convert.ToByte(value: (sum > 0xFF));

        flags = ((byte)(
            (z << IndexZ)
          | (n << IndexN)
          | (h << IndexH)
          | (c << IndexC)
        ));

        return ((byte)result);
    }
    public static ushort Add(this ushort value, ushort other, ref uint flags) {
        var sum = (value + other);
        var result = (sum & 0xFFFF);
        var n = false;
        var h = (((value & 0x0FFF) + (other & 0x0FFF)) > 0x0FFF);
        var c = (sum > 0xFFFF);

        BitHelper.SetFlag(flag: n, n: IndexN, value: ref flags);
        BitHelper.SetFlag(flag: h, n: IndexH, value: ref flags);
        BitHelper.SetFlag(flag: c, n: IndexC, value: ref flags);

        return ((ushort)result);
    }
    public static byte And(this byte value, byte other, ref uint flags) {
        var result = (value & other);

        flags = ((byte)(32 | (Convert.ToByte(value: (0 == result)) << 7)));

        return ((byte)result);
    }
    public static void Ccf(ref uint flags) {
        BitHelper.SetFlag(flag: false, n: IndexN, value: ref flags);
        BitHelper.SetFlag(flag: false, n: IndexH, value: ref flags);
        BitHelper.SetFlag(flag: !BitHelper.HasFlag(n: IndexC, value: flags), n: IndexC, value: ref flags);
    }
    public static void Cp(this byte value, byte other, ref uint flags) {
        var z = Convert.ToByte(value: (0 == ((value - other) & 0xFF)));
        var n = 1;
        var h = Convert.ToByte(value: ((other & 0xF) > (value & 0xF)));
        var c = Convert.ToByte(value: (other > value));

        flags = ((byte)(
            (z << IndexZ)
          | (n << IndexN)
          | (h << IndexH)
          | (c << IndexC)
        ));
    }
    public static byte Cpl(this byte value, ref uint flags) {
        BitHelper.SetFlag(flag: true, n: IndexN, value: ref flags);
        BitHelper.SetFlag(flag: true, n: IndexH, value: ref flags);

        return ((byte)~value);
    }
    public static byte Daa(this byte value, ref uint flags) {
        if (BitHelper.HasFlag(n: IndexN, value: flags)) {
            if (BitHelper.HasFlag(n: IndexC, value: flags)) {
                value -= 0x60;
            }
            if (BitHelper.HasFlag(n: IndexH, value: flags)) {
                value -= 0x6;
            }
        }
        else {
            if (BitHelper.HasFlag(n: IndexC, value: flags) || (value > 0x99)) {
                value += 0x60;

                BitHelper.SetFlag(flag: true, n: IndexC, value: ref flags);
            }
            if (BitHelper.HasFlag(n: IndexH, value: flags) || ((value & 0x0F) > 0x09)) {
                value += 0x6;
            }
        }

        BitHelper.SetFlag(flag: (0 == value), n: IndexZ, value: ref flags);
        BitHelper.SetFlag(flag: false, n: IndexH, value: ref flags);

        return value;
    }
    public static byte Dec(this byte value, ref uint flags) {
        var result = ((value - 1) & 0xFF);
        var z = (0 == result);
        var n = true;
        var h = (0xF == (value & 0xF));

        BitHelper.SetFlag(flag: z, n: IndexZ, value: ref flags);
        BitHelper.SetFlag(flag: n, n: IndexN, value: ref flags);
        BitHelper.SetFlag(flag: h, n: IndexH, value: ref flags);

        return ((byte)result);
    }
    public static byte Inc(this byte value, ref uint flags) {
        var result = ((value + 1) & 0xFF);
        var z = (0 == result);
        var n = false;
        var h = (0xF == (value & 0xF));

        BitHelper.SetFlag(flag: z, n: IndexZ, value: ref flags);
        BitHelper.SetFlag(flag: n, n: IndexN, value: ref flags);
        BitHelper.SetFlag(flag: h, n: IndexH, value: ref flags);

        return ((byte)result);
    }
    public static byte Or(this byte value, byte other, ref uint flags) {
        var result = (value | other);

        flags = ((byte)(Convert.ToByte(value: (0 == result)) << IndexZ));

        return ((byte)result);
    }
    public static byte Sbc(this byte value, byte other, ref uint flags) {
        var carry = (flags & 0x10);
        var result = ((value - other - carry) & 0xFF);
        var z = Convert.ToByte(value: (0 == result));
        var n = 1;
        var h = Convert.ToByte(value: (0 != ((value ^ other ^ (result & 0xFF)) & 0x10)));
        var c = Convert.ToByte(value: (0 > result));

        flags = ((byte)(
            (z << IndexZ)
          | (n << IndexN)
          | (h << IndexH)
          | (c << IndexC)
        ));

        return ((byte)result);
    }
    public static void Scf(ref uint flags) {
        BitHelper.SetFlag(flag: false, n: IndexN, value: ref flags);
        BitHelper.SetFlag(flag: false, n: IndexH, value: ref flags);
        BitHelper.SetFlag(flag: true, n: IndexC, value: ref flags);
    }
    public static byte Sub(this byte value, byte other, ref uint flags) {
        var result = ((value - other) & 0xFF);
        var z = Convert.ToByte(value: (0 == result));
        var n = 1;
        var h = Convert.ToByte(value: ((other & 0xF) > (value & 0xF)));
        var c = Convert.ToByte(value: (other > value));

        flags = ((byte)(
            (z << IndexZ)
          | (n << IndexN)
          | (h << IndexH)
          | (c << IndexC)
        ));

        return ((byte)result);
    }
    public static byte Xor(this byte value, byte other, ref uint flags) {
        var result = ((value ^ other) & 0xFF);

        flags = ((byte)(Convert.ToByte(value: (0 == result)) << IndexZ));

        return ((byte)result);
    }
}

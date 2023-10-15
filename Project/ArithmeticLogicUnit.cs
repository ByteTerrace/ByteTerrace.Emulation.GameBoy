﻿using CommunityToolkit.HighPerformance.Helpers;

namespace ByteTerrace.Emulation.GameBoy;

public static class ArithmeticLogicUnit
{
    public static byte Adc(this byte value, byte other, ref uint flags) {
        var carry = (flags & 0x10);
        var sum = (value + other + carry);
        var result = (sum & 0xFF);
        var z = Convert.ToByte(value: (0 == result));
        var n = 0;
        var h = Convert.ToByte(value: (((value & 0x0F) + (other & 0x0F) + carry) > 0x0F));
        var c = Convert.ToByte(value: (sum > 0xFF));

        flags = ((byte)(
            (z << 7)
          | (n << 6)
          | (h << 5)
          | (c << 4)
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
            (z << 7)
          | (n << 6)
          | (h << 5)
          | (c << 4)
        ));

        return ((byte)result);
    }
    public static byte And(this byte value, byte other, ref uint flags) {
        var result = (value & other);

        flags = ((byte)(32 | (Convert.ToByte(value: (0 == result)) << 7)));

        return ((byte)result);
    }
    public static byte Inc(this byte value, ref uint flags) {
        var result = ((value + 1) & 0xFF);
        var z = (0 == result);
        var n = false;
        var h = (0xF == (value & 0xF));

        BitHelper.SetFlag(flag: z, n: 7, value: ref flags);
        BitHelper.SetFlag(flag: n, n: 6, value: ref flags);
        BitHelper.SetFlag(flag: h, n: 5, value: ref flags);

        return ((byte)result);
    }
    public static byte Or(this byte value, byte other, ref uint flags) {
        var result = (value | other);

        flags = ((byte)(Convert.ToByte(value: (0 == result)) << 7));

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
            (z << 7)
          | (n << 6)
          | (h << 5)
          | (c << 4)
        ));

        return ((byte)result);
    }
    public static byte Sub(this byte value, byte other, ref uint flags) {
        var result = ((value - other) & 0xFF);
        var z = Convert.ToByte(value: (0 == result));
        var n = 1;
        var h = Convert.ToByte(value: ((other & 0xF) > (value & 0xF)));
        var c = Convert.ToByte(value: (other > value));

        flags = ((byte)(
            (z << 7)
          | (n << 6)
          | (h << 5)
          | (c << 4)
        ));

        return ((byte)result);
    }
    public static byte Xor(this byte value, byte other, ref uint flags) {
        var result = ((value ^ other) & 0xFF);

        flags = ((byte)(Convert.ToByte(value: (0 == result)) << 7));

        return ((byte)result);
    }
}
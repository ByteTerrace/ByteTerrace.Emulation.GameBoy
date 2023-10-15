namespace ByteTerrace.Emulation.GameBoy;

public static class ArithmeticLogicUnit
{
    public static byte Add(this byte value, byte other, out byte flags) {
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
        )); ;

        return ((byte)result);
    }
    public static byte And(this byte value, byte other, out byte flags) {
        var result = (value & other);

        flags = ((byte)(32 | (Convert.ToByte(value: (0 == result)) << 7)));

        return ((byte)result);
    }
    public static byte Or(this byte value, byte other, out byte flags) {
        var result = (value | other);

        flags = ((byte)(Convert.ToByte(value: (0 == result)) << 7));

        return ((byte)result);
    }
    public static byte Sub(this byte value, byte other, out byte flags) {
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
        )); ;

        return ((byte)result);
    }
    public static byte Xor(this byte value, byte other, out byte flags) {
        var result = ((value ^ other) & 0xFF);

        flags = ((byte)(Convert.ToByte(value: (0 == result)) << 7));

        return ((byte)result);
    }
}

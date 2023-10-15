namespace ByteTerrace.Emulation.GameBoy;

sealed class Flags
{
    private Registers m_registers;

    private byte Value {
        get => m_registers.F;
    }

    public bool C {
        get => Convert.ToBoolean(value: (Value & 0b00010000));
    }
    public bool H {
        get => Convert.ToBoolean(value: (Value & 0b00100000));
    }
    public bool N {
        get => Convert.ToBoolean(value: (Value & 0b01000000));
    }
    public bool Z {
        get => Convert.ToBoolean(value: (Value & 0b10000000));
    }

    public Flags(Registers registers) {
        m_registers = registers;
    }
}

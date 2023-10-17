namespace ByteTerrace.Emulation.GameBoy;

sealed class Memory
{
    private readonly byte[] m_value;

    public ref byte this[int index] => ref m_value[index];
    public ref byte BootRomControlRegister { get => ref m_value.AsSpan()[65360..65361][0]; }
    public ref byte DividerRegister { get => ref m_value.AsSpan()[65284..65285][0]; }
    public Span<byte> EchoRam { get => m_value.AsSpan()[57344..65024]; }
    public Span<byte> ExternalRam { get => m_value.AsSpan()[40960..49152]; }
    public Span<byte> HighRam { get => m_value.AsSpan()[65408..65535]; }
    public ref byte InterruptAssertedRegister { get => ref m_value.AsSpan()[65295..65296][0]; }
    public ref byte InterruptEnableRegister { get => ref m_value.AsSpan()[65535..][0]; }
    public ref byte JoypadRegister { get => ref m_value.AsSpan()[65280..65281][0]; }
    public Span<byte> IoRegisters { get => m_value.AsSpan()[65280..65408]; }
    public Span<byte> NotUsable { get => m_value.AsSpan()[65184..65280]; }
    public Span<byte> ObjectAttributeMemory { get => m_value.AsSpan()[65024..65184]; }
    public ref byte PictureProcessingUnitStatusRegister { get => ref m_value.AsSpan()[65345..65346][0]; }
    public Span<byte> RomBankA { get => m_value.AsSpan()[0..16384]; }
    public Span<byte> RomBankB { get => m_value.AsSpan()[16384..32768]; }
    public ref byte TimerControlRegister { get => ref m_value.AsSpan()[65287..65288][0]; }
    public ref byte TimerCounterRegister { get => ref m_value.AsSpan()[65285..65286][0]; }
    public ref byte TimerModuloRegister { get => ref m_value.AsSpan()[65286..65287][0]; }
    public Span<byte> VideoRam { get => m_value.AsSpan()[32768..40960]; }
    public Span<byte> WorkRamA { get => m_value.AsSpan()[49152..53248]; }
    public Span<byte> WorkRamB { get => m_value.AsSpan()[53248..57344]; }

    public Memory() {
        m_value = new byte[(ushort.MaxValue + 1)];
    }

    public byte ReadPort(byte port) {
        switch (port) {
            case 0x00: // JOYP
                return JoypadRegister;
            case 0x04: // DIV
                return DividerRegister;
            case 0x05: // TIMA
                return TimerCounterRegister;
            case 0x06: // TMA
                return TimerModuloRegister;
            case 0x07: // TAC
                return TimerControlRegister;
            case 0x0F: // IF
                return InterruptAssertedRegister;
            case 0x41: // STAT
                return PictureProcessingUnitStatusRegister;
            case 0x46: // DMA
                throw new NotImplementedException();
            case 0x4D: // KEY1
                throw new NotImplementedException();
            case 0x50: // BOOT
                return BootRomControlRegister;
            case 0xFF: // IE
                return InterruptEnableRegister;
            default:
                throw new NotImplementedException();
        }
    }
    public void WritePort(byte port, byte value) {
        switch (port) {
            case 0x00: // JOYP (11XXYYYY)
                JoypadRegister = ((byte)(0b11000000 | (value & 0b00110000) | (JoypadRegister & 0b00001111)));
                break;
            case 0x04: // DIV
                DividerRegister = 0;
                break;
            case 0x05: // TIMA
                TimerCounterRegister = value;
                break;
            case 0x06: // TMA
                TimerModuloRegister = value;
                break;
            case 0x07: // TAC (11111XXX)
                TimerControlRegister = ((byte)(0b11111000 | (value & 0b00000111)));
                break;
            case 0x0F: // IF (111XXXXX)
                InterruptAssertedRegister = ((byte)(0b11100000 | (value & 0b00011111)));
                break;
            case 0x41: // STAT (1XXXXYYY)
                PictureProcessingUnitStatusRegister = (byte)(0b10000000 | (value & 0b01111000) | (PictureProcessingUnitStatusRegister & 0b00000111));
                break;
            case 0x46: // DMA
                throw new NotImplementedException();
            case 0x4D: // KEY1
                throw new NotImplementedException();
            case 0x50: // BOOT (1111111X)
                BootRomControlRegister = ((byte)(0x11111110 | (value & 0b00000001)));
                break;
            case 0xFF: // IE (111XXXXX)
                InterruptEnableRegister = ((byte)(0b11100000 | (value & 0b00011111)));
                break;
            default:
                throw new NotImplementedException();
        }
    }
}

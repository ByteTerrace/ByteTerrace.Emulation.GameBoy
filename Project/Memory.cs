namespace ByteTerrace.Emulation.GameBoy;

sealed class Memory
{
    private readonly byte[] m_value;

    public ref byte this[int index] => ref m_value[index];
    public Span<byte> EchoRam { get => m_value.AsSpan()[57344..65024]; }
    public Span<byte> ExternalRam { get => m_value.AsSpan()[40960..49152]; }
    public Span<byte> HighRam { get => m_value.AsSpan()[65408..65535]; }
    public Span<byte> InterruptEnableRegister { get => m_value.AsSpan()[65535..]; }
    public Span<byte> IoRegisters { get => m_value.AsSpan()[65280..65408]; }
    public Span<byte> NotUsable { get => m_value.AsSpan()[65184..65280]; }
    public Span<byte> ObjectAttributeMemory { get => m_value.AsSpan()[65024..65184]; }
    public Span<byte> RomBankA { get => m_value.AsSpan()[0..16384]; }
    public Span<byte> RomBankB { get => m_value.AsSpan()[16384..32768]; }
    public Span<byte> VideoRam { get => m_value.AsSpan()[32768..40960]; }
    public Span<byte> WorkRamA { get => m_value.AsSpan()[49152..53248]; }
    public Span<byte> WorkRamB { get => m_value.AsSpan()[53248..57344]; }

    public Memory() {
        m_value = new byte[(ushort.MaxValue + 1)];
    }
}

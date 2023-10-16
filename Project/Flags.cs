using CommunityToolkit.HighPerformance.Helpers;

namespace ByteTerrace.Emulation.GameBoy;

sealed class Flags
{
    private bool m_interruptMasterEnableFlag;
    private Registers m_registers;

    private uint Value {
        get => m_registers.F;
    }

    public bool C {
        get => BitHelper.HasFlag(n: 4, value: Value);
    }
    public bool H {
        get => BitHelper.HasFlag(n: 5, value: Value);
    }
    public bool IME {
        get => m_interruptMasterEnableFlag;
    }
    public bool N {
        get => BitHelper.HasFlag(n: 6, value: Value);
    }
    public bool Z {
        get => BitHelper.HasFlag(n: 7, value: Value);
    }

    public Flags(Registers registers) {
        m_interruptMasterEnableFlag = false;
        m_registers = registers;
    }

    public void ClearIme() {
        m_interruptMasterEnableFlag = false;
    }
    public void SetIme() {
        m_interruptMasterEnableFlag = true;
    }
}

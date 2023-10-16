using CommunityToolkit.HighPerformance.Helpers;

namespace ByteTerrace.Emulation.GameBoy;

sealed class FlagsHelper
{
    public static bool GetC(Registers registers) {
        return BitHelper.HasFlag(n: 4, value: registers.F);
    }
    public static bool GetH(Registers registers) {
        return BitHelper.HasFlag(n: 5, value: registers.F);
    }
    public static bool GetN(Registers registers) {
        return BitHelper.HasFlag(n: 6, value: registers.F);
    }
    public static bool GetZ(Registers registers) {
        return BitHelper.HasFlag(n: 7, value: registers.F);
    }

    private bool m_interruptMasterEnabledFlag;
    private bool m_isImeOperationScheduled;

    public FlagsHelper() {
        m_interruptMasterEnabledFlag = false;
        m_isImeOperationScheduled = false;
    }

    public void ClearIme() {
        m_interruptMasterEnabledFlag = false;
    }
    public void ClearImeOperationIsScheduled() {
        m_isImeOperationScheduled = false;
    }
    public bool GetIme() {
        return m_interruptMasterEnabledFlag;
    }
    public bool GetImeOperationIsScheduled() {
        return m_isImeOperationScheduled;
    }
    public void SetIme() {
        m_interruptMasterEnabledFlag = true;
    }
    public void SetImeOperationIsScheduled() {
        m_isImeOperationScheduled = true;
    }
}

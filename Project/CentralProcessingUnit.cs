namespace ByteTerrace.Emulation.GameBoy;

sealed class CentralProcessingUnit
{
    private uint m_tickCount;
    private Registers m_registers;

    public byte Accumulator { get => m_registers.A; }
    public Flags Flags { get; }
    public Memory Memory { get; }
    public ushort ProgramCounter { get => m_registers.PC; }
    public ushort StackPointer { get => m_registers.SP; }

    public CentralProcessingUnit() {
        var clockCycle = 0U;
        var memory = new Memory();
        var registers = new Registers();

        m_tickCount = clockCycle;
        m_registers = registers;

        Flags = new Flags(registers: registers);
        Memory = memory;
    }

    public bool MoveNext() {
        var flags = 0U;
        var memory = Memory;
        var programCounter = ProgramCounter;
        var registers = m_registers;
        var tickCount = ++m_tickCount;

        switch (memory[index: programCounter]) {
            case 0x00: // NOOP
                break;
            case 0x07: // RLCA
                break;
            case 0x0F: // RRCA
                break;
            case 0x10: // STOP
                break;
            case 0x17: // RLA
                break;
            case 0x1F: // RRA
                break;
            case 0x27: // DAA
                break;
            case 0x2F: // CPL
                break;
            case 0x34: // INC HL
                break;
            case 0x35: // DEC HL
                break;
            case 0x76: // HALT
                break;
            case 0x80: // ADD B
                registers.A = registers.A.Add(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x81: // ADD C
                registers.A = registers.A.Add(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x82: // ADD D
                registers.A = registers.A.Add(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x83: // ADD E
                registers.A = registers.A.Add(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x84: // ADD H
                registers.A = registers.A.Add(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x85: // ADD L
                registers.A = registers.A.Add(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x86: // ADD HL
                break;
            case 0x87: // ADD A
                registers.A = registers.A.Add(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0x88: // ADC B
                registers.A = registers.A.Adc(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x89: // ADC C
                registers.A = registers.A.Adc(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x8A: // ADC D
                registers.A = registers.A.Adc(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x8B: // ADC E
                registers.A = registers.A.Adc(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x8C: // ADC H
                registers.A = registers.A.Adc(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x8D: // ADC L
                registers.A = registers.A.Adc(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x8E: // ADC HL
                break;
            case 0x8F: // ADC A
                registers.A = registers.A.Adc(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0x90: // SUB B
                registers.A = registers.A.Sub(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x91: // SUB C
                registers.A = registers.A.Sub(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x92: // SUB D
                registers.A = registers.A.Sub(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x93: // SUB E
                registers.A = registers.A.Sub(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x94: // SUB H
                registers.A = registers.A.Sub(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x95: // SUB L
                registers.A = registers.A.Sub(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x96: // SUB HL
                break;
            case 0x97: // SUB A
                registers.A = registers.A.Sub(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0x98: // SBC B
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x99: // SBC C
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x9A: // SBC D
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x9B: // SBC E
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x9C: // SBC H
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x9D: // SBC L
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x9E: // SBC HL
                break;
            case 0x9F: // SBC A
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xA0: // AND B
                registers.A = registers.A.And(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xA1: // AND C
                registers.A = registers.A.And(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xA2: // AND D
                registers.A = registers.A.And(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xA3: // AND E
                registers.A = registers.A.And(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xA4: // AND H
                registers.A = registers.A.And(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xA5: // AND L
                registers.A = registers.A.And(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xA6: // AND HL
                break;
            case 0xA7: // AND A
                registers.A = registers.A.And(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xA8: // XOR B
                registers.A = registers.A.Xor(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xA9: // XOR C
                registers.A = registers.A.Xor(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xAA: // XOR D
                registers.A = registers.A.Xor(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xAB: // XOR E
                registers.A = registers.A.Xor(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xAC: // XOR H
                registers.A = registers.A.Xor(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xAD: // XOR L
                registers.A = registers.A.Xor(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xAE: // XOR HL
                break;
            case 0xAF: // XOR A
                registers.A = registers.A.Xor(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xB0: // OR B
                registers.A = registers.A.Or(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xB1: // OR C
                registers.A = registers.A.Or(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xB2: // OR D
                registers.A = registers.A.Or(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xB3: // OR E
                registers.A = registers.A.Or(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xB4: // OR H
                registers.A = registers.A.Or(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xB5: // OR L
                registers.A = registers.A.Or(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xB6: // OR HL
                break;
            case 0xB7: // OR A
                registers.A = registers.A.Or(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xBE: // CP HL
                break;
            case 0xC6: // ADD N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Add(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xC9: // RET
                break;
            case 0xCB: // ???
                programCounter = registers.IncrementProgramCounter();

                switch (memory[index: programCounter]) {
                    case 0x0E: // RRC HL
                        break;
                    case 0x1E: // RR HL
                        break;
                    case 0x2E: // SRA HL
                        break;
                    case 0x3E: // SRL HL
                        break;
                    default:
                        throw new NotSupportedException();
                }
                break;
            case 0xCE: // ADC N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Adc(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xD6: // SUB N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Sub(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xD9: // RETI
                break;
            case 0xDE: // SBC N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Sbc(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xE6: // AND N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.And(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xEE: // XOR N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Xor(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xF3: // DI
                break;
            case 0xF6: // OR N
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Or(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xFB: // EI
                break;
            default:
                throw new NotSupportedException();
        }

        return true;
    }
}

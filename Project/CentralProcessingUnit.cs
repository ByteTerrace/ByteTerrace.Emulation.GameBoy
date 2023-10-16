namespace ByteTerrace.Emulation.GameBoy;

sealed class CentralProcessingUnit
{
    private Registers m_registers;
    private uint m_tickCount;

    public byte Accumulator { get => m_registers.A; }
    public Flags Flags { get; }
    public Memory Memory { get; }
    public ushort ProgramCounter { get => m_registers.PC; }
    public ushort StackPointer { get => m_registers.SP; }
    public uint TickCount { get => m_tickCount; }

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
            case 0x02: // LD (BC), A
                memory[index: registers.BC] = registers.A;
                break;
            case 0x04: // INC B
                registers.B = registers.B.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x05: // DEC B
                registers.B = registers.B.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x06: // LD B, D8
                programCounter = registers.IncrementProgramCounter();
                registers.B = memory[index: programCounter];
                break;
            case 0x07: // RLCA
                break;
            case 0x0A: // LD A, (BC)
                registers.A = memory[index: registers.BC];
                break;
            case 0x0C: // INC C
                registers.C = registers.C.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x0D: // DEC C
                registers.C = registers.C.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x0E: // LD C, D8
                programCounter = registers.IncrementProgramCounter();
                registers.C = memory[index: programCounter];
                break;
            case 0x0F: // RRCA
                break;
            case 0x10: // STOP
                break;
            case 0x12: // LD (DE), A
                memory[index: registers.DE] = registers.A;
                break;
            case 0x14: // INC D
                registers.D = registers.D.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x15: // DEC D
                registers.D = registers.D.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x16: // LD D, D8
                programCounter = registers.IncrementProgramCounter();
                registers.D = memory[index: programCounter];
                break;
            case 0x17: // RLA
                break;
            case 0x1A: // LD A, (DE)
                registers.A = memory[index: registers.DE];
                break;
            case 0x1C: // INC E
                registers.E = registers.E.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x1D: // DEC E
                registers.E = registers.E.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x1E: // LD E, D8
                programCounter = registers.IncrementProgramCounter();
                registers.E = memory[index: programCounter];
                break;
            case 0x1F: // RRA
                break;
            case 0x24: // INC H
                registers.H = registers.H.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x25: // DEC H
                registers.H = registers.H.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x26: // LD H, D8
                programCounter = registers.IncrementProgramCounter();
                registers.H = memory[index: programCounter];
                break;
            case 0x27: // DAA
                break;
            case 0x29: // ADD HL, HL
                break;
            case 0x2C: // INC L
                registers.L = registers.L.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x2D: // DEC L
                registers.L = registers.L.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x2E: // LD L, D8
                programCounter = registers.IncrementProgramCounter();
                registers.L = memory[index: programCounter];
                break;
            case 0x2F: // CPL
                break;
            case 0x34: // INC (HL)
                break;
            case 0x35: // DEC (HL)
                break;
            case 0x36: // LD (HL), D8
                break;
            case 0x37: // SCF
                break;
            case 0x3C: // INC A
                registers.A = registers.A.Inc(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x3D: // DEC A
                registers.A = registers.A.Dec(ref flags);
                registers.F = ((byte)flags);
                break;
            case 0x3E: // LD A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = memory[index: programCounter];
                break;
            case 0x3F: // CCF
                break;
            case 0x40: // LD B, B
                break;
            case 0x41: // LD B, C
                registers.B = registers.C;
                break;
            case 0x42: // LD B, D
                registers.B = registers.D;
                break;
            case 0x43: // LD B, E
                registers.B = registers.E;
                break;
            case 0x44: // LD B, H
                registers.B = registers.H;
                break;
            case 0x45: // LD B, L
                registers.B = registers.L;
                break;
            case 0x46: // LD B, (HL)
                registers.B = memory[index: registers.HL];
                break;
            case 0x47: // LD B, A
                registers.B = registers.A;
                break;
            case 0x48: // LD C, B
                registers.C = registers.B;
                break;
            case 0x49: // LD C, C
                break;
            case 0x4A: // LD C, D
                registers.C = registers.D;
                break;
            case 0x4B: // LD C, E
                registers.C = registers.E;
                break;
            case 0x4C: // LD C, H
                registers.C = registers.H;
                break;
            case 0x4D: // LD C, L
                registers.C = registers.L;
                break;
            case 0x4E: // LD C, (HL)
                registers.C = memory[index: registers.HL];
                break;
            case 0x4F: // LD C, A
                registers.C = registers.A;
                break;
            case 0x50: // LD D, B
                registers.D = registers.B;
                break;
            case 0x51: // LD D, C
                registers.D = registers.C;
                break;
            case 0x52: // LD D, D
                break;
            case 0x53: // LD D, E
                registers.D = registers.E;
                break;
            case 0x54: // LD D, H
                registers.D = registers.H;
                break;
            case 0x55: // LD D, L
                registers.D = registers.L;
                break;
            case 0x56: // LD D, (HL)
                registers.D = memory[index: registers.HL];
                break;
            case 0x57: // LD D, A
                registers.D = registers.A;
                break;
            case 0x58: // LD E, B
                registers.E = registers.B;
                break;
            case 0x59: // LD E, C
                registers.E = registers.C;
                break;
            case 0x5A: // LD E, D
                registers.E = registers.D;
                break;
            case 0x5B: // LD E, E
                break;
            case 0x5C: // LD E, H
                registers.E = registers.H;
                break;
            case 0x5D: // LD E, L
                registers.E = registers.L;
                break;
            case 0x5E: // LD E, (HL)
                registers.E = memory[index: registers.HL];
                break;
            case 0x5F: // LD E, A
                registers.E = registers.A;
                break;
            case 0x60: // LD H, B
                registers.H = registers.B;
                break;
            case 0x61: // LD H, C
                registers.H = registers.C;
                break;
            case 0x62: // LD H, D
                registers.H = registers.D;
                break;
            case 0x63: // LD H, E
                registers.H = registers.E;
                break;
            case 0x64: // LD H, H
                break;
            case 0x65: // LD H, L
                registers.H = registers.L;
                break;
            case 0x66: // LD H, (HL)
                registers.H = memory[index: registers.HL];
                break;
            case 0x67: // LD H, A
                registers.H = registers.A;
                break;
            case 0x68: // LD L, B
                registers.L = registers.B;
                break;
            case 0x69: // LD L, C
                registers.L = registers.C;
                break;
            case 0x6A: // LD L, D
                registers.L = registers.D;
                break;
            case 0x6B: // LD L, E
                registers.L = registers.E;
                break;
            case 0x6C: // LD L, H
                registers.L = registers.H;
                break;
            case 0x6D: // LD L, L
                break;
            case 0x6E: // LD L, (HL)
                registers.L = memory[index: registers.HL];
                break;
            case 0x6F: // LD L, A
                registers.L = registers.A;
                break;
            case 0x70: // LD (HL), B
                memory[index: registers.HL] = registers.B;
                break;
            case 0x71: // LD (HL), C
                memory[index: registers.HL] = registers.C;
                break;
            case 0x72: // LD (HL), D
                memory[index: registers.HL] = registers.D;
                break;
            case 0x73: // LD (HL), E
                memory[index: registers.HL] = registers.E;
                break;
            case 0x74: // LD (HL), H
                memory[index: registers.HL] = registers.H;
                break;
            case 0x75: // LD (HL), L
                memory[index: registers.HL] = registers.L;
                break;
            case 0x76: // HALT
                break;
            case 0x77: // LD (HL), A
                memory[index: registers.HL] = registers.A;
                break;
            case 0x78: // LD A, B
                registers.A = registers.B;
                break;
            case 0x79: // LD A, C
                registers.A = registers.C;
                break;
            case 0x7A: // LD A, D
                registers.A = registers.D;
                break;
            case 0x7B: // LD A, E
                registers.A = registers.E;
                break;
            case 0x7C: // LD A, H
                registers.A = registers.H;
                break;
            case 0x7D: // LD A, L
                registers.A = registers.L;
                break;
            case 0x7E: // LD A, (HL)
                registers.A = memory[index: registers.HL];
                break;
            case 0x7F: // LD A, A
                break;
            case 0x80: // ADD A, B
                registers.A = registers.A.Add(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x81: // ADD A, C
                registers.A = registers.A.Add(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x82: // ADD A, D
                registers.A = registers.A.Add(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x83: // ADD A, E
                registers.A = registers.A.Add(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x84: // ADD A, H
                registers.A = registers.A.Add(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x85: // ADD A, L
                registers.A = registers.A.Add(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x86: // ADD A, (HL)
                break;
            case 0x87: // ADD A, A
                registers.A = registers.A.Add(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0x88: // ADC A, B
                registers.A = registers.A.Adc(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x89: // ADC A, C
                registers.A = registers.A.Adc(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x8A: // ADC A, D
                registers.A = registers.A.Adc(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x8B: // ADC A, E
                registers.A = registers.A.Adc(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x8C: // ADC A, H
                registers.A = registers.A.Adc(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x8D: // ADC A, L
                registers.A = registers.A.Adc(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x8E: // ADC A, (HL)
                break;
            case 0x8F: // ADC A, A
                registers.A = registers.A.Adc(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0x90: // SUB A, B
                registers.A = registers.A.Sub(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x91: // SUB A, C
                registers.A = registers.A.Sub(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x92: // SUB A, D
                registers.A = registers.A.Sub(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x93: // SUB A, E
                registers.A = registers.A.Sub(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x94: // SUB A, H
                registers.A = registers.A.Sub(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x95: // SUB A, L
                registers.A = registers.A.Sub(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x96: // SUB A, (HL)
                break;
            case 0x97: // SUB A, A
                registers.A = registers.A.Sub(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0x98: // SBC A, B
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0x99: // SBC A, C
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0x9A: // SBC A, D
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0x9B: // SBC A, E
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0x9C: // SBC A, H
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0x9D: // SBC A, L
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0x9E: // SBC A, (HL)
                break;
            case 0x9F: // SBC A, A
                registers.A = registers.A.Sbc(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xA0: // AND A, B
                registers.A = registers.A.And(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xA1: // AND A, C
                registers.A = registers.A.And(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xA2: // AND A, D
                registers.A = registers.A.And(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xA3: // AND A, E
                registers.A = registers.A.And(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xA4: // AND A, H
                registers.A = registers.A.And(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xA5: // AND A, L
                registers.A = registers.A.And(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xA6: // AND A, (HL)
                break;
            case 0xA7: // AND A, A
                registers.A = registers.A.And(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xA8: // XOR A, B
                registers.A = registers.A.Xor(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xA9: // XOR A, C
                registers.A = registers.A.Xor(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xAA: // XOR A, D
                registers.A = registers.A.Xor(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xAB: // XOR A, E
                registers.A = registers.A.Xor(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xAC: // XOR A, H
                registers.A = registers.A.Xor(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xAD: // XOR A, L
                registers.A = registers.A.Xor(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xAE: // XOR A, (HL)
                break;
            case 0xAF: // XOR A, A
                registers.A = registers.A.Xor(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xB0: // OR A, B
                registers.A = registers.A.Or(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xB1: // OR A, C
                registers.A = registers.A.Or(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xB2: // OR A, D
                registers.A = registers.A.Or(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xB3: // OR A, E
                registers.A = registers.A.Or(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xB4: // OR A, H
                registers.A = registers.A.Or(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xB5: // OR A, L
                registers.A = registers.A.Or(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xB6: // OR A, (HL)
                break;
            case 0xB7: // OR A, A
                registers.A = registers.A.Or(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xB8: // CP A, B
                registers.A.Cp(flags: ref flags, other: registers.B);
                registers.F = ((byte)flags);
                break;
            case 0xB9: // CP A, C
                registers.A.Cp(flags: ref flags, other: registers.C);
                registers.F = ((byte)flags);
                break;
            case 0xBA: // CP A, D
                registers.A.Cp(flags: ref flags, other: registers.D);
                registers.F = ((byte)flags);
                break;
            case 0xBB: // CP A, E
                registers.A.Cp(flags: ref flags, other: registers.E);
                registers.F = ((byte)flags);
                break;
            case 0xBC: // CP A, H
                registers.A.Cp(flags: ref flags, other: registers.H);
                registers.F = ((byte)flags);
                break;
            case 0xBD: // CP A, L
                registers.A.Cp(flags: ref flags, other: registers.L);
                registers.F = ((byte)flags);
                break;
            case 0xBE: // CP A, (HL)
                break;
            case 0xBF: // CP A, A
                registers.A.Cp(flags: ref flags, other: registers.A);
                registers.F = ((byte)flags);
                break;
            case 0xC6: // ADD A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Add(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xC9: // RET
                break;
            case 0xCB: // ???
                programCounter = registers.IncrementProgramCounter();

                switch (memory[index: programCounter]) {
                    default:
                        throw new NotSupportedException();
                }

                break;
            case 0xCE: // ADC A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Adc(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xD6: // SUB A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Sub(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xD9: // RETI
                break;
            case 0xDE: // SBC A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Sbc(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xE6: // AND A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.And(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xEE: // XOR A, D8
                programCounter = registers.IncrementProgramCounter();
                registers.A = registers.A.Xor(flags: ref flags, other: memory[index: programCounter]);
                registers.F = ((byte)flags);
                break;
            case 0xF3: // DI
                break;
            case 0xF6: // OR A, D8
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

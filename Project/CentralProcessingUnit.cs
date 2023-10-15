namespace ByteTerrace.Emulation.GameBoy;

sealed class CentralProcessingUnit
{
    private Registers m_registers;

    public byte Accumulator { get => m_registers.A; }
    public Flags Flags { get; }
    public Memory Memory { get; }
    public ushort ProgramCounter { get => m_registers.PC; }
    public ushort StackPointer { get => m_registers.SP; }

    public CentralProcessingUnit() {
        var memory = new Memory();
        var registers = new Registers();

        m_registers = registers;

        Flags = new Flags(registers: registers);
        Memory = memory;
    }

    public void Run() {
        var flags = 0U;
        var memory = Memory;
        var programCounter = ProgramCounter;
        var registers = m_registers;

        do {
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
                case 0x86: // ADD HL
                    break;
                case 0x96: // SUB HL
                    break;
                case 0xA6: // AND HL
                    break;
                case 0xAE: // XOR HL
                    break;
                case 0xB6: // OR HL
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

            programCounter = registers.IncrementProgramCounter();
        } while (true);
    }
}

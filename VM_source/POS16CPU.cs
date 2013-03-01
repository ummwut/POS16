using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class POS16CPU
{
    public POS16HdwrMngr hm;
    public ushort[] mem;
    private ushort[] reg;
    private ushort[] sreg;
    private ushort[] hwiq;
    private ushort[] swiq;
    private byte hwii;
    private byte swii;

    public void init(POS16HdwrMngr hmobj, ushort[] m)
    {
        hm = hmobj;
        mem = m;
        reg = new ushort[14];
        sreg = new ushort[32];  //sreg[0] = software interrupt vector, sreg[1] = hardware interrupt vector
        hwiq = new ushort[256];
        swiq = new ushort[256];
        hwii = 0;
        swii = 0;
    }

    public void runCPU()
    {
        //dunno what to do here yet
        while (false) //some qualifiers
        {
            nextop();
        }
    }

    public void nextop()
    {
        //check for interrupts on both queues
        //read next word from memory
        //execute code
    }

    private ushort readreg(byte index)
    {
        if ((index & 0x10) > 0)
        {
            return mem[(ushort)(readreg((byte)(index & 0x0f)) + reg[10])];
        }
        else
        {
            switch (index)
            {
                case 14:
                    return mem[reg[13]++];
                case 15:
                    return mem[reg[11]++];
                default:
                    return reg[index];
            }
        }
    }

    private void writereg(byte index, ushort val)
    {
        if ((index & 0x10) > 0)
        {
            mem[(ushort)(readreg((byte)(index & 0x0f)) + reg[10])] = val;
        }
        else
        {
            switch (index)
            {
                case 14:
                    mem[--reg[13]] = val;
                    break;
                case 15:
                    break;
                default:
                    reg[index] = val;
                    break;
            }
        }
    }

    private void comparereg(byte leftreg, byte rightreg)
    {
        ushort left = readreg(leftreg);
        ushort right = readreg(rightreg);
    }

    private void compareval(ushort leftval, ushort rightval)
    {

    }

    public void addhwi(ushort i)
    {

    }

    private void addswi(ushort i)
    {

    }

    private ushort nexthwi()
    {
        return 0;
    }

    private ushort nextswi()
    {
        return 0;
    }

    private bool hwi()
    {
        return false;
    }

    private bool swi()
    {
        return false;
    }

}


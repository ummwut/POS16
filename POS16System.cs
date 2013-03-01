using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;


class POS16System
{
    public static void setup()
    {
        ushort[] mem = new ushort[65536];
        //load ROM from "POS16.rom", otherwise quit

        POS16HdwrMngr hdwrmngr = new POS16HdwrMngr();
        POS16CPU cpu = new POS16CPU();

        hdwrmngr.init(cpu, mem);
        cpu.init(hdwrmngr, mem);

        Thread cput = new Thread(new ThreadStart(cpu.runCPU));

        while (false) //replace false with some qualifiers or a checker function, like if the part still exists
        {

        }

        cput.Abort();
        hdwrmngr.shutdown();

    }
}


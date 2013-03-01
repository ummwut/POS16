using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;


class POS16HdwrMngr
{
    public POS16CPU cpu;
    public ushort[] mem;
    public POS16Hdwr[] deviceIO;
    public Thread[] devices;
    public ushort devicenum;

    public void shutdown()
    {
        for (int i = 0; i <= 65535; i++)
        {
            devices[i].Abort();
        }
    }

    public void init(POS16CPU cpuobj, ushort[] m)
    {
        cpu = cpuobj;
        mem = m;
        devicenum = 0;
        deviceIO = new POS16Hdwr[65535];
        devices = new Thread[65535];
    }

    public void reqattention(POS16Hdwr h)
    {
        cpu.addhwi(h.deviceID);
    }

    public ushort hdwraction(ushort index, ushort message)
    {
        return index;
    }

    private void initdevice(ushort index)
    {

    }

    private ushort status(ushort index) //status == 0: no hardware present in slot
    {
        return 0;
    }

    private void findhdwr()
    {

    }

    private void rmhdwr(ushort index)
    {

    }

    private void starthdwr(ushort index)
    {
        devices[index].Start();
    }

}


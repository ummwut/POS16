using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


interface POS16Hdwr
{
    public POS16HdwrMngr control; //access to hardware controller for signalling
    public ushort[] mem; //grants the device access to memory for rapid data read/write
    public ushort memref; //address in memory at which the CPU expects memory to be read/written
    public ushort deviceID; //the device's address on the hardware bus
    public void signal(ushort s); //signal from the CPU, which may indicate an action to be taken or a status update
    public ushort response(); //returns a ushort to the CPU 
    public byte status(); //returns a flag byte indicating device status
    public void operating(); //normal device operations. this method will be called on device start
}

